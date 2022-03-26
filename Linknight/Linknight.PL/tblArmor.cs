using System;
using System.Collections.Generic;

#nullable disable

namespace Linknight.PL
{
    public partial class tblArmor
    {
        public tblArmor()
        {
            tblProfiles = new HashSet<tblProfile>();
        }

        public int Id { get; set; }
        public string ArmorType { get; set; }

        public virtual ICollection<tblProfile> tblProfiles { get; set; }
    }
}
