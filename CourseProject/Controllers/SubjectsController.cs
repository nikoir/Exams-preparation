using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProject.Models;

namespace CourseProject.Controllers
{
    public class SubjectsController : Controller
    {
        // GET: Subjects
        public ActionResult Index(System.Guid? Id)
        {
            using (Entities db = new Entities())
            {
                if (Id != null)
                {
                    Предметы subject = db.Предметы.Where(sb => sb.ID_предмета == Id).FirstOrDefault();
                    return View("Subject", subject);
                }
                else
                    return View(db.Предметы.ToList());
            }
        }
    }
}