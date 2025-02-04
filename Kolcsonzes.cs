using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KajakKenu
{
    internal class Kolcsonzes
    {
        public string Nev { get; set; }
        public int Hajoid { get; set; }
        public string Hajotipus { get; set; }
        public int Szemelyekszama { get; set; }
        public int Elvitelora { get; set; }
        public int Elvitelperc { get; set; }
        public int Visszahozatalora { get; set; }
        public int Visszahozatalperc { get; set; }
        public int Vizentoltottora => Visszahozatalora - Elvitelora;
        public int Vizentoltottperc => Visszahozatalperc - Elvitelperc;

        public Kolcsonzes(string row)
        {
            string[] data = row.Split(';');
            Nev = data[0];
            Hajoid = int.Parse(data[1]);
            Hajotipus = data[2];
            Szemelyekszama = int.Parse(data[3]);
            Elvitelora = int.Parse(data[4]);
            Elvitelperc = int.Parse(data[5]);
            Visszahozatalora = int.Parse(data[6]);
            Visszahozatalperc = int.Parse(data[7]);
        }

        //Feladat 3
        public override string ToString()
        {
            return $"{Nev.Replace(" ", "")}{Hajoid}_{Vizentoltottora}:{Math.Abs(Vizentoltottperc)}";
        }
    }
}
