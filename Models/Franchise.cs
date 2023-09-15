namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class Franchise
    {
        public Franchise()
        {
            Employees = new HashSet<Employee>();
        }
        public int FranchiseId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int? ManagerId { get; set; }
        public Employee? ManagerIdNavigation { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
