using HRSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace  HRSystem.DAL.Repository.DepartmentRepo
{
    public class DeptRepo : IDeptRepo
    {

        private readonly HREntity context;

        public DeptRepo(HREntity shippingContext)
        {
            context = shippingContext;
        }

        public List<Department> GetDepartments()
        {
            return context.Departments.Where(n => n.IsDeleted == false).ToList();
        }

        public Department GetDepartmentsById(string id)
        {
            return context.Departments.Where(s => s.Id == id).Include(e => e.Employees).FirstOrDefault();
        }

        public void Insert(Department department)
        {
            context.Departments.Add(department);
            Save();
        }
        public async Task delete(string id)
        {
            var department = context.Departments.FirstOrDefault(e => e.Id == id);
            department.IsDeleted = true;
            update(department);

        }
        public void update(Department department)
        {

            context.Entry(department).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

      

    }
}
