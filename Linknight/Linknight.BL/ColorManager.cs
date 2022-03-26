using Linknight.BL.Models;
using Linknight.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL
{
    public class ColorManager
    {
        public static List<Color> Load()
        {
            try
            {
                List<Color> colors = new List<Color>();
                using (LinknightEntities dc = new LinknightEntities())
                {
                    dc.tblColors
                        .ToList()
                        .ForEach(a => colors.Add(new Color
                        {
                            Id = a.Id,
                            Image = a.Color
                        }));
                }
                return colors;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
