using Linknight.BL.Models;
using Linknight.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL
{
    public class HelmManager
    {
        public async static Task<IEnumerable<Helm>> Load()
        {
            try
            {
                List<Helm> helms = new List<Helm>();
                using (LinknightEntities dc = new LinknightEntities())
                {
                    dc.tblArmors
                        .ToList()
                        .ForEach(h => helms.Add(new Helm
                        {
                            Id = h.Id,
                            Image = h.ArmorType
                        }));
                }
                return helms;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
