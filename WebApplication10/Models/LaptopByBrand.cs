namespace WebApplication10.Models
{
    public class LaptopByBrand
    {
        public List<Brand> Brands;
        public int BrandId { get; set; }
        public bool OrderBy { get; set; }
        public bool AorD { get; set; }
        public bool MoreOrLess { get; set; }
        public int Price { get; set; }
        public bool HigherOrLower { get; set; }
        public int Year { get; set; }

        public List<Laptop> Results;


    }
}
