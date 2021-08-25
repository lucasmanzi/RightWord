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
    public class AgencyService : BaseService, IAgencyService
    {
        private readonly IAgencyRepository _agencyRepository;

        public AgencyService(IAgencyRepository agencyRepository,
                             INotificator notificator) : base(notificator)
        {
            _agencyRepository = agencyRepository;
        }

        public async Task Add(Agency agency)
        {
            if (!ExecuteValidation(new AgencyValidation(), agency)) return;

            if(_agencyRepository.Find(a => a.Email == agency.Email).Result.Any())
            {
                Notify("This email is alredy taken.");
                return;
            }

            await _agencyRepository.Add(agency);
        }

        public async Task Update(Agency agency)
        {
            if (!ExecuteValidation(new AgencyValidation(), agency)) return;

            if (_agencyRepository.Find(a => a.Email == agency.Email && a.Id != agency.Id).Result.Any())
            {
                Notify("This email is alredy taken.");
                return;
            }

            await _agencyRepository.Update(agency);
        }

        public async Task Delete(Guid id)
        {
            if (_agencyRepository.GetAgencyStudents(id).Result.Students.Any())
            {
                Notify("This agency has affiliated students registered.");
                return;
            }

            await _agencyRepository.Delete(id);
        }

        public void Dispose()
        {
            _agencyRepository?.Dispose();
        }
    }
}
