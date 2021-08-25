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
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(RightWordDbContext context) : base(context) { }

        public async Task<IEnumerable<Document>> GetDocumentsByStudent(Guid studentId)
        {
            return await Find(d => d.StudentId == studentId);
        }
    }
}
