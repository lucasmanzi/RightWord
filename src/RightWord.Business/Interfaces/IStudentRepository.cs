using RightWord.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RightWord.Business.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetStudentByAgency(Guid agencyId);
        Task<IEnumerable<Student>> GetStudentsAgencies();
        Task<Student> GetStudentAgency(Guid id);
    }
}
