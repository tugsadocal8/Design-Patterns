using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adaptor_DesignPatterns
{
    class Program
    {
        class Adapte
        {
            public double ozelIstek(double a, double b)
            {
                return a / b;
            }

        }
        interface IHedef
        {
            string istek(int i);

        }

        class Adaptor: Adapte, IHedef
        {
            public string istek(int i)
            {
                return "Sayı" + (int)Math.Round(ozelIstek(i, 3));

            }
        }
        static void Main(string[] args)
        {
            Adapte _adapte = new Adapte();
            Console.WriteLine("Eski: ");
            Console.WriteLine(_adapte.ozelIstek(5,3));
            

            IHedef _hedef = new Adaptor();
            Console.WriteLine("yeni arayuz");
            Console.WriteLine(_hedef.istek(5));
            Console.ReadKey();
        }
    }
}
