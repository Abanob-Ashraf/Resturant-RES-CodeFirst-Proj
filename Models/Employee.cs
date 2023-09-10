using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpEmail { get; set; }
        public string? EmpPassword { get; set; }
        public string EmpPhone { get; set; }
        public string EmpNationalId { get; set; }
        public DateTime EmpHirigDate { get; set; }
        public double EmpSalary { get; set; }
    }
}
