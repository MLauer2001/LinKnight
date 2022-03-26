using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linknight.BL.Models;

namespace Linknight.UI.ViewModels
{
    public class ProfileViewModel
    {
        public Profile Profile { get; set; }
        public List<Armor> Armors { get; set; }
        public List<Helm> Helms { get; set; }
        public List<Color> Colors { get; set; }
        public List<Lobby> Lobbys { get; set; }
    }
}
