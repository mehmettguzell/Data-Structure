using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_tek_yönlü_doğrusal_lista_eleman_silme
{
    internal class Node
    {
        public int data;
        public Node next;

        public Node( int data )
        {
            this.data = data;
            next = null;
        }
    }
}
