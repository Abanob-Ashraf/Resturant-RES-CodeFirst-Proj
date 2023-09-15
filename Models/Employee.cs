using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeeAddresses = new HashSet<EmployeeAddress>();
            Franchises = new HashSet<Franchise>();
        }

        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpEmail { get; set; }
        public string? EmpPassword { get; set; }
        public string EmpPhone { get; set; }
        public string EmpNationalId { get; set; }
        public DateTime EmpHirigDate { get; set; }
        public double EmpSalary { get; set; }
        public int EmpCategoryId { get; set; }
        public int FranchiseId { get; set; }

        public virtual EmployeeCategory? EmpCategoryIdNavigation { get; set; }
        public virtual Franchise? FranchiseIdNavigation { get; set; }

        public ICollection<Franchise> Franchises { get; set; }
        public virtual ICollection<EmployeeAddress> EmployeeAddresses { get; set; }
    }
}
