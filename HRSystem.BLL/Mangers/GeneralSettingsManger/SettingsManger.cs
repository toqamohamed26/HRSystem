using HRSystem.DAL.Data.Models;
using HRSystem.DAL.Repository.GeneralSettingsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.GeneralSettingsManger
{
    public class SettingsManger : ISettingsManger
    {
        private readonly IGeneralSettRepo _generalSettRepo;
        public SettingsManger(IGeneralSettRepo SettRepo)
        {
            _generalSettRepo = SettRepo;
        }

        public void delete(string id)
        {
            _generalSettRepo.delete(id);
        }

        public List<GeneralSettings> GetAllSettings()
        {
            return _generalSettRepo.GetAllSettings();
        }

        public GeneralSettings GetSettingById(string id)
        {
            return _generalSettRepo.GetSettingsById(id);
        }

        public void Insert(GeneralSettings generalSettings)
        {
            _generalSettRepo.Insert(generalSettings);
        }
        public void update(GeneralSettings generalSettings)
        {
            _generalSettRepo.update(generalSettings);
        }
    }
}
