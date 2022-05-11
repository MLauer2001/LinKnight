using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL.Models
{
    public class Lobby
    {
        public Guid Id { get; set; }
        [DisplayName("Lobby Name")]
        public string LobbyKey { get; set; }
    }
}
