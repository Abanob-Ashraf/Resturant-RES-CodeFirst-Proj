namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class EmployeeCategory
    {
        public EmployeeCategory()
        {
            Employees = new HashSet<Employee>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
