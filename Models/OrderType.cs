namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class OrderType
    {
        public OrderType()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderTypeId { get; set; }
        public string OrderTypeName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
