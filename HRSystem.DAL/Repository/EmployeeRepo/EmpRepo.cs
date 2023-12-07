using HRSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace  HRSystem.DAL.Repository.EmployeeRepo
{
    public class EmpRepo : IEmpRepo
    {
        HREntity context;
        public EmpRepo(HREntity context)
        {
            this.context = context;

        }
        public List<Employee> GetAllEmp()
        {
            var res = context.Employees.Where(e => e.IsDeleted == false).Include(e => e.Department).ToList();
            return res;
        }

        public void delete(string id)
        {
            var employee = context.Employees.FirstOrDefault(e => e.Id == id);
            employee.IsDeleted = true;
            update(employee);

        }
        public void update(Employee employee)
        {

            context.Entry(employee).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public Employee GetEmployeeById(string id)
        {
            return context.Employees.Where(s => s.Id == id).Include(e => e.Department).FirstOrDefault();
        }

        public Employee GetbyId(string id)
        {
            var Employee = context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id && e.IsDeleted != true);
            return (Employee);
        }

        public List<Employee> GetEmpByDeptID(string deptID)
        {
            return context.Employees.Where(e => e.DeptID == deptID && e.IsDeleted != true).ToList();
        }
    }
}
