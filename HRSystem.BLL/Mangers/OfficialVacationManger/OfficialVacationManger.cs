using HRSystem.DAL.Data.Models;
using HRSystem.DAL.Repository.OfficialVacationRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.OfficialVacationManger
{
    public class OfficialVacationManger : IOfficialVacationManger
    {
        private readonly IOfficialVacationRepo _officialVacationRepo;
        public OfficialVacationManger(IOfficialVacationRepo officialVacationRepo)
        {
            _officialVacationRepo = officialVacationRepo;
        }

        public async Task delete(string id)
        {
            _officialVacationRepo.delete(id);
        }

        public List<OfficialVocations> GetAllVacations()
        {
            return _officialVacationRepo.GetAllVacations();
        }

        public OfficialVocations GetVacationById(string id)
        {
            return _officialVacationRepo.GetVacationById(id);
        }

        public void Insert(OfficialVocations officialVacations)
        {
            _officialVacationRepo.Insert(officialVacations);
        }

        public void Save()
        {
            _officialVacationRepo.Save();
        }

        public async Task update(OfficialVocations Vocations)
        {
            _officialVacationRepo.update(Vocations);
        }
    }
}
