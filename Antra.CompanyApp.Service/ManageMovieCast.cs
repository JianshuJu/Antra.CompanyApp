using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repositories;
using Antra.CompanyApp.Data.Models;
using System.Threading.Tasks;
using Antra.CompanyApp.Utilities;

namespace Antra.CompanyApp.Service
{
    public class ManageMovieCast
    {
        private readonly MovieCastRepository movieCastRepository;
        public ManageMovieCast()
        {
            movieCastRepository = new MovieCastRepository();
        }
        public async Task DeleteMovie()
        {
            Console.Write("Enter the Movie Id of the MovieCast to be deleted = ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Cast Id of the MovieCast to be deleted = ");
            int castId = Convert.ToInt32(Console.ReadLine());
            var result = await movieCastRepository.DeleteAsync(movieId, castId);
            if (result > 0)
                Console.WriteLine("MovieCast Successfully Removed.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task InsertMovie()
        {
            MovieCast mc = new MovieCast();
            Console.Write("Enter Character = ");
            mc.Character = Console.ReadLine();
            var result = await movieCastRepository.InsertAsync(mc);
            if (result > 0)
                Console.WriteLine("MovieCast Added Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task UpdateMovie()
        {
            MovieCast mc = new MovieCast();
            Console.Write("Enter Movie Id = ");
            mc.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Cast Id = ");
            mc.CastId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name = ");
            mc.Character = Console.ReadLine();
            var result = await movieCastRepository.UpdataAsync(mc);
            if (result > 0)
                Console.WriteLine("MovieCast Updated Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task PrintAll()
        {
            var movieCollection = await movieCastRepository.GetAllAsync();
            foreach (var item in movieCollection)
            {
                Console.WriteLine("{0} \t {1} \t {2}",
                    item.MovieId, item.CastId, item.Character);
            }
        }
        public async Task PrintById()
        {
            Console.WriteLine("Enter the Movie Id of MovieCast = ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Cast Id of MovieCast = ");
            int castId = Convert.ToInt32(Console.ReadLine());
            var item = await movieCastRepository.GetByIdAsync(movieId, castId);
            Console.WriteLine("{0} \t {1} \t {2}",
                    item.MovieId, item.CastId, item.Character);
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
