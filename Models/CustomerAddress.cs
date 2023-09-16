namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class CustomerAddress
    {
        public int CustomerAddressId { get; set; }
        public string? BuildingNum { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string? PostalCode { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer? CustomerIdNavigation { get; set; }
    }
}
