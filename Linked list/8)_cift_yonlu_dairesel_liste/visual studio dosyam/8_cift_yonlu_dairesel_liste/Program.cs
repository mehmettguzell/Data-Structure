using System.ComponentModel.Design;

namespace _8_cift_yonlu_dairesel_liste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste liste = new Liste();
            int secim = menu();
            int sayi;
            int indis;
            while (secim != 0)
            {
                switch (secim)
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
                        Console.Write("sayı: "); sayi = int.Parse(Console.ReadLine());
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
        public Node prev;
        public Node(int data)
        {
            this.data = data;
            next = prev = null;
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
            if (head == null) 
            {
                head = tail = eleman;
                tail.prev = head;
                tail.next = head;
                head.next = tail;
                head.prev = tail;
                Console.WriteLine("Liste oluşturuldu ve en başa eleman eklendi");
            }
            else
            {
                eleman.next = head;
                head.prev = eleman;
                head = eleman;

                head.prev = tail;
                tail.next = head;
                Console.WriteLine("eleman en başa eklendi");
            }
        }
        public void SonaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = tail = eleman;
                tail.prev = head;
                tail.next = head;
                head.next = tail;
                head.prev = tail;
                Console.WriteLine("Liste oluşturuldu ve en başa eleman eklendi");
            }
            else
            {
                tail.next = eleman;
                eleman.prev = tail;

                tail = eleman;

                tail.next = head;
                head.prev = tail;
            }
        }
        public void Yazdir()
        {
            if (head == null)
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
        public void ArayaEkle(int indis , int data)
        {
            Node eleman = new Node(data);

            if (head == null)
            {
                head = tail = eleman;
                tail.prev = head;
                tail.next = head;
                head.next = tail;
                head.prev = tail;
                Console.WriteLine("Liste oluşturuldu ve en başa eleman eklendi");
            }
            else if (head != null && indis == 0)
            {
                BasaEkle(data);
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                int i = 0;
                while (temp!=tail)
                {
                    if (i == indis)
                    {
                        i++;
                        temp2.next = eleman;
                        eleman.prev = temp2;

                        eleman.next = temp;
                        temp.prev = eleman;
                        Console.WriteLine("Araya eklendi");
                        break;
                    }
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if(i== indis)
                {
                    SonaEkle(data);
                }
            }
        }
        public void BastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
            }
            else if (head.next == head)
            {
                head = tail = null;
                Console.WriteLine("Eleman silindi, Listede eleman kalmadı");
            }
            else
            {
                head = head.next;
                head.prev = tail;
                tail.next = head;
                Console.WriteLine("Baştan eleman silindi");
            }
        }
        public void SondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
            }
            else if (head.next == head)
            {
                head = tail = null;
                Console.WriteLine("Eleman silindi, Listede eleman kalmadı");
            }
            else
            {
                tail = tail.prev;
                tail.next = head;
                head.prev = tail;
                Console.WriteLine("Sondan eleman silindi");
            }
        }
        public void AradanSil(int indis)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
            }
            else if (head.next == head && indis ==0)
            {
                head = tail = null;
                Console.WriteLine("Eleman silindi, Listede eleman kalmadı");
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

                while (temp != tail)
                {
                    if (indis == i)
                    {
                        temp2.next = temp.next;
                        temp.next.prev = temp2;
                        i++;
                        Console.WriteLine("Aradan eleman silindi");
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
