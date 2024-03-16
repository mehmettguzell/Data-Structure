
using System.Runtime.CompilerServices;

namespace _3_Menu_olusturma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Liste listem = new Liste();
            int secim = menu();
            int sayi;

            while(secim!=0)
            {
                switch (secim) 
                {
                    case 1:
                        Console.Write("sayı: ");
                        sayi = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        listem.basaEkle(sayi);
                        break;
                    case 2:
                        Console.Write("sayı: ");
                        sayi = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        listem.sonaEkle(sayi);
                        break;
                    case 3:
                        Console.WriteLine();
                        listem.bastanSil();
                        break;
                    case 4:
                        Console.WriteLine();
                        listem.sondanSil();
                        break;
                    default:
                        Console.WriteLine("!!! YANLIŞ SAYI GİRDİNİZ !!!");
                        break;
                }
                listem.yazdir();
                Console.WriteLine();
                secim = menu();
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("-----------------");
            Console.WriteLine("1- Başa ekle ");
            Console.WriteLine("2- Sona ekle ");
            Console.WriteLine("3- Baştan sil ");
            Console.WriteLine("4- Sondan sil ");
            Console.WriteLine("0- Çıkış yap ");
            Console.WriteLine("-----------------");
            Console.Write("Seçiminiz: ");
            secim = int.Parse(Console.ReadLine()); 
            return secim;

        }
    }
}
