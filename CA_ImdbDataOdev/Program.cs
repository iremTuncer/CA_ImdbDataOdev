using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CA_ImdbDataOdev.Models;
using System.Collections.Generic;

namespace CA_ImdbDataOdev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieRepository moviesrepository = new MovieRepository();
            while(true)
            {
                Console.WriteLine($"1-Film Listeleme \n2-Seçilen yıla göre listeleme \n3-Seçilen puana göre listeleme \n4-Seçilen kelimeye göre listeleme \n5-Seçilen türe göre listeleme \n6-Rastgele film seçimi \n7-Puan aralığında rastgele film getirme ");
                int gelen =int.Parse(Console.ReadLine());

                switch(gelen)
                {
                    case 1:
                        moviesrepository.Listele();
                        break;
                    case 2:
                        Console.WriteLine("Hangi yıldan sonraki filmleri listelemek istersiniz:");
                        moviesrepository.YilaGoreListe();
                        break;
                    case 3:
                        Console.WriteLine("Kaç puan ve üzeri filmleri listelemek istersiniz?");
                        moviesrepository.PuanaGoreListe();
                        break;
                    case 4:
                        Console.WriteLine("Hangi kelimeyi içeren filmleri listelemek istersiniz?");
                        moviesrepository.KelimeArama();
                        break;
                    case 5:
                        Console.WriteLine("Hangi tür filmleri listelemek istersiniz?");
                        moviesrepository.TurArama();
                        break;
                    case 6:
                        moviesrepository.Rastgele();
                        break;
                    case 7:
                        moviesrepository.PuanaGoreRastgeleFilm();
                        break;
                    default:
                        break;
                }
            }

           






            

            
            
            
            
            
           
            
            

           







        }
    }
}
