using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_DesignPatterns
{
    class Program
    {
        public class IDBilgi
        {
            public int IDNo;
            public IDBilgi(int idNo)
            {
                this.IDNo = idNo;
            }

        }

        public class Insan
        {
            public int yas;
            public DateTime dogumTarihi;
            public string isim;
            public IDBilgi IDBilgi;

            public Insan yuzeyselKopyalama()
            {
                return (Insan)this.MemberwiseClone();
            }

            public Insan derinKopyalama()
            {
                Insan klon = (Insan)this.MemberwiseClone();
                klon.IDBilgi = new IDBilgi(IDBilgi.IDNo);
                klon.isim = String.Copy(isim);
                return klon;
            }
            public static void degerGoster(Insan i)
            {
                Console.WriteLine("İsim: {0:s}, Yaş: {1:d},Doğum Tarihi: {2:dd/MM/yyyy}", i.isim, i.yas, i.dogumTarihi);
                Console.WriteLine("ID#: {0:d}", i.IDBilgi.IDNo);
            }
        }

        static void Main(string[] args)
        {
            // nesne hakkında genel bilgi
            Insan _i1 = new Insan();
            _i1.yas = 35;
            _i1.dogumTarihi = Convert.ToDateTime("2000-01-01");
            _i1.isim = "sac";
            _i1.IDBilgi = new IDBilgi(001);

            //_i1 nesnesinin yüzeysel olarak kopyalanması ve _i2 nesnesine aktarılması
            Insan _i2 = _i1.yuzeyselKopyalama();
            //_i1 nesnesinin derin kopya ve _i3 nesnesine aktarılması
            Insan _i3 = _i1.derinKopyalama();

            //Nesnelerin ilk değerlerinin gösterilmesi
            Console.WriteLine("Nesnelerin orijinal değerleri \n");
            Insan.degerGoster(_i1);
            Insan.degerGoster(_i2);
            Insan.degerGoster(_i3);

            //_i1 nesnesinin değerlerinin değiştirilmesi
            _i1.yas = 45;
            _i1.dogumTarihi = Convert.ToDateTime("1990-01-01");
            _i1.isim = "cas";
            _i1.IDBilgi = new IDBilgi(002);

            //Nesnelerin yeni değerlerinin gösterilmesi
            Console.WriteLine("Nesnelerin yeni değerleri \n");
            Insan.degerGoster(_i1);
            //referans değeri değiştirir
            Insan.degerGoster(_i2);
            Insan.degerGoster(_i3);

            Console.ReadKey();
        }
    }
}
