using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.UserManger
{
    public interface IUserManger
    {
        List<User> GetAllUsers();
        User GetUserById(string id);
        Task update(User User);
        Task delete(string id);
    }
}
