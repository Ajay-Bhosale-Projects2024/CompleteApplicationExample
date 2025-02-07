using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Security;
using CompleteApplicationExample.Models;
using System.Web.Security;

namespace CompleteApplicationExample.Controllers
{
    
    public class AccountController : Controller
    {
        MVCDBContext db = new MVCDBContext();


        public ActionResult Login()
        {
           ViewBag["User"]="loging is here";
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(Login user,string ReturnUrl)
        {
            var Isvalid = from i in db.Registrations where i.Email == user.Email && i.Password == user.Password select i;
            
            
                if (Isvalid.Count() > 0)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    Session["Name"] = user.Email;
                    if(ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(user);
                }
            
           
            
            
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Registration Register)
        {
            if(ModelState.IsValid)
            {
                db.Registrations.Add(Register);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(Register);
        }

        public RedirectToRouteResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
