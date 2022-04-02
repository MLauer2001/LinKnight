using Linknight.BL;
using Linknight.BL.Models;
using Linknight.UI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linknight.UI.Views
{
    public class AdminController : Controller
    {
        public IActionResult Login(string returnUrl)
        {
            TempData["returnurl"] = returnUrl;
            return View();
        }

        public IActionResult Logout()
        {
            SetUser(null);
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            try
            {
                if (AdminManager.Login(admin))
                {
                    SetUser(admin);
                    if (TempData["returnurl"] != null)
                        return Redirect(TempData["returnurl"].ToString());
                    else
                    {
                        ViewBag.Message = "You are now logged in.";
                    }
                }
                return View("~/Views/Admin/Index.cshtml");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(admin);
            }
        }
        

        private void SetUser(Admin admin)
        {
            HttpContext.Session.SetObject("admin", admin);
            if (admin != null)
            {
                HttpContext.Session.SetObject("fullname", "Welcome " + admin.FullName);
            }
            else
            {
                HttpContext.Session.SetObject("fullname", "");
            }
        }

        // GET: AdminController
        public ActionResult Index()
        {
            return View(AdminManager.Load());
        }

        // GET: AdminController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(AdminManager.LoadById(id));
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
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
