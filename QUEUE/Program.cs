using System.Security.Cryptography.X509Certificates;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueueYapisi que = new QueueYapisi();
            int sayi;
            int secim = menu();

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("Sayı:");sayi = int.Parse(Console.ReadLine());
                        que.enQueue(sayi);
                        break;
                    case 2:
                        que.deQueue();
                        break;
                    case 3:
                        Console.Clear();

                        if (que.peek() == -1)
                            break;
                        Console.WriteLine("Queue ye ilk giren eleman: " + que.peek());
                        break;
                    case 4:
                        Console.Clear();
                        que.print();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        if (que.isEmpty())
                        {
                            Console.Clear();
                            Console.WriteLine("QUEUE boş");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("QUEUE boş değil");
                        }
                        break;
                    case 7:
                        Console.Clear();    
                        Console.WriteLine("Eleman sayısı: " + que.size());
                        break;
                    case 8:
                        Console.Clear();
                        que.clear();
                        break;
                    case 0:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("!!!Hatalı bir secim yaptınız!!!");
                        break;
                }
                secim = menu();
            }

            Console.ReadKey();
        }

        private static int menu()
        {
            int secim = 0;
            Console.WriteLine("------------------");
            Console.WriteLine("1- enQueue");
            Console.WriteLine("2- deQueue");
            Console.WriteLine("3- peek");
            Console.WriteLine("4- Print");
            Console.WriteLine("5- Ekranı temizle");
            Console.WriteLine("6- Queue boş mu?");
            Console.WriteLine("7- Elaman Sayısı");
            Console.WriteLine("8- Queue'yi temizle");
            Console.WriteLine("0- QUIT ");
            Console.WriteLine("------------------");
            Console.Write("Seciminiz: ");secim = int.Parse(Console.ReadLine());
                
            return secim;
        }
    }
    class Node
    {
        public int data;
        public Node next;
        public Node( int data )
        {
            this.data = data;
            next = null;
        }
    }
    class QueueYapisi
    {
        Node front;
        Node rear;
        public QueueYapisi()
        {
            this.front = this.rear = null;
        }

        public void enQueue(int data)
        {
            Node eleman = new Node(data);
            if (front == null)
            {
                front = rear = eleman;
                Console.WriteLine("\nListe oluşturuldu ve eleman eklendi\n");
            }
            else
            {
                rear.next = eleman;
                rear = eleman;
                Console.WriteLine("\nQUEUE ye eleman eklendi\n");
            }
        }
        public void deQueue()
        {
            if (front == null)
            {
                Console.WriteLine("QUEUE 'de silinecek eleman yok");
            }
            else
            {
                int data = front.data;
                front = front.next;
                Console.WriteLine("\n" + data + " sayisi QUEUE den silindi");
            }
        }
        public void print()
        {
            if (front == null)
            {
                Console.WriteLine("Liste boş");
            }
            else
            {
                Node temp = front;
                Console.Write("Front ->\t");
                while (temp.next!= null)
                {
                    Console.Write(temp.data + " <- ");
                    temp = temp.next;
                }
                Console.Write(temp.data + "\t\t<- Rear\n ");

            }

        }
        public bool isEmpty()
        {
            return front == null;
        }
        public int size()
        {
            int count = 0;
            Node temp = front;
            while(temp != null)
            {
                count++;
                temp = temp.next;
            }

            return count;
        }
        public int peek()
        {
            if (front == null)
            {
                Console.WriteLine("Kuyruk boş");
                return -1;
            }
                return front.data;
        }
        public void clear()
        {
            front = rear = null;
            Console.WriteLine("Kuyruk temizlendi");
        }

    }
}
