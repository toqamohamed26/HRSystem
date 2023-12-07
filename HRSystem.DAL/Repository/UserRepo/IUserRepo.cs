using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repository.UserRepo
{
    public interface IUserRepo
    {
        List<User> GetAllUsers();
        User GetUserById(string id);
        void update(User user);
        void delete(string id);
        void save();
    }
}
