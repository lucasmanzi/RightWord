using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RightWord.App.ViewModels;
using RightWord.Business.Interfaces;
using RightWord.Business.Models;
using RightWord.Business.Services;

namespace RightWord.App.Controllers
{
    public class AgencyController : BaseController
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IAgencyService _agencyService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AgencyController(IAgencyRepository agencyRepository,
                                IAgencyService agencyService,
                                UserManager<IdentityUser> userManager,
                                IMapper mapper,
                                INotificator notificator) : base(notificator)
        {
            _agencyRepository = agencyRepository;
            _agencyService = agencyService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AgencyViewModel>>(await _agencyRepository.GetAll()));
        }

        [Authorize(Roles = "Admin, Agency")]
        public async Task<IActionResult> Details(Guid id)
        {
            if (User.IsInRole("Agency"))
            {
                var result = await _agencyRepository.Find(x => x.Email == User.Identity.Name);
                if (result.Any())
                    id = _mapper.Map<IEnumerable<AgencyViewModel>>(result).FirstOrDefault().Id;
                else
                    return RedirectToAction("Create");
            }

            var agencyViewModel = _mapper.Map<AgencyViewModel>(await _agencyRepository.GetById(id));

            if (agencyViewModel == null) return NotFound();

            return View(agencyViewModel);
        }

        [Authorize(Roles = "Admin, Agency")]
        public async Task<IActionResult> Create()
        {
            if (User.IsInRole("Agency"))
            {
                var result = await _agencyRepository.Find(x => x.Email == User.Identity.Name);
                if (result.Any())
                    return RedirectToAction("Edit/", result.FirstOrDefault().Id.ToString());
            }

            return View();
        }

        [Authorize(Roles = "Admin, Agency")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgencyViewModel agencyViewModel)
        {
            if (User.IsInRole("Agency"))
            {
                agencyViewModel.Email = User.Identity.Name;
                ModelState.Clear();
                TryValidateModel(agencyViewModel);
            }

            if (!ModelState.IsValid) return View(agencyViewModel);

            await _agencyService.Add(_mapper.Map<Agency>(agencyViewModel));

            if(!IsValidOperation()) return View(agencyViewModel);

            TempData["Success"] = "Agency successfully created!";

            if (!User.IsInRole("Admin"))
                return RedirectToAction("Index", "Home");

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin, Agency")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var agencyViewModel = _mapper.Map<AgencyViewModel>(await _agencyRepository.GetById(id));

            if (agencyViewModel == null) return NotFound();

            return View(agencyViewModel);
        }

        [Authorize(Roles = "Admin, Agency")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AgencyViewModel agencyViewModel)
        {
            if (id != agencyViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(agencyViewModel);

            await _agencyService.Update(_mapper.Map<Agency>(agencyViewModel));

            if (!IsValidOperation()) return View(agencyViewModel);

            TempData["Success"] = "Agency successfully edited!";

            if (!User.IsInRole("Admin"))
                return RedirectToAction("Index", "Home");

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var agencyViewModel = _mapper.Map<AgencyViewModel>(await _agencyRepository.GetById(id));

            if (agencyViewModel == null) return NotFound();

            return View(agencyViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string email)
        {
            var user = await _userManager.FindByNameAsync(email);

            await _agencyService.Delete(id);

            if (user != null) { await _userManager.DeleteAsync(user); }

            TempData["Success"] = "Agency successfully deleted!";

            return RedirectToAction(nameof(Index));
        }
    }
}
