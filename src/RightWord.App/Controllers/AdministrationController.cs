using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RightWord.App.ViewModels;
using RightWord.Business.Interfaces;
using RightWord.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RightWord.App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        private readonly IAgencyService _agencyService;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        UserManager<IdentityUser> userManager,
                                        IStudentService studentService,
                                        IStudentRepository studentRepository,
                                        IAgencyService agencyService,
                                        IAgencyRepository agencyRepository,
                                        IMapper mapper,
                                        INotificator notificator) : base(notificator)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _studentService = studentService;
            _studentRepository = studentRepository;
            _agencyService = agencyService;
            _agencyRepository = agencyRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.Name
                };

                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Administration");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null) return NotFound();

            var userIdentity = (ClaimsIdentity)User.Identity;
            var claims = userIdentity.Claims;
            var roleClaimType = userIdentity.RoleClaimType;
            var roles = claims.Where(c => c.Type == ClaimTypes.Role).ToList();

            var model = new RoleViewModel
            {
                Id = new Guid(role.Id),
                Name = role.Name
            };

            var usersList = await _userManager.GetUsersInRoleAsync(role.Name);

            foreach (var item in usersList)
            {
                model.Users.Add(item.UserName);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(RoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id.ToString());

            if (role == null) return NotFound();

            role.Name = model.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(Guid id)
        {
            ViewBag.Id = id;

            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null) return NotFound();

            var model = new List<UserRoleViewModel>();

            var usersList = await _userManager.GetUsersInRoleAsync(role.Name);

            foreach (var user in _userManager.Users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                if (!userRoles.Any() || usersList.Any(x => x.Id == user.Id))
                {
                    if (user.UserName != User.Identity.Name && user.UserName.ToLower() != "support@rightword.com")
                    {
                        var userRoleViewModel = new UserRoleViewModel
                        {
                            UserId = user.Id,
                            UserName = user.UserName,
                            IsSelected = usersList.Any(x => x.Id == user.Id)
                        };

                        model.Add(userRoleViewModel);
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(IEnumerable<UserRoleViewModel> model, Guid Id)
        {
            var role = await _roleManager.FindByIdAsync(Id.ToString());

            if (role == null) return NotFound();

            foreach (var item in model)
            {
                var user = await _userManager.FindByNameAsync(item.UserName);

                if (item.IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!item.IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }

            return RedirectToAction("EditRole", new { Id });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id, Guid roleId)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return NotFound();
            await _userManager.DeleteAsync(user);

            var student = await _studentRepository.Find(x => x.Email == user.UserName);
            if (student.Any())
            {
                var studentId = _mapper.Map<IEnumerable<StudentViewModel>>(student).FirstOrDefault().Id;
                await _studentService.Delete(studentId);
            }

            var agency = await _agencyRepository.Find(x => x.Email == user.UserName);
            if (agency.Any())
            {
                var agencyId = _mapper.Map<IEnumerable<AgencyViewModel>>(agency).FirstOrDefault().Id;
                await _agencyService.Delete(agencyId);
            }


            TempData["Success"] = "Student successfully deleted!";

            id = roleId;

            return RedirectToAction("EditUsersInRole", new { id });
        }

    }
}
