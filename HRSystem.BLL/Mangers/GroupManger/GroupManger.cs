using HRSystem.DAL.Data.Models;
using HRSystem.DAL.Repository.GroupRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.GroupManger
{
    public class GroupManger : IGroupManger
    {
        private readonly IGroupRepo _groupRepo;
        public GroupManger(IGroupRepo groupRepo)
        {
            _groupRepo = groupRepo;
        }
        public List<Group> GetAllGroups()
        {
            return _groupRepo.GetAllGroups();
        }

        public void Insert(Group group)
        {
            _groupRepo.Insert(group);
        }

        public void Save()
        {
            _groupRepo.Save();
        }
    }
}
