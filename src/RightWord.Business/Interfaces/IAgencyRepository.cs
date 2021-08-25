using RightWord.Business.Models;
using System;
using System.Threading.Tasks;

namespace RightWord.Business.Interfaces
{
    public interface IAgencyRepository : IRepository<Agency>
    {
        Task<Agency> GetAgencyStudents(Guid id);
        Task<Agency> GetAgencyStudentsDocuments(Guid id);
    }
}
