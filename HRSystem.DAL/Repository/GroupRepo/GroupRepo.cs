using HRSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repository.GroupRepo
{
    public class GroupRepo : IGroupRepo
    {
        private readonly HREntity context;
        public GroupRepo(HREntity shippingContext)
        {
            context = shippingContext;
        }
        public List<Group> GetAllGroups()
        {
            return context.Groups.Include(e => e.GroupPermissions).ToList();
        }

        public void Insert(Group group)
        {
            context.Groups.Add(group);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
