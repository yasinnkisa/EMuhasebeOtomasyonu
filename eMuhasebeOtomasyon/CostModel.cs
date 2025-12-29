using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMuhasebeOtomasyon
{
    public class CostModel
    {
        public string GiderID { get; set; }
        public string GiderAdi { get; set; }
        public double Tutar { get; set; }
        public string Kategori { get; set; }
        public string Tarih { get; set; }
        public string Aciklama { get; set; } // Bu satırı eklediğinden emin ol
    }
}