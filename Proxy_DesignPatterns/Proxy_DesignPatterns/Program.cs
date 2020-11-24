using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_DesignPatterns
{
    class Program
    {
        public interface INesne
        {
            string istek();

        }
        private class Nesne
        {
            public string istek()
            {
                return "Sol tarafta ki kapıya git\n";
            }
        }
        public class Proxy : INesne
        {
            Nesne _nesne;
            public string istek()
            {
                if(_nesne == null)
                {
                    Console.WriteLine("Robot aktif değildir");
                    _nesne = new Nesne();
                    return "Proxy sınıfı istek bulamadı.";
                }
                else
                {
                    Console.WriteLine("Robot aktif durumdadır.");
                }
                return "istek : " + _nesne.istek();
            }
        }

        public class protectedProxy:INesne
        {
            Nesne _nesne;
            string sifre = "hodor";
            public string dogrulama(string _s)
            {
                if (_s!=sifre)
                {
                    return "Şifre geçerli değil";
                }
                else
                {
                    return "Erişim sağlandı";
                }
            }
            public string istek()
            {
                if(_nesne==null)
                {
                    return "Doğrulama işlemi gerçekleştiriniz";
                }
                else
                {
                    return "Doğrulama sağlandı"+_nesne.istek();
                }
            }
        }
        static void Main(string[] args)
        {
            INesne _nesne = new Proxy();
            Console.WriteLine(_nesne.istek());
            Console.WriteLine(_nesne.istek());

            _nesne = new protectedProxy();
            Console.WriteLine((_nesne as protectedProxy).dogrulama("Deneme"));
            Console.WriteLine((_nesne as protectedProxy).dogrulama("hodor"));
        }
    }
}
