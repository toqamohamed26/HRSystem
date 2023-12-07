using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.OfficialVacationManger
{
    public interface IOfficialVacationManger
    {
        void Insert(OfficialVocations officialVacations);
        void Save();
        List<OfficialVocations> GetAllVacations();
        OfficialVocations GetVacationById(string id);
        Task update(OfficialVocations Vocations);
        Task delete(string id);
    }
}
