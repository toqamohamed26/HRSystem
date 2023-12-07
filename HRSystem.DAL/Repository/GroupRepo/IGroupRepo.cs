using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repository.GroupRepo
{
    public interface IGroupRepo
    {
        void Insert(Group group);
        void Save();
        List<Group> GetAllGroups();

    }
}
