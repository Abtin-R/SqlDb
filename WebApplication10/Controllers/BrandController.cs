using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class BrandController : Controller
    {
        public DataBase db = DataBase.GetInstance();


        public IActionResult Index()
        {

            return View();
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
            if (l.OrderBy)
            {
                if (l.AorD)
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
                if (l.AorD)
                {
                    l.Results = l.Results.OrderBy(la => la.Price).ToList();
                }
                else
                {
                    l.Results = l.Results.OrderByDescending(la => la.Price).ToList();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}