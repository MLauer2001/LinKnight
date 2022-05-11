using Linknight.BL;
using Linknight.BL.Models;
using Linknight.UI.ViewModels;
using Linknight.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Linknight.UI.Controllers
{
    public class LobbyController : Controller
    {
        private static HttpClient InitializeClient()
        {
            HttpClient client = new ApiClient();
            return client;
        }

        // GET: LobbyController1
        public ActionResult Index()
        {
            HttpClient client = InitializeClient();

            HttpResponseMessage response;
            string result;
            dynamic items;

            response = client.GetAsync("Link").Result;
            result = response.Content.ReadAsStringAsync().Result;
            items = (JArray)JsonConvert.DeserializeObject(result);
            List<Lobby> lobbies = items.ToObject<List<Lobby>>();

            return View(nameof(Index), lobbies);
        }


        // GET: LobbyController1/Details/5
        public ActionResult Details(Guid id)
        {
            HttpClient client = InitializeClient();
            HttpResponseMessage response = client.GetAsync("Link/" + id).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            Lobby lobby = JsonConvert.DeserializeObject<Lobby>(result);

            LobbyVm lobbyVm = new LobbyVm();
            string results = HttpContext.Session.GetString("user");
            User user = JsonConvert.DeserializeObject<User>(results);
            lobbyVm.User = user;
            lobbyVm.Lobby = lobby;

            return View("Lobby", lobbyVm);
        }

        // GET: LobbyController1/Create
        public ActionResult Create()
        {
            HttpClient client = InitializeClient();
            HttpResponseMessage response = client.GetAsync("Link/" + id).Result;
            return View();
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
