namespace WebApplication10.Models
{
    public class Compare
    {
        public List<Laptop> laptops = new DataBase().Laptops;
        public int id1 { get; set; }
        public int id2 { get; set; }
        public bool isSame = false;

    }
}
