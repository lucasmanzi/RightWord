using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RightWord.Business.Interfaces
{
    public interface IUserService
    {
        Dictionary<string, string> GetUserProfile(string email);
    }
}
