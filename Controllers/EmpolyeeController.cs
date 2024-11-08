using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADO.Net_Project.Models;
using ADO.Net_Project.Repository;

namespace ADO.Net_Project.Controllers
{
    public class EmpolyeeController : Controller
    {
       EmpRepository repo = new EmpRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult save(EmpoyeeModel model)
        {
            if (model != null)
            {
                bool result = repo.AddEmployee(model);
                TempData["msg"] = "Save Data Successfully...!";
                return RedirectToAction("Index");
            }
            else
            {
				TempData["msg"] = "Save Data Empty...!";
				return RedirectToAction("Index");
			}
        }
    }
}