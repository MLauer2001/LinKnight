using Linknight.BL;
using Linknight.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linknight.UI.ViewModels;
using Linknight.UI.Extensions;

namespace Linknight.UI.Controllers
{
    public class LobbyController : Controller
    {
        public IActionResult Index()
        {
            return View(ProfileManager.Load());
        }
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
    }
}
