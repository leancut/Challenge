using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Challenge.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            try
            {
                using (challengeContext db = new challengeContext())
                {
                    var oUser = (from d in db.Users
                                 where d.Email_User == User.Trim() && d.Pass == Pass.Trim()
                                 select d).FirstOrDefault();
                    if(oUser == null)
                    {
                        ViewBag.Error = "User or pass incorrects";
                        return View();
                    }
                    Session["User"]= oUser;

                }

                    return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }

        }
    }
}