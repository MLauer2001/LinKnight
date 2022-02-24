using System;
using System.Collections.Generic;

#nullable disable

namespace Linknight.PL
{
    public partial class tblHelm
    {
        public tblHelm()
        {
            tblProfiles = new HashSet<tblProfile>();
        }

        public int Id { get; set; }
        public string HelmType { get; set; }

        public virtual ICollection<tblProfile> tblProfiles { get; set; }
    }
}
