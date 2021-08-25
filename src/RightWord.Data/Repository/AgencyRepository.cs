using Microsoft.EntityFrameworkCore;
using RightWord.Business.Interfaces;
using RightWord.Business.Models;
using RightWord.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RightWord.Data.Repository
{
    public class AgencyRepository : Repository<Agency>, IAgencyRepository
    {
        public AgencyRepository(RightWordDbContext context) : base(context) { }

        public async Task<Agency> GetAgencyStudents(Guid id)
        {
            return await Db.Agencies.AsNoTracking().Include(s => s.Students)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Agency> GetAgencyStudentsDocuments(Guid id)
        {
            //return await Db.Agencies.AsNoTracking()
            //    .Include(s => s.Students)
            //    .Include(s => s.Documents)
            //    .FirstOrDefaultAsync(a => a.Id == id);
            throw new NotImplementedException();
        }
    }
}
