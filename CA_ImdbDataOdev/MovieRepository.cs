using CA_ImdbDataOdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_ImdbDataOdev
{
    internal class MovieRepository
    {
        IMDBDataContext db = new IMDBDataContext();
        public List<Movie> MovieList()
        {
            return db.Movies.ToList();
        }
        public void Listele()
        {
            foreach (var movie in db.Movies.ToList())
            {
                Console.WriteLine(movie.Title);
            }
        }
        public void YilaGoreListe()
        {
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
        }
        public void PuanaGoreListe()
        {
            
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
        }
        public void KelimeArama()
        {
            
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
        }
        public void TurArama()
        {
            string gelenTur = Console.ReadLine();
            var result4 = from m in db.Movies
                          join mg in db.MovieGenres on m.Id equals mg.MovieId
                          join g in db.Genres on mg.GenreId equals g.Id
                          select new
                          {
                              Tur = g.Name,
                              Title = m.Title
                          };
            foreach (var item in result4.Where(x => x.Tur == gelenTur))
            {
                Console.WriteLine($"Film adı:{item.Title} Tür:{item.Title}");
            }
        }
        public void Rastgele()
        {
            Random rnd = new Random();
            int rastgele = rnd.Next(1, 1001);
            foreach (Movie item in db.Movies.Where(x=>x.Id==rastgele))
            {
                Console.WriteLine($"Film adı:{item.Title}");
            }
        }
        public void PuanaGoreRastgeleFilm()
        {
            Random rnd2 = new Random();
            int rastgele2 = rnd2.Next(1,101);
            Console.WriteLine("Puan giriniz(1 ile 100 arasında):");
            int puan = Convert.ToInt32(Console.ReadLine());
            foreach(Movie item in db.Movies.Where(x=>x.Id == rastgele2 && x.Rating>puan))
            {
                Console.WriteLine($"Film adı:{item.Title} Puan:{item.Rating}");
            }
        }


    }
}
