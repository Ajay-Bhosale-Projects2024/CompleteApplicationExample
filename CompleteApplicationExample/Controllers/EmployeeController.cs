using CompleteApplicationExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace CompleteApplicationExample.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        MVCDBContext db = new MVCDBContext();

        [AllowAnonymous]        
        public ActionResult Index()
        {
            List<Employee> Employees=db.Employees.ToList();
            return View(Employees);
        }

        public ViewResult AddEmployee()
        {
            
            
            return View();
        }

        

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult AddEmployee(Employee Emp,HttpPostedFileBase selectedFile)
        {
           
            if (selectedFile != null)
            {
                Emp.YearlyInc = (Emp.MonthlyInc * 12) - (Emp.MonthlyInc * Convert.ToDecimal(0.05));
                string pdfFile = Convert.ToString(selectedFile.FileName).ToLower();
                if(pdfFile.EndsWith(".pdf"))   //if(selectedFile.FileName.ToString().ToLower().EndsWith(".pdf"))              
                { 
                
                    string physicalPath = Server.MapPath("~/Upload/");
                    if(!Directory.Exists(physicalPath))
                    {
                        Directory.CreateDirectory(physicalPath);
                    }
                    selectedFile.SaveAs(physicalPath+selectedFile.FileName);
                    Emp.Attachment = selectedFile.FileName;
                }
                else
                {
                    ModelState.AddModelError("","Upload Only .pdf File");
                }
            }
            else
            {
                ModelState.AddModelError("", "Upload Attachment .pdf File");
            }
            
            
           
            if(ModelState.IsValid)
            {
                db.Employees.Add(Emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(Emp);
            }
            
        }
          //hello how are you

        public ViewResult View(int EmpId)
        {
            var record = db.Employees.Find(EmpId);
            return View(record);
        }

        public ViewResult Update(int EmpId)
        {
            var record = db.Employees.Find(EmpId);
            return View(record);
        }

        [HttpPost]
        public RedirectToRouteResult Update(Employee emp)
        {
        //    Employee oldValues = db.Employees.Single(S => S.EmpId ==
        //     emp.EmpId);

        //    oldValues.Name = emp.Name;
        //    oldValues.MonthlyInc = emp.MonthlyInc;
        //    oldValues.YearlyInc = emp.YearlyInc;
        //    oldValues.Email = emp.Email;
        //    oldValues.Mobile = emp.Mobile;
        //    oldValues.Address = emp.Address;

            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index","Employee");

        }

        public RedirectToRouteResult Delete(int EmpId)
        {
            var record = db.Employees.Find(EmpId);
            db.Entry(record).State = EntityState.Deleted;    
            db.SaveChanges();

            return RedirectToAction("Index","Employee");
        }


    }
}