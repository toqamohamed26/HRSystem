namespace HRSystem.BL.DTO.RegisterDTO
{

    public record RegisterEmployeeDTO
  (
      string UserName,
      string Email,
      string Password,
      string Phone,
      string Address,
      string Gender ,
      string Nationality ,
      string NationalID ,
      double Salary ,
      DateTime HireDate ,
      TimeSpan? Attendance,
      TimeSpan? CheckOut,
      string Department 
      )
    {

    }
  
}
