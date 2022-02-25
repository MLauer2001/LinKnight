using System;
using System.Collections.Generic;

#nullable disable

namespace Linknight.PL
{
    public partial class tblProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LobbyId { get; set; }
        public int CharacterId { get; set; }

        public virtual tblCharacter Character { get; set; }
        public virtual tblLobby Lobby { get; set; }
    }
}
