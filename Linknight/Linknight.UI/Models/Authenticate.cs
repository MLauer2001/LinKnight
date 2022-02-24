using Linknight.BL.Models;
using Linknight.UI.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linknight.UI.Models
{
    public static class Authenticate
    {
        public static bool IsAuthenticated(HttpContext context)
        {
            if (context.Session.GetObject<Admin>("admin") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
