using HRSystem.DAL.Data.Models;

namespace  HRSystem.DAL.Repository.EmployeeRepo
{
    public interface IEmpRepo
    {
        List<Employee> GetAllEmp();
        Employee GetEmployeeById(string id);
        Employee GetbyId(string id);
        void update(Employee employee);
        void delete(string id);
        List<Employee> GetEmpByDeptID (string deptID);
        void Save();

    }
}
