using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_generalProjectExperiment.Models;
namespace Web_generalProjectExperiment.Controllers
{
    public class HomeController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GuncelleSayfasi(int id) {

           var data= db.Employees.FirstOrDefault(x => x.EmployeeID == id);

            return View(data);


        }

        [HttpPost]
        public string DataGet()
        {


            return "String donuyor";
        }
       //public IQueryable<Employees> DataGet()
       // {


       //     return db.Employees.Where(x => x.EmployeeID > 0).Take(1); 

       // }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}