namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class PaymentMethod
    {
        public PaymentMethod()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set;}

        public virtual ICollection<Order> Orders { get; set; }
    }
}
