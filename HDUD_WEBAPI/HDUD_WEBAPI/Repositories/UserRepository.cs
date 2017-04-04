using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HDUD_WEBAPI.Models;

namespace HDUD_WEBAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HDUDContext _context;

        public UserRepository(HDUDContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            return _context.User.FirstOrDefault(w => w.UserId == id);
        }

        public bool Login(User item)
        {
            return _context.User.Count(w => w.Email == item.Email && w.Password == item.Password) > 0;
        }

        public void Add(User item)
        {
            _context.User.Add(item);
            _context.SaveChanges();
        }
    }
}
