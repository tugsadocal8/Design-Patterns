using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_DesignPattern_2
{
    class Program
    {
        interface IAraba
        {
            void bilgiDetaylari();
            void fiyatEkle(double eklenmisFiyat);
            void tanimEkle(string eklenmisTanim);
        }

        public class Araba:IAraba
        {
            public string model { get; set; }
            public string marka { get; set; }
            public double fiyat { get; set; }
            public string tanim { get; set; }

            public Araba()
            {
                fiyat = 125.000;
            }

            public void bilgiDetaylari()
            {
                Console.WriteLine(tanim);
            }

            public void fiyatEkle(double eklenmisFiyat)
            {
                fiyat += eklenmisFiyat;
            }
            public void tanimEkle(string eklenmisTanim)
            {
                tanim = "Model:" + model + " Marka:" + marka + " güncel fiyat: " + fiyat.ToString() + " " + eklenmisTanim;
            }

            class ArabaDecorator : IAraba
            {
                private IAraba araba;
                public ArabaDecorator(IAraba a)
                {
                    araba = a;
                }
                public void bilgiDetaylari()
                {
                    araba.bilgiDetaylari();
                }
                public void fiyatEkle(double eklenmisFiyat)
                {
                    araba.fiyatEkle(eklenmisFiyat);
                }
                public void tanimEkle(string eklenmisTanim)
                {
                    araba.tanimEkle(eklenmisTanim);
                }

                class SunroofDecorator:ArabaDecorator
                {
                    public SunroofDecorator(IAraba araba) : base(araba) { }

                    public void bilgiDetaylari()
                    {
                        base.fiyatEkle(15.000);
                        base.tanimEkle("Cam tavan araca eklendi");
                        base.bilgiDetaylari();
                    }
                }
                class ParkSensorDecorator : ArabaDecorator
                {
                    public ParkSensorDecorator(IAraba araba) : base(araba) { }

                    public void bilgiDetaylari()
                    {
                        base.fiyatEkle(10.000);
                        base.tanimEkle("Park sensörü araca eklendi");
                        base.bilgiDetaylari();
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            IAraba araba = new Araba() { model = "Polo", marka = "vw", fiyat = 125.000, tanim = "yeni araba" };
            
        }
    }
}
