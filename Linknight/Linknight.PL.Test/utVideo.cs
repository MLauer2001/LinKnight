using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Linq;

namespace Linknight.PL.Test
{
    public class utVideo
    {
        protected LinknightEntities dc;
        protected IDbContextTransaction transaction;

        [SetUp]
        public void Setup()
        {
            dc = new LinknightEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            transaction.Rollback();
            transaction = null;
        }

        [Test]
        public void LoadTest()
        {
            Assert.AreEqual(4, dc.tblVideos.Count());
        }

        [Test]
        public void InsertTest()
        {

            tblVideo newrow = new tblVideo();
            newrow.Id = Guid.NewGuid();
            newrow.LobbyId = dc.tblLobbies.FirstOrDefault().Id;
            newrow.VideoURL = "Whoop";

            dc.tblVideos.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblVideo existingrow = dc.tblVideos.FirstOrDefault(c => c.VideoURL == "https://www.youtube.com/watch?v=dQw4w9WgXcQ");

            if (existingrow != null)
            {
                existingrow.VideoURL = "Matt";
                dc.SaveChanges();
            }

            tblVideo row = dc.tblVideos.FirstOrDefault(c => c.VideoURL == "Matt");

            Assert.AreEqual(existingrow.VideoURL, row.VideoURL);
        }

        [Test]
        public void DeleteTest()
        {

            InsertTest();

            tblVideo row = dc.tblVideos.FirstOrDefault(c => c.VideoURL == "https://www.youtube.com/watch?v=dQw4w9WgXcQ");

            if (row != null)
            {
                dc.tblVideos.Remove(row);
                dc.SaveChanges();
            }

            tblVideo deletedrow = dc.tblVideos.FirstOrDefault(c => c.VideoURL == "https://www.youtube.com/watch?v=dQw4w9WgXcQ");

            Assert.IsNull(deletedrow);
        }
    }
}
