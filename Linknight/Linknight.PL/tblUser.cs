using System;
using System.Collections.Generic;

#nullable disable

namespace Linknight.PL
{
    public partial class tblUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
