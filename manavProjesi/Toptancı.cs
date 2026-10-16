using System;
using System.Collections.Generic;
using System.Text;

namespace manavProjesi
{
    internal class Toptancı
    {
        public List<Urun> meyveler = new List<Urun>()
        {
            new Urun{ad = "Elma",kilo = 100m},
            new Urun{ad = "Armut",kilo = 80m},
            new Urun{ad = "Muz",kilo = 60m},
        };

        public List<Urun> sebzeler = new List<Urun>()
        {
            new Urun{ad = "Domates",kilo=100m},
            new Urun{ad = "Biber",kilo=70m},
            new Urun{ad = "Patates",kilo=150m},
        };
    }
}
