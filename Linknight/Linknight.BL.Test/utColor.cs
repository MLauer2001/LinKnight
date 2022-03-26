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
    public class utColor
    {
        [TestMethod]
        public void LoadTest()
        {
            Task.Run(async () =>
            {
                List<Color> colors = (List<Color>)await ColorManager.Load();
                Assert.AreEqual(4, colors.ToList().Count);
            }).GetAwaiter().GetResult();
        }
    }
}