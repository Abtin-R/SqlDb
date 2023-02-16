using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class LaptopController : Controller
    {
        public DataBase db = DataBase.GetInstance();


        public IActionResult Index()
        {

            return View();
        }
        public IActionResult MostExpensive()
        {
            List<Laptop> result = db.Laptops.OrderByDescending(l => l.Price).Take(2).ToList();
            return View(result);
        }

        public IActionResult Cheapest()
        {
            List<Laptop> result = db.Laptops.OrderBy(l => l.Price).Take(3).ToList();
            return View(result);
        }

        public IActionResult Budget()
        {
            return View(new Budget());
        }

        [HttpPost]
        public IActionResult Budget(Budget b)
        {
            b.result = db.Laptops.Where(l => l.Price <= b.range).ToList();
            return View(b);
        }
        public IActionResult Compare()
        {

            return View(new Compare());
        }
        [HttpPost]
        public IActionResult CompareRes(Compare c)
        {
            if (c.id2 == c.id1)
            {
                c.isSame = true;
            }
            c.laptops = c.laptops.Where(l => l.id == c.id1 || l.id == c.id2).ToList();
            return View(c);
        }
        public IActionResult LaptopsByBrand()
        {
            var v = new LaptopByBrand();
            v.Brands = db.Brands;
            return View(v);
        }
        [HttpPost]
        public IActionResult LaptopsByBrandRes(LaptopByBrand l)
        {
            l.Results = db.Laptops.Where(la => la.Brand.Id == l.BrandId).ToList();

            if (l.MoreOrLess == true)
            {
                l.Results = l.Results.Where(la => la.Price < l.Price).ToList();
            }
            else
            {
                l.Results = l.Results.Where(la => la.Price > l.Price).ToList();
            }

            if (l.HigherOrLower == true)
            {
                l.Results = l.Results.Where(la => la.Year > l.Year).ToList();
            }
            else
            {
                l.Results = l.Results.Where(la => la.Year < l.Year).ToList();
            }


            if (l.OrderBy)
            {
                if (!l.AorD)
                {
                    l.Results = l.Results.OrderByDescending(la => la.Year).ToList();
                }
                else
                {
                    l.Results = l.Results.OrderBy(la => la.Year).ToList();
                }
            }
            else
            {
                if (!l.AorD)
                {
                    l.Results = l.Results.OrderByDescending(la => la.Price).ToList();
                }
                else
                {
                    l.Results = l.Results.OrderBy(la => la.Price).ToList();
                }
            }
            return View(l);
        }
        public IActionResult AllBrands()
        {
            IEnumerable<IGrouping<string, Laptop>> brandsAndLaptops = db.Laptops.GroupBy(l => l.Brand.Name);
            return View(brandsAndLaptops);
        }

        public IActionResult AddBrand()
        {

            return View(new Brand());
        }
        [HttpPost]
        public IActionResult AddBrand(Brand b)
        {
            b.Id = db.Brands.OrderByDescending(b => b.Id).Count() + 1;
            db.Brands.Add(b);

            return View(b);
        }
        public IActionResult AddLaptop()
        {

            return View(new Laptop());
        }
        [HttpPost]
        public IActionResult AddLaptop(Laptop l)
        {
            l.id = db.Laptops.OrderByDescending(l => l.id).Count() + 1;
            l.Brand = db.Brands.First(b => b.Id == l.brand);
            db.Laptops.Add(l);
            return View(l);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}