using HRSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repository.GeneralSettingsRepo
{
    public class GeneralSettRepo : IGeneralSettRepo
    {
        private readonly HREntity context;
        public GeneralSettRepo(HREntity shippingContext)
        {
            context = shippingContext;
        }
        public List<GeneralSettings> GetAllSettings()
        {
            return context.GeneralSettings.Where(e => e.IsDeleted == false).ToList();
        }

        public void Insert(GeneralSettings generalSettings)
        {
            context.GeneralSettings.Add(generalSettings);
            Save();
        }
        public void delete(string id)
        {
            var generalSettings = context.GeneralSettings.FirstOrDefault(e => e.ID == id);
            generalSettings.IsDeleted = true;
            update(generalSettings);

        }
        public void update(GeneralSettings generalSettings)
        {
            context.Entry(generalSettings).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public GeneralSettings GetSettingsById(string id)
        {
            return context.GeneralSettings.Where(s => s.ID == id).FirstOrDefault();
        }
    }
}
