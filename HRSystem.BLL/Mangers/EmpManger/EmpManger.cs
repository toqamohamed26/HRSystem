using HRSystem.BL.DTO.Employee;
using HRSystem.DAL.Data.Models;
using HRSystem.DAL.Repository.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.EmpManger
{
    public class EmpManger : IEmpManger
    {
        private readonly IEmpRepo _empRepo;
        public EmpManger(IEmpRepo empRepo)
        {
            _empRepo = empRepo;
        }

        public async Task delete(string id)
        {
            _empRepo.delete(id);
        }

        public IEnumerable<AllEmployeesDTO> GetAllEmp()
        {
            IEnumerable<Employee> empFromDB = _empRepo.GetAllEmp();
            return empFromDB.Select(emp => new AllEmployeesDTO
            {
                Id = emp.Id,
                UserName = emp.UserName,
                Phone = emp.PhoneNumber,
                email = emp.Email,
                Address = emp.Address,
                Department = emp.Department.Name,
                Attendance = emp.Attendance,
                Nationality = emp.Nationality,
                Gender = emp.Gender,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                NationalID = emp.NationalID,
                CheckOut = emp.CheckOut,
            });
        }

        public Employee GetEmployeeById(string id)
        {
            return _empRepo.GetEmployeeById(id);
        }

        public async Task update(Employee employee)
        {
            _empRepo.update(employee);
        }

        public List<AllEmployeesDTO> GetEmpByDeptID(string deptId)
        {
            var Employee = _empRepo.GetEmpByDeptID(deptId);
            var EMPDto = Employee.Select(emp => new AllEmployeesDTO
            {
                Id = emp.Id,
                UserName = emp.UserName,
                Phone = emp.PhoneNumber,
                email = emp.Email,
                Address = emp.Address,
                Department = emp.DeptID,
                Attendance = emp.Attendance,
                Nationality = emp.Nationality,
                Gender = emp.Gender,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                NationalID = emp.NationalID,
                CheckOut = emp.CheckOut,
            }).ToList();
            return (EMPDto);

        }
    }
}
