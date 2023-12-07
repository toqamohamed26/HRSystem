using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.GroupManger
{
    public interface IGroupManger
    {
        void Insert(Group group);
        void Save();
        List<Group> GetAllGroups();
    }
}
