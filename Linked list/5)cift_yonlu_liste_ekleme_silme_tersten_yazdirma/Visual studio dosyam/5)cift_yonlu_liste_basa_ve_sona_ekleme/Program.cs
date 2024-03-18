using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace _5_cift_yonlu_liste_basa_ve_sona_ekleme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste listem = new Liste();
            int secim = menu();
            int sayi;
            while(secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("sayı: ");sayi = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        listem.BasaEkle(sayi);
                        listem.yazdir();
                        break;
                    case 2:
                        Console.Write("sayı: ");sayi = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        listem.SonaEkle(sayi);
                        listem.yazdir();
                        break;
                    case 3:
                        listem.tersYazdır();
                        break;
                    case 4:
                        listem.BastanSil();
                        listem.yazdir();
                        break;
                    case 5:
                        listem.SondanSil();
                        listem.yazdir();
                        break;
                    default:
                        Console.WriteLine("HATALI BİR İŞLEM NUMARASI GİRDİNİZ");
                        break;
                }
                secim = menu();
            }
        }

        private static int menu()
        {
            Console.WriteLine("1- basa ekle");
            Console.WriteLine("2- sona ekle");
            Console.WriteLine("3- tersten yazdır");
            Console.WriteLine("4- baştan sil");
            Console.WriteLine("5- sondan sil");
            Console.WriteLine("0- çıkış");
            Console.Write("Seçiminiz: ");
            int secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }
    class Node
    {
        public int data;
        public Node next;
        public Node prev;
        public Node(int data )
        {
            this.data = data;
            prev=next = null;
        }
    }
    class Liste
    {
        public Node head;
        public Node tail;

        public Liste()
        {
            head = tail = null;
        }
        public void BasaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = tail = eleman;
                Console.WriteLine($"Liste oluşturuldu ve başa {data} elemanı eklendi");

            }
            else
            {
                eleman.next = head;
                head.prev = eleman;
                head = eleman;
                Console.WriteLine();
                Console.WriteLine($"En başa {data} elemanı eklendi");
            }
        }
        public void SonaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = tail = eleman;
                Console.WriteLine($"Liste oluşturuldu ve sona {data} elemanı eklendi");
                Console.WriteLine();

            }
            else
            {
                tail.next = eleman;
                eleman.prev = tail;
                Console.WriteLine();    
                Console.WriteLine($"sona {data} elemanı eklendi");
            Console.WriteLine();

                tail = eleman;
            }
        }
        public void yazdir()
        {
            if(head == null)
            {
                Console.WriteLine();
                Console.WriteLine("liste boş");
            }
            else
            {
            Node temp = head;
            while (temp.next != null)
            {
                Console.Write(temp.data + " --> ");
                temp = temp.next;
            }
            Console.Write(temp.data + " --> null");
            Console.WriteLine();
            Console.WriteLine();
            }
        }
        public void tersYazdır()
        {
            if (head == null) { 
                Console.WriteLine("lİSTE BOŞ"); 
                Console.WriteLine();
            }
            else
            {
                Node temp = tail;
                Console.WriteLine();
                Console.WriteLine("Sondan başa doğru yazdırılıyor...");
                while (temp.prev != null)
                {
                    Console.Write(temp.data + " --> ");
                    temp = temp.prev;
                }
                Console.WriteLine(temp.data + " --> null");
                Console.WriteLine();
            }
        }
        public void BastanSil()
        {
            if (head == null)
            {
                Console.WriteLine();
                Console.WriteLine("silinecek öge yok");
            }
            else if( head.next == null )
            {
                head = tail = null;
                Console.WriteLine();

                Console.WriteLine("listede kalan son eleman da silindi");

            }
            else
            {
                head = head.next;
                head.prev = null;
                Console.WriteLine();

                Console.WriteLine("silme işlemi başarılı");
            }
        }
        public void SondanSil()
        {
            if (head == null)
            {
                Console.WriteLine();
                Console.WriteLine("silinecek eleman yok");    
            }
            else if (head.next == null)
            {
                head = tail = null;
                Console.WriteLine();
                Console.WriteLine("son eleman da silindi");
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
                Console.WriteLine();
                Console.WriteLine("Sondaki eleman silindi");
            }
        }
    }
}
