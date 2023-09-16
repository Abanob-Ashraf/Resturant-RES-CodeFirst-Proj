namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string TestimonialText { get; set; }
        public bool ShownInWebsite { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? CustomerIdNavigation { get; set; }
    }
}
