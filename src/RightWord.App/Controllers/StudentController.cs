using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RightWord.App.Extensions;
using RightWord.App.ViewModels;
using RightWord.Business.Interfaces;
using RightWord.Business.Models;
using RightWord.Business.Services;

namespace RightWord.App.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentService _studentService;
        private readonly IAgencyRepository _agencyRepository;
        //private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        
        public StudentController(IStudentRepository studentRepository,
                                 IAgencyRepository agencyRepository,
                                 IStudentService studentService,
                                 //IDocumentRepository documentRepository,
                                 IMapper mapper,
                                 INotificator notificator) : base(notificator)
        {
            _studentRepository = studentRepository;
            _agencyRepository = agencyRepository;
            _studentService = studentService;
            //_documentRepository = documentRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin, Agency")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<StudentViewModel> students;

            if (User.IsInRole("Admin"))
                students = _mapper.Map<IEnumerable<StudentViewModel>>(await _studentRepository.GetStudentsAgencies());
            else
            {
                var agency = await _agencyRepository.Find(a => a.Email == User.Identity.Name);
                if (agency.Any())
                    students = _mapper.Map<IEnumerable<StudentViewModel>>(await _studentRepository.GetStudentsAgencies()).Where(s => s.Active && s.AgencyId == agency.FirstOrDefault().Id);
                else
                    return RedirectToAction("Create", "Agency");
            }

            return View(students);
        }

        //[Authorize(Roles = "Admin, Agency")]
        public async Task<IActionResult> Details(Guid id)
        {
            if (User.IsInRole("Student"))
            {
                var result = await _studentRepository.Find(x => x.Email == User.Identity.Name);
                if (result.Any())
                    id = _mapper.Map<IEnumerable<StudentViewModel>>(result).FirstOrDefault().Id;
                else
                    return RedirectToAction("Create");
            }

            var studentViewModel = await GetStudent(id);

            if (studentViewModel == null) return NotFound();

            return View(studentViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var studentViewModel = await FillStudent(new StudentViewModel());

            if (User.IsInRole("Student"))
            {
                studentViewModel.Email = User.Identity.Name;
                studentViewModel.AgencyId = _agencyRepository.Find(a => a.Email == "admin@rightword.com").Result.FirstOrDefault().Id;
            }

            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            studentViewModel = await FillStudent(studentViewModel);

            if (User.IsInRole("Student"))
            {
                studentViewModel.Email = User.Identity.Name;
                studentViewModel.AgencyId = _agencyRepository.Find(a => a.Email == "admin@rightword.com").Result.FirstOrDefault().Id;
            }

            if (!ModelState.IsValid) return View(studentViewModel);

            if (studentViewModel.PassportUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";

                if (!await UploadArquivo(studentViewModel.PassportUpload, imgPrefixo))
                {
                    return View(studentViewModel);
                }

                studentViewModel.PassportImage = imgPrefixo + studentViewModel.PassportUpload.FileName;
            }
            else
            {
                return View(studentViewModel);
            }
            
            await _studentService.Add(_mapper.Map<Student>(studentViewModel));

            if(!IsValidOperation()) return View(studentViewModel);

            TempData["Success"] = "Student successfully created!";

            if (User.IsInRole("Student"))
                return RedirectToAction("Index", "Home");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (User.IsInRole("Student"))
            {
                var result = await _studentRepository.Find(x => x.Email == User.Identity.Name);
                if (result.Any())
                    id = _mapper.Map<IEnumerable<StudentViewModel>>(result).FirstOrDefault().Id;
                else
                    return RedirectToAction("Create");
            }

            var studentViewModel = await GetStudent(id);
            studentViewModel = await FillStudent(studentViewModel);

            if (studentViewModel == null) return NotFound();

            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StudentViewModel studentViewModel)
        {
            if (id != studentViewModel.Id) return NotFound();

            studentViewModel = await FillStudent(studentViewModel);

            if (studentViewModel.PassportUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(studentViewModel.PassportUpload, imgPrefixo))
                    return View(studentViewModel);

                studentViewModel.PassportImage = imgPrefixo + studentViewModel.PassportUpload.FileName;
            }
            else
            {
                studentViewModel.PassportImage = (await GetStudent(id)).PassportImage;
            }

            if (!ModelState.IsValid) return View(studentViewModel);

            await _studentService.Update(_mapper.Map<Student>(studentViewModel));

            if (!IsValidOperation()) return View(studentViewModel);

            TempData["Success"] = "Student successfully edited!";

            if (User.IsInRole("Student"))
                return RedirectToAction("Index", "Home");

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var studentViewModel = await GetStudent(id);

            if (studentViewModel == null) return NotFound();

            return View(studentViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var studentViewModel = await GetStudent(id);
            if (studentViewModel == null) return NotFound();

            await _studentService.Delete(id);

            if (!IsValidOperation()) return View(studentViewModel);

            TempData["Success"] = "Student successfully edited!";

            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> GetDocuments(Guid id)
        //{
        //    var documents = await GetStudentDocuments(id);

        //    if (documents == null)
        //    {
        //        return NotFound();
        //    }

        //    return PartialView("_ListDocuments", new StudentViewModel { Documents = documents });
        //}

        //public async Task<IActionResult> CreateDocument(Guid id)
        //{
        //    return PartialView("_CreateDocument", new DocumentViewModel { StudentId = id });
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateDocument([FromForm] DocumentViewModel document)
        //{
        //    if (!ModelState.IsValid) return PartialView("_CreateDocument", document);

        //    var imgPrefixo = Guid.NewGuid() + "_";

        //    if (!await UploadArquivo(document.ImageUpload, imgPrefixo))
        //    {
        //        return PartialView("_CreateDocument", document);
        //    }

        //    document.Image = imgPrefixo + document.ImageUpload.FileName;

        //    await _documentRepository.Add(_mapper.Map<Document>(document));

        //    var url = Url.Action("GetDocuments", "Student", new { id = document.StudentId });

        //    return Json(new { success = true, url });
        //}

        //[HttpPost, ActionName("DeleteDocument")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteDocument(Guid id)
        //{
        //    var documentViewModel = _mapper.Map<IEnumerable<DocumentViewModel>>(await _documentRepository.GetById(id));
        //    if (documentViewModel == null) return NotFound();

        //    await _documentRepository.Delete(id);

        //    return RedirectToAction(nameof(Index));
        //}

        //private async Task<IEnumerable<DocumentViewModel>> GetStudentDocuments(Guid id)
        //{
        //    //var student = _mapper.Map<StudentViewModel>(await _studentRepository.GetStudentAgency(id));
        //    var documents = _mapper.Map<IEnumerable<DocumentViewModel>>(await _documentRepository.GetDocumentsByStudent(id));

        //    return documents;
        //}

        private async Task<StudentViewModel> GetStudent(Guid id)
        {
            var student = _mapper.Map<StudentViewModel>(await _studentRepository.GetStudentAgency(id));
            student.Agencies = _mapper.Map<IEnumerable<AgencyViewModel>>(await _agencyRepository.GetAll());
            //student.Documents = _mapper.Map<IEnumerable<DocumentViewModel>>(await _documentRepository.GetDocumentsByStudent(id));
            return student;
        }

        private async Task<StudentViewModel> FillStudent(StudentViewModel student)
        {
            student.Agencies = User.IsInRole("Agency")
                ? _mapper.Map<IEnumerable<AgencyViewModel>>(await _agencyRepository.Find(a => a.Email == User.Identity.Name))
                : _mapper.Map<IEnumerable<AgencyViewModel>>(await _agencyRepository.GetAll());
            student.Countries = CultureHelper.CountryList();
            student.Languages = CultureHelper.LanguageList();
            //student.Documents = _mapper.Map<IEnumerable<DocumentViewModel>>(await _documentRepository.GetDocumentsByStudent(student.Id));

            return student;
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo == null || arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

    }
}