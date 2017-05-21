using Starcounter;

namespace Yuri.Models
{
    [Database]
    public class FranchiseOffice
    {
        public string Name;
        public Corporation Corporation;

        public string Street;
        public string Number;
        public string Zip;
        public string City;
        public string Country;

        public int HousesSold => 0;
        public decimal TotalCommision => 0;
        public decimal AvgCommision => 0;
        public decimal Trend => 0;
    }
}
