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
        public int ArmorId { get; set; }
        public int ColorId { get; set; }
        public int HelmId { get; set; }

        public virtual tblArmor Armor { get; set; }
        public virtual tblColor Color { get; set; }
        public virtual tblHelm Helm { get; set; }
        public virtual tblLobby Lobby { get; set; }
    }
}
