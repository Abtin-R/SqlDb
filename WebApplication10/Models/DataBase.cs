using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebApplication10.Models
{
    public class DataBase
    {
        public static DataBase db { get; } = new DataBase();
        public List<Laptop> Laptops { get; set; }
        public List<Brand> Brands { get; set; }

        public DataBase()
        {
            Brand b1 = new Brand(1, "Lenova");
            Brand b2 = new Brand(2, "Acer");
            Brand b3 = new Brand(3, "Asus");

            Laptop l1 = new Laptop(1, "Legion", b1, 1359, 2019);
            Laptop l2 = new Laptop(2, "Swift 3", b2, 999, 2018);
            Laptop l3 = new Laptop(3, "Nitro 5", b2, 1099, 2020);
            Laptop l4 = new Laptop(4, "Rog Srtix", b3, 1599, 2021);
            Laptop l5 = new Laptop(5, "Tuf", b3, 849, 2022);


            List<Laptop> laptops = new List<Laptop> { l1, l2, l3, l4, l5 };
            List<Brand> brands = new List<Brand> { b1, b2, b3 };
            Laptops = laptops;
            Brands = brands;

        }

        public static DataBase GetInstance()
        {
            return db;
        }
    }
}
