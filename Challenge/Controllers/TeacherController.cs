using Challenge.Filters;
using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Challenge.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        [AuthorizeUser(idOperacion:1)]
        public ActionResult Index()
        {
            challengeContext db = new challengeContext();
            
            return View(db.Teachers.ToList());
        }


        public ActionResult Create_Teacher()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Teacher(Teacher T)
        {

            if (!ModelState.IsValid)
                return View();
            try
            {
                using (challengeContext db = new challengeContext())
                {
                    db.Teachers.Add(T);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error when the Teacher is input", ex);
                return View();
            }
           
        }
        public ActionResult Edit_Teacher(int id)
        {
            using (var db = new challengeContext())
            {
                Teacher teach = db.Teachers.Where(a => a.DNI == id).FirstOrDefault();
                return View(teach);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Teacher(Teacher T)
        {
            try
            {
                using (var db = new challengeContext())
                {
                    Teacher teach = db.Teachers.Find(T.DNI);
                    teach.Name = T.Name;
                    teach.Surname = T.Surname;
                    teach.Status = T.Status;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error when the Teacher is input", ex);
                return View();

            }


        }

        public ActionResult Details_Teacher(int id)
        {
            using (var db = new challengeContext())
            {
                Teacher teach = db.Teachers.Where(a => a.DNI == id).FirstOrDefault();
                return View(teach);
            }
        }

        public ActionResult Delete_Teacher(int id)
        {
            using (var db = new challengeContext())
            {
                Teacher teach = db.Teachers.Where(a => a.DNI == id).FirstOrDefault();
                db.Teachers.Remove(teach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }

}