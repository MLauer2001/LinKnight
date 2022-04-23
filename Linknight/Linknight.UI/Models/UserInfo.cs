using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linknight.UI.Models
{
    public class UserInfo
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        public string UserGroup { get; set; }

        //if 0 = Busy
        //if 1 = Free
        public string freeflag { get; set; }

        //if tpflag is 2 = User Admin
        //if tpflag is 0 = User Member
        //if tpflag is 1 = Admin

        public string tpflag { get; set; }

        public int UserID { get; set; }
        public int AdminID { get; set; }
    }
}
