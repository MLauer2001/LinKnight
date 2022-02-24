using System;
using System.Collections.Generic;

#nullable disable

namespace Linknight.PL
{
    public partial class tblLobby
    {
        public tblLobby()
        {
            tblProfiles = new HashSet<tblProfile>();
            tblVideos = new HashSet<tblVideo>();
        }

        public Guid Id { get; set; }
        public string LobbyKey { get; set; }

        public virtual ICollection<tblProfile> tblProfiles { get; set; }
        public virtual ICollection<tblVideo> tblVideos { get; set; }
    }
}
