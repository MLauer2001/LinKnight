using Linknight.BL.Models;
using Linknight.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL
{
    public class ArmorManager
    {
        public async static Task<IEnumerable<Armor>> Load()
        {
            try
            {
                List<Armor> armors = new List<Armor>();
                using (LinknightEntities dc = new LinknightEntities())
                {
                    dc.tblArmors
                        .ToList()
                        .ForEach(a => armors.Add(new Armor
                        {
                            Id = a.Id,
                            Image = a.ArmorType
                        }));
                }
                return armors;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
