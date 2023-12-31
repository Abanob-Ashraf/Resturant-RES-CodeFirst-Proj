﻿namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class Customer
    {
        public Customer()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
            Testimonials = new HashSet<Testimonial>();
            Reservations = new HashSet<Reservation>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; } 
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string? CustomerPassword { get; set; }
        public string CustomerPhone { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
