using System;
using System.Collections.Generic;

#nullable disable

namespace Linknight.PL
{
    public partial class tblColor
    {
        public tblColor()
        {
            tblProfiles = new HashSet<tblProfile>();
        }

        public int Id { get; set; }
        public string Color { get; set; }

        public virtual ICollection<tblProfile> tblProfiles { get; set; }
    }
}
