using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_tek_yönlü_doğrusal_lista_eleman_silme
{
    internal class Liste
    {
        public Node? head;

        public Liste()
        {
            head = null;
        }

        public void sonaEkle( int data )
        {
            Node eleman = new Node(data);
            if( head == null ) 
            {
                head = eleman;
                Console.WriteLine($"İlk düğüm oluşturuldu: {data}");
            }
            else
            {
                Node temp = head;
                while( temp.next != null ) 
                {
                    temp = temp.next;
                }
                temp.next = eleman;
                Console.WriteLine($"En sona {data} elemanı eklendi ");
            }
        }
        public void basaEkle( int data )
        {
            Node eleman = new Node(data);   
            if( head == null )
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
            if ( head == null )
                Console.WriteLine("Liste boş");
            else
            {
                Node temp = head;
                while( temp.next != null ) 
                {
                    Console.Write($"{temp.data} --> ");
                    temp = temp.next;
                }
                Console.Write($"{temp.data} --> finish");
                Console.WriteLine();
                Console.WriteLine();

            }
        }

        public void bastanSil()
        {
            if( head == null )
                Console.WriteLine("Liste boş");
            else 
            {
                head = head.next;
                Console.WriteLine("Baştan eleman silindi");
            }
            
        }
        public void sondanSil()
        {
            if( head == null )
            {
                Console.WriteLine("Liste boş");
            }
            else if( head.next == null)
            {
                head = null;
                Console.WriteLine("En sona kalan elaman da silindi");
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                while( temp.next != null ) 
                {
                    temp2 = temp;
                    temp = temp.next;
                }
                temp2.next = null;
                Console.WriteLine("sondaki düğüm silindi");
            }

        }

    }
}
