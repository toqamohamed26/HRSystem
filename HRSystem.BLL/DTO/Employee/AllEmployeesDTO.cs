using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.BL.DTO.Employee
{
    public class AllEmployeesDTO
    {
            public string Id { get; set; }
            public string email { get; set; }

            public string UserName { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Gender { get; set; }
            public string Nationality { get; set; }
            public string NationalID { get; set; }
            public DateTime BirthDate { get; set; }
            public double Salary { get; set; }
            public DateTime HireDate { get; set; }
            public TimeSpan? Attendance { get; set; }
            public TimeSpan? CheckOut { get; set; }           
            public string Department { get; set; }
            

    }
}
