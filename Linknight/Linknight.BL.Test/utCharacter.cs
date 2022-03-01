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
    public class utCharacter
    {
        [TestMethod]
        public void LoadTest()
        {
            Task.Run(async () =>
            {
                List<Character> characters = (List<Character>)await CharacterManager.Load();
                Assert.AreEqual(4, characters.ToList().Count);
            }).GetAwaiter().GetResult();
        }
        [TestMethod]
        public void InsertTest()
        {
            Task.Run(async () =>
            {
                Character character = new Character();


                int results = await CharacterManager.Insert(new Character { Color = "Blue" }, true);
                Assert.IsTrue(results > 0);

            });

        }
        [TestMethod]
        public void UpdateTest()
        {

            var task = CharacterManager.Load();
            IEnumerable<Character> characters = task.Result;
            task.Wait();
            Character character = characters.FirstOrDefault(c => c.Color == "Blue");
            character.Color = "Violet";
            var results = CharacterManager.Update(character, true);
            Assert.IsTrue(results.Result > 0);

        }
        [TestMethod]
        public void DeleteTest()
        {
            Task.Run(async () =>
            {
                var task = await CharacterManager.Load();
                IEnumerable<Character> characters = task;
                Character character = characters.FirstOrDefault(c => c.Color == "Blue");
                int results = await CharacterManager.Delete(character.Id, true);
                Assert.IsTrue(results > 0);

            });
        }
    }
}
