using RightWord.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightWord.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAgencyRepository _agencyRepository;

        public UserService(IStudentRepository studentRepository,
                           IAgencyRepository agencyRepository,
                           INotificator notificator) : base(notificator)
        {
            _studentRepository = studentRepository;
            _agencyRepository = agencyRepository;
        }

        public Dictionary<string, string> GetUserProfile(string email)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string role;
            string id = string.Empty;

            var agency = _agencyRepository.Find(a => a.Email == email).Result;

            if (agency.Any())
            {
                role = "Agency";
                id = agency.FirstOrDefault().Id.ToString();
            }
            else
            {
                var student = _studentRepository.Find(a => a.Email == email).Result;
                role = "Student";

                if (student.Any())
                {
                    id = student.FirstOrDefault().Id.ToString();
                }
            }

            result.Add("role", role);
            result.Add("id", id);

            return result;
        }
    }
}
