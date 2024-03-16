namespace Linked_list_eleman_ekleme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste listem = new Liste();

            listem.sonaEkle(15);
            listem.sonaEkle(25);
            listem.sonaEkle(35);
            listem.sonaEkle(45);
            listem.yazdir();
            listem.basaEkle(5);
            listem.basaEkle(95);
            listem.basaEkle(31);
            listem.yazdir();

            Console.ReadKey();
        }
    }
}
