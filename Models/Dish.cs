namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class Dish
    {
        public Dish()
        {
            DishIngredientRels = new HashSet<DishIngredientRel>();
            OrderesDishesRels = new HashSet<OrderDishesRel>();
        }

        public int DishId { get; set; }
        public string DishName { get; set; }
        public double DishPrice { get; set; }
        public string DishImageName { get; set; }
        public int DishCategoryId { get; set; }
        public virtual DishCategory? DishCategoryIdNavigation { get; set; }

        public virtual ICollection<DishIngredientRel> DishIngredientRels { get; set; }
        public virtual ICollection<OrderDishesRel> OrderesDishesRels { get; set; }
    }
}
