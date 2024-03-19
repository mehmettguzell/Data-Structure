using System.Runtime.CompilerServices;

namespace _6_cift_yonlu_liste_araya_ekleme_ve_silme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Listem listem = new Listem();
            int secim = menu();
            int sayi = 0;
            int indis = 0;
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("sayı: "); sayi = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        listem.BasaEkle(sayi);
                        listem.Yazdir();
                        break;
                    case 2:
                        Console.Write("sayı: "); sayi = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        listem.SonaEkle(sayi);
                        listem.Yazdir();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.Write("sayı: "); sayi = int.Parse(Console.ReadLine());
                        Console.Write("indis: "); indis = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        listem.ArayaEkle(indis,sayi);
                        listem.Yazdir();
                        break;
                    case 4:
                        listem.TersYazdır();
                        break;
                    case 5:
                        listem.BastanSil();
                        listem.Yazdir();
                        break;
                    case 6:
                        listem.SondanSil();
                        listem.Yazdir();
                        break;
                    case 7:
                        Console.Write("indis: ");indis = int.Parse(Console.ReadLine());
                        listem.AradanSil(indis);
                        listem.Yazdir();    
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
            Console.WriteLine("1- Basa ekle");
            Console.WriteLine("2- Sona ekle");
            Console.WriteLine("3- Araya ekle");
            Console.WriteLine("4- Tersten yazdır");
            Console.WriteLine("5- Baştan sil");
            Console.WriteLine("6- Sondan sil");
            Console.WriteLine("7- Aradan sil");
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
        public Node(int data)
        {
            this.data = data;
            next = prev = null;
        }

    }
    class Listem
    {
        public Node head;
        public Node tail;
        public Listem()
        {
            head = tail = null;
        }
        public void BasaEkle(int data)
        {
            Node eleman = new Node(data);
            if(head == null) 
            {
                head = tail = eleman;
                Console.WriteLine();
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
                Console.WriteLine();
                Console.WriteLine($"Liste oluşturuldu ve sona {data} elemanı eklendi");
                Console.WriteLine();
            }
            else
            {
                tail.next = eleman;
                eleman.prev = tail;
                tail = eleman;
                Console.WriteLine();
                Console.WriteLine($"sona {data} elemanı eklendi");
                Console.WriteLine();
            }
        }
        public void ArayaEkle(int indis,int data)
        {
            Node eleman = new Node(data);
            if(head == null)
            {
                head = tail = eleman;
                Console.WriteLine();
                Console.WriteLine($"Liste oluşturuldu ve başa {data} elemanı eklendi");
            }
            else if(head != null && indis == 0)
            {
                BasaEkle(data);
                Console.WriteLine();
                Console.WriteLine($"Liste oluşturuldu ve başa {data} elemanı eklendi");
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                int i=0;
                while (temp.next!=null)
                {
                    if (i == indis)
                    {
                        temp2.next = eleman;
                        eleman.prev = temp2;

                        eleman.next = temp;
                        temp.prev = eleman;
                        Console.WriteLine();
                        Console.WriteLine($"araya {data} sayısı eklendi");
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
                    eleman.prev = temp2;

                    eleman.next = tail;
                    tail.prev = eleman;
                    Console.WriteLine();
                    Console.WriteLine($"araya {data} sayısı eklendi");
                }
            }
        }
        public void Yazdir()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
                Console.WriteLine();
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
        public void TersYazdır()
        {
            if(head == null)
            {
                Console.WriteLine("Liste boş!!");
                Console.WriteLine();
            }
            else
            {
                Node temp = tail;
                while( temp.prev != null)
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
            if(head == null)
            {
                Console.WriteLine();
                Console.WriteLine("silinecek öge yok");
                Console.WriteLine();

            }
            else if(head.next == null)
            {
                head = tail =null;
                Console.WriteLine();
                Console.WriteLine("listede kalan son eleman da silindi");
                Console.WriteLine();
            }
            else
            {
                head = head.next;
                head.prev = null;
                Console.WriteLine();
                Console.WriteLine("silme işlemi başarılı");
                Console.WriteLine();
            }

        }
        public void SondanSil()
        {
            if(head == null)
            {
                Console.WriteLine();
                Console.WriteLine("Liste boş");
                Console.WriteLine();
            }
            else if(head.next == null)
            {
                head = tail =null;
                Console.WriteLine();
                Console.WriteLine("son eleman da silindi");
                Console.WriteLine();
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
                Console.WriteLine();
                Console.WriteLine("Sondaki eleman silindi");
                Console.WriteLine();
            }
        }
        public void AradanSil(int indis)
        {
            if (head == null)
            {
                Console.WriteLine();    
                Console.WriteLine("Liste boş");    
            }
            else if (head.next == null && indis == 0)
            {
                head = tail = null;
                Console.WriteLine();
                Console.WriteLine("Listede kalan son eleman da silindi");
                Console.WriteLine();
            }
            else if (head.next != null && indis == 0)
            {
                BastanSil();
                Console.WriteLine();
                Console.WriteLine("Eleman silindi");
                Console.WriteLine();
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                int i = 0;
                while (temp.next != null) 
                {
                    if(indis == i)
                    {
                        temp2.next = temp.next;
                        temp.next.prev = temp2;
                        Console.WriteLine();
                        Console.WriteLine("Aradan Eleman silindi");
                        Console.WriteLine();
                        i++;
                        break;
                    }
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if(indis == i)
                {
                    SondanSil();
                    Console.WriteLine($"Sondaki elemanı silindi");
                }
            }
        }
    }
}
