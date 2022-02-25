using System;
using System.Collections.Generic;

#nullable disable

namespace Linknight.PL
{
    public partial class tblArmor
    {
        public tblArmor()
        {
            tblCharacters = new HashSet<tblCharacter>();
        }

        public int Id { get; set; }
        public string ArmorType { get; set; }

        public virtual ICollection<tblCharacter> tblCharacters { get; set; }
    }
}
