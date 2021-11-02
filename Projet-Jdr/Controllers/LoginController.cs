using Projet_Jdr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Jdr.Controllers
{
    public class LoginController : Controller
    {
        private MyContext context = new MyContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckLogin(Utilisateur user)
        {
            string msgErreur = "Echec authentification";
            if (ModelState.IsValid)
            {
                Utilisateur userDB = context.Utilisateurs.SingleOrDefault(u => u.Email.Equals(user.Email));
                if (userDB != null)
                {
                    if (userDB.Password.Equals(user.Password))
                    {
                        if (userDB.Admin)
                        {
                            Session["Admin"] = userDB.Admin; //enregistrement de userdb.admin dans la session
                        }
                        Session["user_id"] = userDB.Id;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = msgErreur;
                    }
                }
                else
                {
                    ViewBag.Error = msgErreur;
                }
            }
            else
            {
                ViewBag.Error = msgErreur;
            }

            return View("Index", user);
        }

        public ActionResult Logout()
        {
            Session.Remove("user_id");
            Session.Remove("Admin");
            return View("Index");
        }

        public ActionResult Authorisation()
        {
            return View();
        }
    }
}