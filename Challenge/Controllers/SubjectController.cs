using Challenge.Filters;
using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Challenge.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        [AuthorizeUser(idOperacion: 2)]
        public ActionResult Index_Subject()
        {

            challengeContext db = new challengeContext();

            return View(db.Subjects.ToList());

        }

        public ActionResult Create_Subject()
        {
            List<Models.Teacher_List> lst = null;
            using (Models.challengeContext db= new challengeContext())
            {
                lst=
                    (from d in db.Teachers
                     select new Teacher_List
                     {
                         dNI=d.DNI,
                         name=d.Name + " "+d.Surname
                     }).ToList();
            }

            List<SelectListItem> ites = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.name.ToString(),
                    Value = d.dNI.ToString(),
                    Selected = false

                };
            });

            ViewBag.ites = ites;
                return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Subject(Subject s)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (challengeContext db = new challengeContext())
                {
                    db.Subjects.Add(s);
                    db.SaveChanges();
                    return RedirectToAction("Index_Subject");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error when the Teacher is input", ex);
                return View();
            }

        }

        public ActionResult List_Teacher()
        {
            using (var db= new challengeContext())
            {
                return PartialView(db.Teachers.ToList());
            }
        }
        public ActionResult Edit_Subject(int id)
        {
         
            using (var db = new challengeContext())
            {
                Subject sub = db.Subjects.Where(a => a.Id_Subject == id).FirstOrDefault();
                return View(sub);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Subject(Subject s)
        {
            if (!ModelState.IsValid)
                return View();


            try
            {
                using (var db = new challengeContext())
                {
                    
                    Subject subj = db.Subjects.Find(s.Id_Subject);
                    subj.Name_Subject = s.Name_Subject;
                    subj.DNI_Teacher = s.DNI_Teacher;
                    subj.Schedule_From = s.Schedule_From;
                    subj.Schedule_To = s.Schedule_To;
                    subj.Quota = s.Quota;
                    db.SaveChanges();
                    return RedirectToAction("Index_Subject");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error when the Subject is input", ex);
                return View();

            }


        }

        public ActionResult Details_Subject(int id)
        {
            using (var db = new challengeContext())
            {
                Subject sub = db.Subjects.Where(a => a.Id_Subject == id).FirstOrDefault();
                var teach = sub.DNI_Teacher;
                var tea = db.Teachers.Where(b => b.DNI == teach).Select(t => t.Surname).FirstOrDefault();
                var tea0 = db.Teachers.Where(b => b.DNI == teach).Select(t => t.Name).FirstOrDefault();
                ViewBag.Teache = tea0 + " " + tea;
                return View(sub);
            }
        }

        public ActionResult Delete_Subject(int id)
        {
            using (var db = new challengeContext())
            {
                Subject sub = db.Subjects.Where(a => a.Id_Subject == id).FirstOrDefault();
                db.Subjects.Remove(sub);
                db.SaveChanges();
                return RedirectToAction("Index_Subject");
            }
        }


    }
}