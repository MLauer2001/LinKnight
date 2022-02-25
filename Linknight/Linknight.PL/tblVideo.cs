using System;
using System.Collections.Generic;

#nullable disable

namespace Linknight.PL
{
    public partial class tblVideo
    {
        public Guid Id { get; set; }
        public string VideoURL { get; set; }
        public Guid LobbyId { get; set; }

        public virtual tblLobby Lobby { get; set; }
    }
}
