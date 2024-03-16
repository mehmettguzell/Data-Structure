namespace _2_tek_yönlü_doğrusal_lista_eleman_silme
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
            listem.bastanSil();
            listem.yazdir();
            listem.sondanSil();
            listem.yazdir();
            listem.sondanSil();
            listem.sondanSil();
            listem.sondanSil();
            listem.yazdir();
            listem.sondanSil();
            listem.sondanSil();
            listem.sondanSil();
            listem.sondanSil();
            listem.yazdir();


            Console.ReadKey();  
        }
    }
}
