using HRSystem.DAL.Data.Models;
namespace HRSystem.BL.Mangers.DepartmentManger
{
    public interface IDeptManger
    {
        void Insert(Department department);
        List<Department> GetDepartments();
        Department GetDepartmentsById(string id);
        void update(Department department);

        void delete(string id);

    }
}
