using System;
using System.Collections.Generic;

#nullable disable

namespace Linknight.PL
{
    public partial class tblCharacter
    {
        public tblCharacter()
        {
            tblProfiles = new HashSet<tblProfile>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public int HelmId { get; set; }
        public int ArmorId { get; set; }

        public virtual tblArmor Armor { get; set; }
        public virtual tblHelm Helm { get; set; }
        public virtual ICollection<tblProfile> tblProfiles { get; set; }
    }
}
