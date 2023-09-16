namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class OrderState
    {
        public OrderState()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStateId { get; set; }
        public string OrderStateName { get; set;}

        public virtual ICollection<Order> Orders { get; set;}
    }
}
