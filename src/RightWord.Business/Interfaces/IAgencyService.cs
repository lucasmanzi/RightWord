using RightWord.Business.Models;
using System;
using System.Threading.Tasks;

namespace RightWord.Business.Services
{
    public interface IAgencyService : IDisposable
    {
        Task Add(Agency agency);
        Task Update(Agency agency);
        Task Delete(Guid id);
    }
}