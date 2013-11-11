using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CA1.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogIn(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect");
                }
            }
            return View(user);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registration(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MusicDBDataContext())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrpPass = crypto.Compute(user.Password);
                    
                     StoreUser u = new StoreUser()                     
                    {
                        Email_Address = user.Email,
                        Password = encrpPass,
                        PasswordSalt = crypto.Salt,
                        User_Id = Guid.NewGuid()
                    };

                     db.StoreUsers.InsertOnSubmit(u);
                        db.SubmitChanges();
                    

                        return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect!");
            }
            return View();
        }

        private bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var db = new MusicDBDataContext())
            {
                var user = db.StoreUsers.FirstOrDefault(u => u.Email_Address == email);

                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        IsValid = true;
                    }
                }
            }

            return IsValid;
        }

    }
}
