namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class CustomerAddress
    {
        public int CustAddressId { get; set; }

        public string? CustAddressBuildingNumber { get; set; }

        public string CustAddressStreet { get; set; }

        public string CustAddressCity { get; set; }

        public string CustAddressCountry { get; set; }

        public string? CustAddressPostalCode { get; set; }

    }
}
