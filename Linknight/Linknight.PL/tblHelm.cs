using System;
using System.Collections.Generic;

#nullable disable

namespace Linknight.PL
{
    public partial class tblHelm
    {
        public tblHelm()
        {
            tblCharacters = new HashSet<tblCharacter>();
        }

        public int Id { get; set; }
        public string HelmType { get; set; }

        public virtual ICollection<tblCharacter> tblCharacters { get; set; }
    }
}
