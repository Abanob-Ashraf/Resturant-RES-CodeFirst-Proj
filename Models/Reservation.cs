namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string? Note { get; set; }
        public int NoOfGuests { get; set; }
        public DateTime ReservarionDate { get; set; }
        public int CustomerId { get; set; }
        public int FranchiseId { get; set; }

        public virtual Customer? CustomerIdNavigation { get; set; }
        public virtual Franchise? FranchiseIdNavigation { get; set; }
    }
}
