using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.DTO.GeneralSettings
{
    public class UpdateSettingsDTO
    {
        public string Id { get; set; }
        public int Add_hours { get; set; }
        public int sub_hours { get; set; }
        public string vacation1 { get; set; }
        public string vacation2 { get; set; }
    }
}
