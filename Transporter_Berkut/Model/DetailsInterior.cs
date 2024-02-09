using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporter_Berkut.Model
{
    public class DetailsInterior: DetailsMain
    {
        public DetailsInterior(List<Detail> det) :base(det,"ИМ создание интерьера")
        {
        }

        public static void Get(List<Detail> a)
        {
            foreach (var t in a)
            {
                Console.WriteLine(t.PartName);
            }
        }
    }
}
