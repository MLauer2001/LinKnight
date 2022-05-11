using Linknight.BL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Linknight.API.Test
{
    [TestClass]
    public class utLink
    {
        public HttpClient client { get; }

        public utLink()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>();

            var testServer = new TestServer(webHostBuilder);

            client = testServer.CreateClient();
        }

        [TestMethod]
        public void GetTest()
        {
            HttpResponseMessage response;
            string result;
            dynamic items;

            // Call the api
            response = client.GetAsync("Link").Result;
            result = response.Content.ReadAsStringAsync().Result;
            items = (JArray)JsonConvert.DeserializeObject(result);
            List<Lobby> lobbies = items.ToObject<List<Lobby>>();

            Assert.IsTrue(lobbies.Count > 0);
        }

        [TestMethod]
        public void GetIdTest()
        {
            HttpResponseMessage response;
            string result;
            dynamic items;

            response = client.GetAsync("Link").Result;
            result = response.Content.ReadAsStringAsync().Result;
            items = (JArray)JsonConvert.DeserializeObject(result);
            List<Lobby> lobbies = items.ToObject<List<Lobby>>();
            Lobby lobby = lobbies[0];

            Guid guid = lobby.Id;
            response = client.GetAsync("Link/" + guid).Result;

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void PostTest()
        {
            Lobby lobby = new Lobby
            {
                Id = Guid.NewGuid(),
                LobbyKey = "123456"
            };

            bool rollback = true;

            string serialziedResponse = JsonConvert.SerializeObject(lobby);
            var content = new StringContent(serialziedResponse);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync("Link/" + rollback, content).Result;
            string result = response.Content.ReadAsStringAsync().Result;

            result = result.Replace("\"", "");

            Guid guid = Guid.Parse(result);
            Assert.IsFalse(guid.Equals(Guid.Empty));
        }

        [TestMethod]
        public void PutTest()
        {
            // Get Id
            HttpResponseMessage responseA;
            string resultA;
            dynamic itemsA;

            responseA = client.GetAsync("Link").Result;
            resultA = responseA.Content.ReadAsStringAsync().Result;
            itemsA = (JArray)JsonConvert.DeserializeObject(resultA);
            List<Lobby> lobbies = itemsA.ToObject<List<Lobby>>();
            Lobby guid = lobbies[0];

            Lobby lobby = new Lobby
            {
                Id = guid.Id,
                LobbyKey = "Tester"
            };

            bool rollback = true;

            string serialziedQuestion = JsonConvert.SerializeObject(lobby);
            var content = new StringContent(serialziedQuestion);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PutAsync("Link/" + guid.Id + "/" + rollback, content).Result;
            string result = response.Content.ReadAsStringAsync().Result;

            result = result.Replace("\"", "");

            Assert.IsTrue(result == "1");
        }
    }
}
