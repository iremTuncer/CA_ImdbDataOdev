using System;
using System.Linq;
using CA_ImdbDataOdev.Models;

namespace CA_ImdbDataOdev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMDBDataContext db = new IMDBDataContext();

            foreach (var movie in db.Movies.ToList())
            {
                Console.WriteLine(movie.Title);
            }
            //Yıl değerinden sonra//
            Console.WriteLine("Hangi yıldan sonraki filmleri listelemek istersiniz:");
            int gelenYıl = Convert.ToInt32(Console.ReadLine());
            var result = from m in db.Movies
                         where m.Year > gelenYıl
                         select new
                         {
                             m.Year,
                             m.Title
                         };
            foreach (var item in result.ToList())
            {
                Console.WriteLine(item);
            }
            //Puan değerinden sonra//
            Console.WriteLine("Kaç puan ve üzeri filmleri listelemek istersiniz?");
            int gelenPuan = Convert.ToInt32(Console.ReadLine());
            var result2 = db.Movies.Where(x => x.Rating > gelenPuan).Select(x => new
            {
                x.Rating,
                x.Title
            }).ToList();

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            //Alınan değer açıklama bölümünde bulunan filmler//
            Console.WriteLine("Hangi kelimeyi içeren filmleri listelemek istersiniz?");
            string gelenKelime = Console.ReadLine();
            var result3 = db.Movies.Where(x => x.Description.Contains(gelenKelime)).Select(x => new
            {
                x.Title,
                x.Description
            }).ToList();
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }
            //Türe göre filmler//
            Console.WriteLine("Hangi tür filmleri listelemek istersiniz?");
            string gelenTur = Console.ReadLine();
            var result4 = db.Genres.Where(x => x.Name.Contains(gelenKelime)).ToList();
            foreach (var item in result4.ToList())
            {
                Console.WriteLine(item.Name);
            }
            //Rastgele film//
            Console.WriteLine("Rastgele bir film getirmek için bir sayı girin:");
            int gelenSayi = Convert.ToInt32(Console.ReadLine());
            var result5 = db.Movies.Where(x=> x.Id == gelenSayi).Select(x => new 
            {
                x.Id, 
                x.Title
            }).ToList();
            foreach (var item in result5)
            {
                Console.WriteLine(item);
            }

           







        }
    }
}
