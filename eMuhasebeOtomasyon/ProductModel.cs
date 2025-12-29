using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMuhasebeOtomasyon
{

    public class ProductModel
    {
        public string Barkod { get; set; }
        public string UrunAdi { get; set; }
        public int StokAdedi { get; set; }
        public int KritikSeviye { get; set; }
        public double AlisFiyati { get; set; }
        public double SatisFiyati { get; set; }
    }
}
