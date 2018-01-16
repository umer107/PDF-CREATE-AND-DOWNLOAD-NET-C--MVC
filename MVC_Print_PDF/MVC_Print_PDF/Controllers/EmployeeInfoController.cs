using MVC_Print_PDF.Data;
using Rotativa.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_Print_PDF.Controllers
{
    public class EmployeeInfoController : Controller
    {
        private ApplicationDBEntities ctx = new ApplicationDBEntities();
        //
        // GET: /EmployeeInfo/
        public ActionResult Index()
        {
            var emps = ctx.EmployeeInfoes.First();
            return View(emps);
        }

        public ActionResult PrintAllReport()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }
        public ActionResult IndexById(int id)
        {
            var emp = ctx.EmployeeInfoes.Where(e => e.EmpNo == id).First();
            return View(emp);
        }
        public ActionResult PrintSalarySlip(int id)
        {
            var report = new ActionAsPdf("IndexById", new { id = id });
            return report;
        }
	}
}