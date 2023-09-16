namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class Order
    {
        public Order()
        {
            OrderDishesRels = new HashSet<OrderDishesRel>();
        }

        public int OrderId { get; set; }
        public string OrderSerialNum { get; set; }
        public bool IsPaid { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderTypeId { get; set; }
        public int OrderStateId { get; set; }
        public int PaymentMethodId { get; set; }
        public int CustomerId { get; set; }
        public int FranchiseId { get; set; }

        public virtual OrderType OrderTypeIdNavigation { get; set; }
        public virtual OrderState OrderStateIdNavigation { get; set; }
        public virtual PaymentMethod PaymentMethodIdNavigation { get; set; }
        public virtual Customer CustomerIdNavigation { get; set; }
        public virtual Franchise FranchiseIdNavigation { get; set; }

        public virtual ICollection<OrderDishesRel> OrderDishesRels { get; set; }
    }
}
