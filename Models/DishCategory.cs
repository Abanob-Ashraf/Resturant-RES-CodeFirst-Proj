namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class DishCategory
    {
        public DishCategory()
        {
            Dishes = new HashSet<Dish>();
        }

        public int DishCategoryId { get; set; }
        public string DishCategoryName { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
