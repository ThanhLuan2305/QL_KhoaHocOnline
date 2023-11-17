using QL_KhoaHocOnl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_KhoaHocOnl.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        QL_COURSEEntities db = new QL_COURSEEntities();
        public ActionResult Index()
        {
            List<COURSE> list = db.COURSE.ToList();
            return View(list);
        }
        public ActionResult Detail(string id)
        {
            COURSE course = db.COURSE.Where(c => c.ID_COURSE == id).FirstOrDefault();
            return View(course);
        }
    }
}