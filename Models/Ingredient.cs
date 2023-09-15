namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            DishIngredientRels = new HashSet<DishIngredientRel>();
        }

        public int IngredientId { get; set; }
        public string IngredientName { get; set; }

        public virtual ICollection<DishIngredientRel> DishIngredientRels { get; set; }
    }
}
