using HDUD_WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDUD_WEBAPI.Repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        bool Login(User item);
        void Add(User item);
    }
}
