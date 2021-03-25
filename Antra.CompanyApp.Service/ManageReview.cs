using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repositories;
using Antra.CompanyApp.Data.Models;
using System.Threading.Tasks;
using Antra.CompanyApp.Utilities;

namespace Antra.CompanyApp.Service
{
    public class ManageReview
    {
        private readonly ReviewRepository reviewRepository;
        public ManageReview()
        {
            reviewRepository = new ReviewRepository();
        }
        public async Task DeleteMovie()
        {
            Console.Write("Enter the Movie Id of the MovieCast to be deleted = ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the User Id of the MovieCast to be deleted = ");
            int userId = Convert.ToInt32(Console.ReadLine());
            var result = await reviewRepository.DeleteAsync(movieId, userId);
            if (result > 0)
                Console.WriteLine("Review Successfully Removed.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task InsertMovie()
        {
            Review r = new Review();
            Console.Write("Enter the Movie Id = ");
            r.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the User Id = ");
            r.UserId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Rating = ");
            r.Rating =Convert.ToDecimal( Console.ReadLine());
            Console.Write("Enter Review Text = ");
            r.ReviewText = Console.ReadLine();
            var result = await reviewRepository.InsertAsync(r);
            if (result > 0)
                Console.WriteLine("Review Added Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task UpdateMovie()
        {
            Review r = new Review();
            Console.Write("Enter the Movie Id = ");
            r.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the User Id = ");
            r.UserId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Rating = ");
            r.Rating = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Review Text = ");
            r.ReviewText = Console.ReadLine();         
            var result = await reviewRepository.UpdataAsync(r);
            if (result > 0)
                Console.WriteLine("Review Updated Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task PrintAll()
        {
            var movieCollection = await reviewRepository.GetAllAsync();
            foreach (var item in movieCollection)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3}",
                    item.MovieId, item.UserId, item.Rating, item.ReviewText);
            }
        }
        public async Task PrintById()
        {
            Console.WriteLine("Enter the Movie Id of MovieCast = ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the User Id of MovieCast = ");
            int userId = Convert.ToInt32(Console.ReadLine());
            var item = await reviewRepository.GetByIdAsync(movieId, userId);
            Console.WriteLine("{0} \t {1} \t {2} \t {3}",
                    item.MovieId, item.UserId, item.Rating, item.ReviewText);
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
