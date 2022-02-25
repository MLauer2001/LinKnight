using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL.Models
{
    public class Video
    {
        public Guid Id { get; set; }
        public string VideoURL { get; set; }
        public Guid LobbyId { get; set; }
    }
}
