using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repositories;
using Antra.CompanyApp.Data.Models;
using System.Threading.Tasks;
using Antra.CompanyApp.Utilities;

namespace Antra.CompanyApp.Service
{
    public class ManageMovieGenre
    {
        private readonly MovieGenreRepository movieGenreRepository;
        public ManageMovieGenre()
        {
            movieGenreRepository = new MovieGenreRepository();
        }
        public async Task DeleteMovie()
        {
            Console.Write("Enter the Movie Id of the MovieGenre to be deleted = ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Genre Id of the MovieGenre to be deleted = ");
            int genreId = Convert.ToInt32(Console.ReadLine());
            var result = await movieGenreRepository.DeleteAsync(movieId, genreId);
            if (result > 0)
                Console.WriteLine("MovieGenre Successfully Removed.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task InsertMovie()
        {
            MovieGenre mg = new MovieGenre();
            Console.Write("Enter Movie Id = ");
            mg.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Genre Id = ");
            mg.GenreId = Convert.ToInt32(Console.ReadLine());
            var result = await movieGenreRepository.InsertAsync(mg);
            if (result > 0)
                Console.WriteLine("MovieGenre Added Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        //public async Task UpdateMovie()
        //{
        //    MovieGenre mg = new MovieGenre();
        //    Console.Write("Enter Movie Id = ");
        //    mg.MovieId = Convert.ToInt32(Console.ReadLine());
        //    Console.Write("Enter Genre Id = ");
        //    mg.GenreId = Convert.ToInt32(Console.ReadLine());
        //    Console.Write("Enter Name = ");
        //    mg.Character = Console.ReadLine();
        //    var result = await movieGenreRepository.UpdataAsync(mg);
        //    if (result > 0)
        //        Console.WriteLine("MovieGenre Updated Successfully.");
        //    else
        //        Console.WriteLine("Some Error Happened.");
        //}
        public async Task PrintAll()
        {
            var movieCollection = await movieGenreRepository.GetAllAsync();
            foreach (var item in movieCollection)
            {
                Console.WriteLine("{0} \t {1}",
                    item.MovieId, item.GenreId);
            }
        }
        public async Task PrintById()
        {
            Console.WriteLine("Enter the Movie Id of MovieCast = ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Genre Id of MovieCast = ");
            int genreId = Convert.ToInt32(Console.ReadLine());
            var item = await movieGenreRepository.GetByIdAsync(movieId, genreId);
            Console.WriteLine("{0} \t {1}",
                    item.MovieId, item.GenreId);
        }
        public async void Run()
        {
            int choice = 0;
            do
            {
                MenuSelectOption u = new MenuSelectOption();
                choice = u.Show();
                switch (choice)
                {
                    case (int)MenuOptions.Options.Insert:
                        await InsertMovie();
                        break;
                    case (int)MenuOptions.Options.Delete:
                        await DeleteMovie();
                        break;
                    //case (int)MenuOptions.Options.Update:
                    //    await UpdateMovie();
                    //    break;
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
