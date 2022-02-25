using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int ArmorId { get; set; }
        public int HelmId { get; set; }
    }
}
