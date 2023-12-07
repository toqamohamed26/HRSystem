using HRSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repository.UserRepo
{
    public class UserRepo : IUserRepo
    {
        HREntity context;
        public UserRepo(HREntity context)
        {
            this.context = context;

        }

        public List<User> GetAllUsers()
        {
            var res = context.users.Where(e => e.IsDeleted == false).Include(e => e.Group).ToList();
            return res;
        }
        public void delete(string id)
        {
            var user = context.users.FirstOrDefault(e => e.Id == id);
            user.IsDeleted = true;
            update(user);

        }
        public void update(User user)
        {

            context.Entry(user).State = EntityState.Modified;
            save();
        }
      
        public void save()
        {
            context.SaveChanges();
        }

        public User GetUserById(string id)
        {
            return context.users.Where(s => s.Id == id).Include(e => e.Group).FirstOrDefault();
        }
    }
}
