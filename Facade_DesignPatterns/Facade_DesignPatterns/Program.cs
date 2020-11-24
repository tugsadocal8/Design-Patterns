using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_DesignPatterns
{
    class Program
    {

        public class Gadget
        {
            public string islem1()
            {
                return "Gaget: Hazır \n";
            }
            public string islem2()
            {
                return "Gaget: Kalkıyor \n";
            }
        }

        public class Spencer
        {
            public string islem1()
            {
                return "Spencer: Hazır \n";
            }
            public string islem2()
            {
                return "Spencer: Ateş \n";
            }
        }

        public class Cephe
        {
            protected Gadget _g;
            protected Spencer _s;

            public Cephe(Gadget altG,Spencer altS)
            {
                this._g = altG;
                this._s = altS;
            }
            public string İslem()
            {
                string sonuc = "Cephe Tasarım alt sistem başlattı\n";
                sonuc += this._g.islem1();
                sonuc += this._s.islem1();
                sonuc += "komut gönderme";
                sonuc += this._g.islem2();
                sonuc += this._s.islem2();
                return sonuc;
            }
        }

        static void Main(string[] args)
        {
            Gadget altG = new Gadget();
            Spencer altS = new Spencer();
            Cephe cep = new Cephe(altG, altS);
            Console.WriteLine(cep.İslem());
        }
    }
}
