using Microsoft.EntityFrameworkCore;
using RightWord.Business.Interfaces;
using RightWord.Business.Models;
using RightWord.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightWord.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(RightWordDbContext context) : base(context) { }

        public async Task<Student> GetStudentAgency(Guid id)
        {
            return await Db.Students.AsNoTracking().Include(a => a.Agency)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudentsAgencies()
        {
            return await Db.Students.AsNoTracking().Include(a => a.Agency)
                .OrderBy(s => s.SurName).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentByAgency(Guid agencyId)
        {
            return await Find(s => s.AgencyId == agencyId);
        }

        
    }
}
