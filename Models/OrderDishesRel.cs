namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class OrderDishesRel
    {
        public int OrderDishesRelId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }

        public virtual Order? OrderIdNavigation { get; set; }
        public virtual Dish? DishIdNavigation { get; set; }
    }
}
