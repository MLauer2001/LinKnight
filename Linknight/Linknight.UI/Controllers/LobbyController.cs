using Linknight.BL;
using Linknight.BL.Models;
using Linknight.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linknight.UI.Controllers
{
    public class LobbyController : Controller
    {
        // GET: LobbyController1
        //[Route("~/Lobby/{username}")]
        public ActionResult Index()
        {
            LobbyVm lobbyVm = new LobbyVm();
            string result = HttpContext.Session.GetString("user");
            User user = JsonConvert.DeserializeObject<User>(result);
            lobbyVm.User = user;

            return View(lobbyVm);
        }


        // GET: LobbyController1/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: LobbyController1/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Profile";
            ProfileViewModel profileVM = new ProfileViewModel();
            profileVM.Profile = new Profile();
            profileVM.Lobbys = LobbyManager.Load();
            profileVM.Colors = ColorManager.Load();
            profileVM.Armors = ArmorManager.Load();
            profileVM.Helms = HelmManager.Load();
            return View(profileVM);
        }

        // POST: LobbyController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfileViewModel profileVM)
        {
            try
            {
                int results = ProfileManager.Insert(profileVM.Profile);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(profileVM);
            }
        }

        // GET: LobbyController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LobbyController1/Delete/5
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
