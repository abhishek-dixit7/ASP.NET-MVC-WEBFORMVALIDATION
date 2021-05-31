using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormswithDB.Models;

namespace FormswithDB.Controllers
{
    public class HomeController : Controller
    {
        

        
        // GET: Home
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeDataPrimary emp)
        {
            if (ModelState.IsValid)
            {
                if (Add(emp) > 0)
                {
                    ModelState.Clear();
                    ViewBag.isSuccess = "Data Added";
                }   
            }
            return View();
        }

        private int Add(EmployeeDataPrimary emp)
        {
            using (var context = new EmployeeDBEntities())
            {
                EmployeeData temp = new EmployeeData()
                {
                    firstName = emp.firstName,
                    lastName = emp.lastName
                };

                context.EmployeeData.Add(temp);

                context.SaveChanges();

                return temp.id;

            }

        }
    }
}