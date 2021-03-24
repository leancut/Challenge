using Challenge.Filters;
using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Challenge.Controllers
{
    public class InscriptionsController : Controller
    {
        // GET: Inscriptions
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Index_Inscriptions()
        {

            challengeContext db = new challengeContext();

            return View(db.Subjects.ToList());

        }

        public ActionResult Details_InsSubject(int id)
        {
            using (var db = new challengeContext())
            {
                Subject subj = db.Subjects.Where(a => a.Id_Subject == id).FirstOrDefault();
                var teach = subj.DNI_Teacher;
                var tea = db.Teachers.Where(b => b.DNI == teach).Select(t => t.Surname).FirstOrDefault();
                var tea0 = db.Teachers.Where(b => b.DNI == teach).Select(t => t.Name).FirstOrDefault();
                ViewBag.Teache = tea0 + " "+tea;
                return View(subj);
            }
        }
        public ActionResult Create_Inscription(int id)
        {
            var oser = (User)Session["User"];
            var Inscription = new Inscription();
            Inscription.Id_User = oser.Id_User;
            Inscription.Id_Subject = id;
            Inscription.Inscription_Date = DateTime.Now;

            return View(Inscription);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Inscription(Inscription I)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (challengeContext db = new challengeContext())
                {
                    db.Inscriptions.Add(I);
                    var id = I.Id_Subject;
                    Subject sub = db.Subjects.Where(a => a.Id_Subject == id).FirstOrDefault();
                    sub.Quota = sub.Quota-1;
                    db.SaveChanges();
                    return RedirectToAction("Index_Inscriptions");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error when the Teacher is input", ex);
                return View();
            }

        }
    }
}