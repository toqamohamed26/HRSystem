using HRSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repository.OfficialVacationRepo
{
    public class OfficialVacationRepo : IOfficialVacationRepo
    {
        private readonly HREntity context;
        public OfficialVacationRepo(HREntity shippingContext)
        {
            context = shippingContext;
        }
        public List<OfficialVocations> GetAllVacations()
        {
            return context.OfficialVocations.Where(e => e.IsDeleted == false).ToList();
        }

        public void Insert(OfficialVocations officialVacations)
        {
            context.OfficialVocations.Add(officialVacations);
            Save();
        }

        public void delete(string id)
        {
            var officialVacations = context.OfficialVocations.FirstOrDefault(e => e.Id == id);
            officialVacations.IsDeleted = true;
            update(officialVacations);

        }
        public void update(OfficialVocations officialVacations)
        {

            context.Entry(officialVacations).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public OfficialVocations GetVacationById(string id)
        {
            return context.OfficialVocations.Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
