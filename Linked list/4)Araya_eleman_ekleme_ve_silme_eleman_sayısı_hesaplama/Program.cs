namespace Araya_eleman_ekleme_ve_silme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste listem = new Liste();
            int secim = menu();
            int sayi;
            int indis;

            while (secim != 0)
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
                        Console.Write("sayı: ");
                        sayi = int.Parse(Console.ReadLine());
                        Console.Write("indis: ");
                        indis = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        listem.arayaEkle(indis, sayi);
                        break;
                    case 4:
                        Console.WriteLine();
                        listem.bastanSil();
                        break;
                    case 5:
                        Console.WriteLine();
                        listem.sondanSil();
                        break;
                    case 6: 
                        Console.WriteLine();
                        Console.Write("indis: ");
                        indis = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        listem.aradanSil(indis);
                        break;
                    case 7:
                        listem.elemanSay();
                        break;

                    default:
                        Console.WriteLine("!!! YANLIŞ SAYI GİRDİNİZ !!!");
                        break;
                }
                //Console.Clear();
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
            Console.WriteLine("3- Araya ekle ");
            Console.WriteLine("4- Baştan sil ");
            Console.WriteLine("5- Sondan sil ");
            Console.WriteLine("6- Aradan sil ");
            Console.WriteLine("7- Eleman sayısı hesapla ");
            Console.WriteLine("0- Çıkış yap ");
            Console.WriteLine("-----------------");
            Console.Write("Seçiminiz: ");
            secim = int.Parse(Console.ReadLine());
            return secim;

        }
    }
    class Liste
    {
        public Node head;
        public Liste() { head = null; }
        public void sonaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
                head = eleman;
            else
            {
                Node temp = head;
                while (temp.next != null)
                    temp = temp.next;
                temp.next = eleman;
                Console.WriteLine($"En sona {data} elemanı eklendi ");

            }
        }
        public void basaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
                head = eleman;
            else
            {
                eleman.next = head;
                head = eleman;
                Console.WriteLine($"Başa {data} elemanı eklendi");
            }
        }
        public void arayaEkle(int indis,int data)
        {
            Node eleman = new Node(data);
            bool sonuc = false;
            if (head == null && indis == 0)
            {
                sonuc = true;
                head = eleman;
                Console.WriteLine("ekleme yapıldı");
            }
            else if (indis == 0)
            {
                basaEkle(data);
                sonuc = true;
            }
            else
            {
                int i = 0;
                Node temp = head;
                Node temp2 = temp;

                while (temp.next != null)
                {
                    if (i == indis)
                    {
                        sonuc = true;
                        temp2.next = eleman;
                        eleman.next = temp;
                        Console.WriteLine("araya eklendi");
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
                    sonuc = true;
                    Console.WriteLine("araya eklendi");
                }
            }
            if (sonuc = false)
            {
                Console.WriteLine("!!! HATALI İNDİS !!!");
            }
        }
        public void yazdir()
        {
            if (head == null)
                Console.WriteLine("Liste boş");
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    Console.Write($"{temp.data} --> ");
                    temp = temp.next;
                }
                Console.Write($"{temp.data} --> Null");
                Console.WriteLine();
                Console.WriteLine();

            }
        }
        public void bastanSil()
        {
            if (head == null)
                Console.WriteLine("liste boş");
            else
            {
                head = head.next;
                Console.WriteLine("Baştan eleman silindi");
            }

        }
        public void sondanSil()
        {
            if (head == null)
                Console.WriteLine("Liste boş");
            else if (head.next == null)
            {
                head = null;
                Console.WriteLine("En sona kalan elaman da silindi");
            }
            else
            {
                Node temp = head;
                Node temp2 = head;
                while (temp.next != null)
                {
                    temp2 = temp;
                    temp = temp.next;
                }
                temp2.next = null;
                Console.WriteLine("sondaki düğüm silindi");
            }
        }
        public void aradanSil( int indis )
        {
            bool sonuc = false;
            if ( head == null ) Console.WriteLine("Liste boş");
            else if( head.next == null && indis == 0)
            {
                head = null; 
                sonuc = true;
                Console.WriteLine("Listede kalan son eleman silindi");
            }
            else if (head.next != null && indis == 0)
            {
                bastanSil();
                sonuc = true;
                Console.WriteLine("Aradan Eleman silindi");
            }
            else
            {
                int i = 0;
                Node temp = head;
                Node temp2 = temp;
                while(temp.next != null)
                {
                    if( indis == i)
                    {
                        temp2.next = temp.next;
                        i++;
                        sonuc = true;
                        Console.WriteLine("Aradan eleman silindi");
                        break;
                    }
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if( indis == i)
                {
                    //sondanSil();
                    temp2.next = null;
                    sonuc = true;
                    Console.WriteLine("Aradan eleman silindi");
                    i++;
                }
            }
            if ( sonuc == false)
            {
                Console.WriteLine( "!!! HARALI İNDİS !!!" );
            }

        }
        public void elemanSay()
        {
            int sayac = 0;
            if( head == null ) Console.WriteLine("eleman sayısı: " + sayac);
            else
            {
                Node temp = head;
                while (temp.next !=null)
                {
                    temp = temp.next;
                    sayac++;
                }
                sayac++;
                Console.WriteLine("eleman sayısı: " + sayac);
            }
        }
    }
    class Node
    {
        public int data;
        public Node next;
        public Node(int data) { this.data = data; next = null; }
    }
}



