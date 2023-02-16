namespace WebApplication10.Models
{
    public class Laptop
    {
        public int id { get; set; }
        public string Model { get; set; }
        public Brand Brand { get; set; }
        public int brand { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }

        public Laptop(int id, string model, Brand brand, int price, int year)
        {
            this.id = id;
            Model = model;
            Brand = brand;
            Price = price;
            Year = year;
        }
        public Laptop()
        {

        }



    }
}
