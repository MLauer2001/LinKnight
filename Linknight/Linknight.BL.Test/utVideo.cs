using Linknight.BL;
using Linknight.BL.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL.Test
{
    [TestClass]
    public class utVideo
    {
        [TestMethod]
        public void LoadTest()
        {
            Task.Run(async () =>
            {
                List<Video> videos = (List<Video>)await VideoManager.Load();
                Assert.AreEqual(4, videos.ToList().Count);
            }).GetAwaiter().GetResult();
        }
        [TestMethod]
        public void InsertTest()
        {
            Task.Run(async () =>
            {
                Video video = new Video();


                int results = await VideoManager.Insert(new Video { VideoURL = "Test" }, true);
                Assert.IsTrue(results > 0);

            });

        }
        [TestMethod]
        public void UpdateTest()
        {

            var task = VideoManager.Load();
            IEnumerable<Video> videos = task.Result;
            task.Wait();
            Video video = videos.FirstOrDefault(c => c.VideoURL == "https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            video.VideoURL = "Tested";
            var results = VideoManager.Update(video, true);
            Assert.IsTrue(results.Result > 0);

        }
        [TestMethod]
        public void DeleteTest()
        {
            Task.Run(async () =>
            {
                var task = await VideoManager.Load();
                IEnumerable<Video> videos = task;
                Video video = videos.FirstOrDefault(c => c.VideoURL == "https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                int results = await VideoManager.Delete(video.Id, true);
                Assert.IsTrue(results > 0);

            });
        }
    }
}
