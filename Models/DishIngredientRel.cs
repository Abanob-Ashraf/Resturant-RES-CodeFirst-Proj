namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class DishIngredientRel
    {
        public int DishIngredientRelId { get; set; }
        public int DishId { get; set; }
        public int IngredientId { get; set; }

        public virtual Dish? DishIdNavigation { get; set; }
        public virtual Ingredient? IngredientIdNavigation { get; set; }
    }
}
