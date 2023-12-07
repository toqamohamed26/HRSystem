using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repository.GeneralSettingsRepo
{
    public interface IGeneralSettRepo
    {
        void Insert(GeneralSettings generalSettings);
        void update(GeneralSettings generalSettings);
        GeneralSettings GetSettingsById(string id);
        void delete(string id);
        void Save();
        List<GeneralSettings> GetAllSettings();


    }
}
