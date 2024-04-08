using System.ComponentModel.Design;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackYapisi stk = new StackYapisi();
            int sayi = 0;

            int secim = menu();
            while (secim != 0)
            {
                switch ( secim)
                {
                    case 1:
                        Console.Write("sayi = ");sayi = int.Parse(Console.ReadLine());  
                        stk.push(sayi);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        sayi = stk.pop(); break;
                    case 3:
                        Console.Clear();
                        stk.print();
                        break;
                    case 4:
                        Console.Clear();
                        stk.topPrint();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Gecerli bir sayi giriniz");
                        break;
                }
                secim = menu();
            }
            Console.ReadKey();
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("---------------------");
            Console.WriteLine("1- push");
            Console.WriteLine("2- pop");
            Console.WriteLine("3- yazdir");
            Console.WriteLine("4- top elemani yazdir");
            Console.WriteLine("5- Ekranı Temizle");
            Console.WriteLine("0- çıkış");
            Console.WriteLine("---------------------");
            Console.Write("Seciminiz: ");
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

    class StackYapisi
    {
        Node top;
        public StackYapisi()
        {
            top = null;
        }
        public void push( int data )
        {
            Node eleman = new Node(data);
            if (top == null)
            {
                top = eleman;
                Console.WriteLine("\nStack oluşturuldu ve ilk eleman eklendi\n");
            }
            else
            {
                eleman.next = top;
                top = eleman;
                Console.WriteLine("\nEleman eklendi\n");
            }

        }
        public int pop()
        {
            if (top == null)
            {
                Console.WriteLine("\nStack boş\n");
                return -1;
            }
            else
            {
                int sayi = top.data;
                top = top.next;
                Console.WriteLine("\n"+sayi + " stackten çıkartıldı\n");
                return sayi;
            }
        }
        public void print()
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş");
            }
            else
            {
                Node temp = top;
                while (temp.next != null)
                {
                    Console.WriteLine(temp.data);
                    temp = temp.next;
                }
                Console.WriteLine(temp.data);
                Console.WriteLine("||\n||");
                Console.WriteLine("null\n");
            }
        }
        public void topPrint()
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş");
            }
            else
            {
                Console.WriteLine("top elemanı: " + top.data);
            }
        }
    }
}
