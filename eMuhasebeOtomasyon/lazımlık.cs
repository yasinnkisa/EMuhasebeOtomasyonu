using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMuhasebeOtomasyon
{
    internal class lazımlık
    {
        public class AppConfig
        {
            public string SirketAdi { get; set; }
            public string Versiyon { get; set; }
            public string Durum { get; set; }
        }

        // Hesap planı kodları için model
        public class AccountPlanModel
        {
            public string Kod { get; set; }
            public string Aciklama { get; set; }
        }

    }
}
