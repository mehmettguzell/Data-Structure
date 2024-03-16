using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_list_eleman_ekleme
{
    internal class Liste
    {
        public Node? head;

        public Liste()
        {
            head = null;
        }

        public void sonaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = eleman;
                Console.WriteLine($"İlk düğüm oluşturuldu: {data}");
            }
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = eleman;
                Console.WriteLine($"En sona {data} elemanı eklendi ");
            }
        }
        public void basaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = eleman;
            }
            else
            {
                eleman.next = head;
                head = eleman;
                Console.WriteLine($"Başa {data} elemanı eklendi");
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
                Console.Write($"{temp.data} --> finish");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}

