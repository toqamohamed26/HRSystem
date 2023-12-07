using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repository.OfficialVacationRepo
{
    public interface IOfficialVacationRepo
    {
        void Insert(OfficialVocations officialVacations);
        void update(OfficialVocations officialVocations);
        OfficialVocations GetVacationById(string id);

        void delete(string id);
        void Save();
        List<OfficialVocations> GetAllVacations();
    }
}
