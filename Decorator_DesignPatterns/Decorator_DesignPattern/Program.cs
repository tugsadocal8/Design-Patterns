using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_DesignPattern
{
    class Program
    {
        interface IBilesen
        {
            string Operasyon();
        }

        class Bileşen:IBilesen
        {
            public string Operasyon()
            {
                return "İstanbulu dinliyorum";
            }
        }
        class DecoratorA:IBilesen
        {
            private IBilesen bilesen;

            public DecoratorA(IBilesen b)
            {
                bilesen = b;
            }

            public string Operasyon()
            {
                string s = bilesen.Operasyon();
                s += "gözlerim kapalı";
                return s;

            }
        }
        class DecoratorB : IBilesen
        {
            private IBilesen bilesen;
            public DecoratorB(IBilesen b)
            {
                bilesen = b;
            }

            public string Operasyon()
            {
                string s = bilesen.Operasyon();
                s += "Önce hafiften bir rüzgr esiyor";
                return s;
            }
            public string yeniDavranis()
            {
                return "Yavaş Yavaş sallanıyor";
            }
        }
        static void Main(string[] args)
        {
            IBilesen bilesen = new Bileşen();
            Console.WriteLine(bilesen.Operasyon());
            Console.WriteLine(new DecoratorA(bilesen).Operasyon());
            Console.WriteLine(new DecoratorB(bilesen).Operasyon());
            Console.WriteLine(new DecoratorB(bilesen).yeniDavranis());
            Console.WriteLine(new DecoratorB(new DecoratorA(bilesen)).Operasyon());
            
            Console.ReadKey();
        }
    }
}
