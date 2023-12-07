using HRSystem.DAL.Data.Models;
using HRSystem.DAL.Repository.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.UserManger
{
    public class UserManger : IUserManger
    {
        private readonly IUserRepo _userRepo;
        public UserManger(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task delete(string id)
        {
             _userRepo.delete(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User GetUserById(string id)
        {
           return _userRepo.GetUserById(id);
        }

        public async Task update(User User)
        {
            _userRepo.update(User);
        }
    }
}
