using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Tek_Yonlu_Dairesel_Basa_ve_Sona_Ekleme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste liste = new Liste();
            int secim = menu();
            int sayi;
            int indis;
            while(secim != 0) 
            {
                switch(secim)
                {
                    case 1:
                        Console.Write("sayı: "); sayi = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine();
                        liste.BasaEkle(sayi);
                        liste.Yazdir();
                        break;
                    case 2:
                        Console.Write("sayı: "); sayi = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine();
                        liste.SonaEkle(sayi);
                        liste.Yazdir();
                        break;
                    case 3:
                        Console.Write("sayı: ");sayi = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("indis: "); indis = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine();
                        liste.ArayaEkle(indis, sayi);
                        liste.Yazdir();
                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine();
                        liste.BastanSil();
                        liste.Yazdir();
                        break;
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine();
                        liste.SondanSil();
                        liste.Yazdir();
                        break;
                    case 6:
                        Console.Write("indis: "); indis = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine();
                        liste.AradanSil(indis);
                        liste.Yazdir();
                        break;
                    default:
                        Console.WriteLine("\n\n\nHATALI BİR İŞLEM NUMARASI GİRDİNİZ\n\n");
                        break;
                }
               secim = menu();
            }
            Console.ReadKey();  
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("*----------*------------*");
            Console.WriteLine("1- BASA EKLE");
            Console.WriteLine("2- SONDA EKLE");
            Console.WriteLine("3- ARAYA EKLE");
            Console.WriteLine("4- BASTAN SIL");
            Console.WriteLine("5- SONDAN SIL");
            Console.WriteLine("6- ARADAN SIL");
            Console.WriteLine("0- CIKIS");
            Console.WriteLine("*----------*------------*");
            Console.Write("SECIMINIZ: ");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }
    class Node
    {
        public int data;
        public Node next;
        public Node(int data) 
        {
            this.data = data;
            next = null;
        }
    }
    class Liste
    {
        Node head;
        Node tail;
        public Liste()
        {
            head = tail = null; 
        }
        public void BasaEkle(int data)
        {
            Node eleman = new Node(data);
            if(head == null)
            {
                head = tail = eleman;
                tail.next = head;
                Console.WriteLine("\nBASA ELEMAN EKLENDI");
            }
            else
            {
                eleman.next = head;
                head = eleman;
                tail.next = head;
                Console.WriteLine("\nBASA ELEMAN EKLENDI");
            }
        }
        public void SonaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null) 
            {
                head = tail = eleman;
                tail.next = head;
                Console.WriteLine("\nSONA ELEMAN EKLENDI");
            }
            else
            {
                tail.next = eleman;
                tail = eleman;
                tail.next = head;
                Console.WriteLine("\nSONA ELEMAN EKLENDI");
            }
        }
        public void ArayaEkle(int indis, int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = tail =eleman;
                tail.next = head;
                Console.WriteLine("\nLISTE OLUSTURULDU VE ELEMAN EKLENDI");
            }
            else if (head != null && indis == 0)
            {
                BasaEkle(data);
                Console.WriteLine("\nARAYA EKLENDI");
            }
            else
            {
                int i = 0;
                Node temp = head;
                Node temp2 = temp;
                while (temp != tail)
                {
                    if (i == indis)
                    {
                        temp2.next = eleman;
                        eleman.next = temp;
                        Console.WriteLine("\nARAYA EKLENDI");
                        i++;
                        break;
                    }
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)
                {
                    temp2.next = eleman;
                    eleman.next = temp;
                    Console.WriteLine("\nARAYA EKLENDI");
                }
            }


        }
        public void Yazdir()
        {
            if(head == null)
            {
                Console.WriteLine("\nLISTE BOS");
            }
            else
            {
                Node temp = head;
                while (temp != tail)
                {
                    Console.Write(temp.data + " --> ");
                    temp = temp.next;
                }
                Console.WriteLine(temp.data + " --> null\n\n");
            }
        }
        public void BastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("\nLISTE BOS");
            }
            else if (head.next == head)
            {
                head = tail = null;
                Console.WriteLine("\nBASTAN ELEMAN SILINDI");
            }
            else
            {
                head = head.next;
                tail.next = head;
                Console.WriteLine("\nBASTAN ELEMAN SILINDI");
            }
        }
        public void SondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("\nLISTE BOS");
            }
            else if (head.next == tail)
            {
                head = tail = null;
                Console.WriteLine("\nSONDAN ELEMAN SILINDI");
            }
            else
            {
                Node temp = head;
                while (temp.next != tail)
                {
                    temp = temp.next;
                }
                temp.next = null;
                tail = temp;
                tail.next = head;
                Console.WriteLine("\nSONDAN ELEMAN SILINDI");
            }
        }
        public void AradanSil(int indis)
        {
            if (head == null)
            {
                Console.WriteLine("LISTE BOS");
            }
            else if (head.next == head && indis == 0)
            {
                head = tail = null;
                Console.WriteLine("ARADAN ELEMAN SILINDI");
            }
            else if (head.next != head && indis == 0)
            {
                BastanSil();
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                int i = 0;

                while (temp!= tail)
                {
                    if (i == indis)
                    {
                        temp2.next = temp.next;
                        Console.WriteLine("ARADAN ELEMANS SILINDI");
                        i++;
                        break;
                    }
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)
                {
                    SondanSil();
                }

            }
        }
    }
}
