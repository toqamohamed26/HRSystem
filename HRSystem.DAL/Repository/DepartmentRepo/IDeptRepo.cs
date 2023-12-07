using HRSystem.DAL.Data.Models;
using System.Diagnostics;

namespace HRSystem.DAL.Repository.DepartmentRepo
{
    public interface IDeptRepo
    {
        void Insert(Department department);
        void Save();
        List<Department> GetDepartments();
        Department GetDepartmentsById(string id);

        void update(Department department );

        Task delete(string id);

    }
}
