using RightWord.Business.Interfaces;
using RightWord.Business.Models;
using RightWord.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightWord.Business.Services
{
    public class StudentService : BaseService, IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository,
                              INotificator notificator) : base(notificator)
        {
            _studentRepository = studentRepository;
        }

        public async Task Add(Student student)
        {
            if (!ExecuteValidation(new StudentValidation(), student)) return;

            if (_studentRepository.Find(a => a.Email == student.Email).Result.Any())
            {
                Notify("This email is alredy taken.");
                return;
            }

            await _studentRepository.Add(student);
        }

        public async Task Update(Student student)
        {
            if (!ExecuteValidation(new StudentValidation(), student)) return;

            if (_studentRepository.Find(a => a.Email == student.Email && a.Id != student.Id).Result.Any())
            {
                Notify("This email is alredy taken.");
                return;
            }

            await _studentRepository.Update(student);
        }
        public async Task Delete(Guid id)
        {
            await _studentRepository.Delete(id);
        }

        public void Dispose()
        {
            _studentRepository?.Dispose();
        }
    }
}
