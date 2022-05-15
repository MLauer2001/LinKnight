using Linknight.BL;
using Linknight.BL.Models;
using Linknight.UI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linknight.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login(string returnUrl)
        {
            TempData["returnurl"] = returnUrl;
            return View();
        }

        public IActionResult Logout()
        {
            SetUser(null);
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                if (UserManager.Login(user))
                {
                    SetUser(user);
                    if (TempData["returnurl"] != null)
                        return Redirect(TempData["returnurl"].ToString());
                    else
                    {
                        ViewBag.Message = "You are now logged in.";
                    }
                }
                return View("~/Views/Home/Index.cshtml");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);
            }
        }


        private void SetUser(User user)
        {
            HttpContext.Session.SetObject("user", user);
            if (user != null)
            {
                HttpContext.Session.SetObject("username", "Welcome " + user.Username);
            }
            else
            {
                HttpContext.Session.SetObject("username", "");
            }
        }

        public ActionResult Profile(Guid id)
        {
            return View(UserManager.LoadById(id));
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(UserManager.Load());
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(UserManager.LoadById(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                int results = UserManager.Insert(user);
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(Guid id)
        {
            string results = HttpContext.Session.GetString("user");
            User user = JsonConvert.DeserializeObject<User>(results);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, User user)
        {
            try
            {
                Task<int> results = UserManager.Update(user);
                SetUser(user);
                return View("~/Views/Home/Index.cshtml");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
