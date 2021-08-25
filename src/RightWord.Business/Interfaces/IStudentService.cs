using RightWord.Business.Models;
using System;
using System.Threading.Tasks;

namespace RightWord.Business.Services
{
    public interface IStudentService : IDisposable
    {
        Task Add(Student agency);
        Task Update(Student agency);
        Task Delete(Guid id);
    }
}