using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repositories;
using Antra.CompanyApp.Data.Models;
using System.Threading.Tasks;
using Antra.CompanyApp.Utilities;

namespace Antra.CompanyApp.Service
{
    public class ManageMovie
    {
        private readonly MovieRepository movieRepository;
        public ManageMovie()
        {
            movieRepository = new MovieRepository();
        }
        public async Task DeleteMovie()
        {
            Console.Write("Enter the ID of the movie to be deleted = ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = await movieRepository.DeleteAsync(id);
            if (result > 0)
                Console.WriteLine("Movie Successfully Removed.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task InsertMovie()
        {
            Movie m = new Movie();
            Console.Write("Enter Title = ");
            m.Title = Console.ReadLine();
            Console.Write("Enter Overview = ");
            m.Overview = Console.ReadLine();
            Console.Write("Enter Budget = ");
            m.Budget = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Revenue = ");
            m.Revenue = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Imdb Url = ");
            m.ImdbUrl = Console.ReadLine();
            Console.Write("Enter Tmdb Url = ");
            m.TmdbUrl = Console.ReadLine();
            Console.Write("Enter Poster Url = ");
            m.PosterUrl = Console.ReadLine();
            Console.Write("Enter Backdrop Url = ");
            m.BackdropUrl = Console.ReadLine();
            Console.Write("Enter Original Language = ");
            m.OriginalLanguage = Console.ReadLine();
            Console.Write("Enter Release Date = ");
            m.ReleaseDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Run Time = ");
            m.RunTime = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price = ");
            m.Price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Created Date = ");
            m.CreatedDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Updated Date = ");
            m.UpdatedDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Person Who Updated = ");
            m.UpdatedBy = Console.ReadLine();
            Console.Write("Enter Person Who Created = ");
            m.CreatedBy = Console.ReadLine();
            var result = await movieRepository.InsertAsync(m);
            if (result > 0)
                Console.WriteLine("Movie Added Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task UpdateMovie()
        {
            Movie m = new Movie();
            Console.Write("Enter ID = ");
            m.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Title = ");
            m.Title = Console.ReadLine();
            Console.Write("Enter Overview = ");
            m.Overview = Console.ReadLine();
            Console.Write("Enter Budget = ");
            m.Budget = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Revenue = ");
            m.Revenue = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Imdb Url = ");
            m.ImdbUrl = Console.ReadLine();
            Console.Write("Enter Tmdb Url = ");
            m.TmdbUrl = Console.ReadLine();
            Console.Write("Enter Poster Url = ");
            m.PosterUrl = Console.ReadLine();
            Console.Write("Enter Backdrop Url = ");
            m.BackdropUrl = Console.ReadLine();
            Console.Write("Enter Original Language = ");
            m.OriginalLanguage = Console.ReadLine();
            Console.Write("Enter Release Date = ");
            m.ReleaseDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Run Time = ");
            m.RunTime = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price = ");
            m.Price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Created Date = ");
            m.CreatedDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Updated Date = ");
            m.UpdatedDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Person Who Updated = ");
            m.UpdatedBy = Console.ReadLine();
            Console.Write("Enter Person Who Created = ");
            m.CreatedBy = Console.ReadLine();
            var result = await movieRepository.UpdataAsync(m);
            if (result > 0)
                Console.WriteLine("Movie Updated Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task PrintAll()
        {
            var movieCollection = await movieRepository.GetAllAsync();
            foreach (var item in movieCollection)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \t {8} \t {9} \t {10} \t {11} \t {12} \t {13} \t {14} \t {15} \t {16} \t {17}",
                    item.Id, item.Title, item.Overview, item.Tagline, item.Budget, item.Revenue, item.ImdbUrl, item.TmdbUrl, item.PosterUrl, item.BackdropUrl, item.OriginalLanguage, item.ReleaseDate, item.RunTime, item.Price, item.CreatedDate, item.UpdatedDate, item.UpdatedBy, item.CreatedBy);
            }
        }
        public async Task PrintById()
        {
            Console.WriteLine("Enter the ID of movie = ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = await movieRepository.GetByIdAsync(id);
            Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \t {8} \t {9} \t {10} \t {11} \t {12} \t {13} \t {14} \t {15} \t {16} \t {17}",
                    item.Id, item.Title, item.Overview, item.Tagline, item.Budget, item.Revenue, item.ImdbUrl, item.TmdbUrl, item.PosterUrl, item.BackdropUrl, item.OriginalLanguage, item.ReleaseDate, item.RunTime, item.Price, item.CreatedDate, item.UpdatedDate, item.UpdatedBy, item.CreatedBy);

        }
        public async void Run()
        {
            int choice = 0;
            do
            {
                MenuSelectOption m = new MenuSelectOption();
                choice = m.Show();
                switch (choice)
                {
                    case (int)MenuOptions.Options.Insert:
                        await InsertMovie();
                        break;
                    case (int)MenuOptions.Options.Delete:
                        await DeleteMovie();
                        break;
                    case (int)MenuOptions.Options.Update:
                        await UpdateMovie();
                        break;
                    case (int)MenuOptions.Options.PrintAll:
                        await PrintAll();
                        break;
                    case (int)MenuOptions.Options.PrintById:
                        await PrintById();
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                Console.WriteLine("Press Enter to continue.......");
                Console.ReadLine();
                Console.Clear();
            } while (choice != (int)MenuOptions.Options.Exit);
        }
    }
}
