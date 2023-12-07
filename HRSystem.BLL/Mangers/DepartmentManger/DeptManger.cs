using HRSystem.DAL.Data.Models;
using HRSystem.DAL.Repository.DepartmentRepo;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.BL.Mangers.DepartmentManger
{
    public class DeptManger : IDeptManger
    {
        private readonly IDeptRepo _deptRepo;
        public DeptManger(IDeptRepo deptRepo)
        {
            _deptRepo = deptRepo;
        }
        public Department GetDepartmentsById(string id)
        {
            return _deptRepo.GetDepartmentsById(id);
        }

        public List<Department> GetDepartments()
        {
            return _deptRepo.GetDepartments();
        }

        public void Insert(Department department)
        {
            _deptRepo.Insert(department);
        }

        public void update(Department department )
        {

            _deptRepo.update(department);
        }
     

        public void delete(string id)
        {
            _deptRepo.delete(id);
        }
    }
}
