using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Geron.Models;

namespace Geron.Controllers
{
    public class HomeController : Controller
    {
        TriangleContext db;
        public HomeController(TriangleContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CalculationList()
        {
            return View(db.Triangles.ToList().OrderByDescending(x => x.Date));
        }

        [HttpPost]
        public IActionResult Index(Triangle triangle)
        {
            // return triangle.a.ToString() + ' ' + triangle.b.ToString() + ' ' + triangle.c.ToString() + ' ';
            // check does triangle exists
            if (triangle.a + triangle.b > triangle.c && triangle.a + triangle.c > triangle.b && triangle.b + triangle.c > triangle.a)
            {
                triangle.Date = DateTime.Now;
                double p = (triangle.a + triangle.b + triangle.c) / 2;
                double S = Math.Sqrt(p * (p - triangle.a) * (p - triangle.b) * (p - triangle.c));
                triangle.S = "S = " + S.ToString();
                db.Triangles.Add(triangle);
                db.SaveChanges();
                ViewBag.S = triangle.S;
            }
            else
            {
                ViewBag.S = "This triangle doesn't exists";
            }

            return View();
        }
    }
}
