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

        public ActionResult Details_Subject(int id)
        {
            using (var db = new challengeContext())
            {
                return View();
            }
        }
        public ActionResult Create_Inscription(Subject s)
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Inscription(Inscription I)
        {
            return View();
        }
    }
}