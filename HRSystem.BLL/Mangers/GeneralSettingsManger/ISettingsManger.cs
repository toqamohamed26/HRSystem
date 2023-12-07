using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.GeneralSettingsManger
{
    public interface ISettingsManger
    {
        List<GeneralSettings> GetAllSettings();
        void Insert(GeneralSettings generalSettings);
        GeneralSettings GetSettingById(string id);
        void update(GeneralSettings generalSettings);
        void delete(string id);
    }
}
