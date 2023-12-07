using HRSystem.BL.DTO.Employee;
using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.EmpManger
{
    public interface IEmpManger
    {
        IEnumerable<AllEmployeesDTO> GetAllEmp();
        Employee GetEmployeeById(string id);
       Task update(Employee employee);
       Task delete(string id);
        List<AllEmployeesDTO> GetEmpByDeptID(string deptId);
    }
}
