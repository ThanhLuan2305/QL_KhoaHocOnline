using QL_KhoaHocOnl.Models;
using QL_KhoaHocOnl.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_KhoaHocOnl.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        QL_COURSEEntities db = new QL_COURSEEntities();
       
        public ActionResult Login()
        {
            // db.Products.Add(p);
            // db.SaveChanges();
            return View();
        }
        public ActionResult Register()
        {
            // db.Products.Add(p);
            // db.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM rgt)
        {
            if (db.USER_COURSE.Where(x => x.ROLE_USER == "Admin") == null)
            {
                USER_COURSE u = new USER_COURSE();
                u.ROLE_USER = "Admin";
                u.USERNAME = "admin";
                u.PASSWORD = "admin123";
                u.EMAIL_USER = "admin@gmail.com";
                db.USER_COURSE.Add(u);
                db.SaveChanges();
            }
            if (db.USER_COURSE.Where(x => x.ROLE_USER == "Manager") == null)
            {
                USER_COURSE u = new USER_COURSE();
                u.ROLE_USER = "Manager";
                u.USERNAME = "manager";
                u.PASSWORD = "manager123";
                u.EMAIL_USER = "manager@gmail.com";
                db.USER_COURSE.Add(u);
                db.SaveChanges();
            }
            if (ModelState.IsValid)
            {
                USER_COURSE user = new USER_COURSE();
                user.ROLE_USER = "Student";
                user.USERNAME = rgt.Username;
                user.PASSWORD = mahoa(rgt.Password);
                user.EMAIL_USER = rgt.Email;
                db.USER_COURSE.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(LoginVM lg)
        {
            string role = db.USER_COURSE.Where(x => x.USERNAME == lg.Username).Select(x => x.ROLE_USER).ToString();
            if (ModelState.IsValid)
            {
               if (role == "Admin")
                {
                    if (db.USER_COURSE.Where(x => x.USERNAME == lg.Username).Where(x => x.PASSWORD == lg.Password).FirstOrDefault() == null)
                    {
                        return View();
                    }
                    else
                        return RedirectToAction("Index", "Home");
                }
               else
                {
                    string HashPass = mahoa(lg.Password);
                    if (db.USER_COURSE.Where(x => x.USERNAME == lg.Username).Where(x => x.PASSWORD == HashPass).FirstOrDefault() == null)
                    {
                        return View();
                    }
                    else
                        return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }
        public string mahoa(string pass)
        {
            string HashPass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "SHA1");
            return HashPass;
        }
    }
}