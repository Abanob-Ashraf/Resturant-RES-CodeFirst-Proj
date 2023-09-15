namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class EmployeeAddress
    {
        public int EmployeeAddressId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int EmpId { get; set; }

        public virtual Employee? EmployeeIdNavigation { get; set; }
    }
}
