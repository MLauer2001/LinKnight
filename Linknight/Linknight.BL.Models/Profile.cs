using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL.Models
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LobbyId { get; set; }
        public int CharacterId { get; set; }
    }
}
