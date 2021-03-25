using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repositories;
using Antra.CompanyApp.Data.Models;
using System.Threading.Tasks;
using Antra.CompanyApp.Utilities;


namespace Antra.CompanyApp.Service
{
    public class ManageGenre
    {
        private readonly GenreRepository genreRepository;
        public ManageGenre()
        {
            genreRepository = new GenreRepository();
        }
        public async Task DeleteMovie()
        {
            Console.Write("Enter the ID of the genre to be deleted = ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = await genreRepository.DeleteAsync(id);
            if (result > 0)
                Console.WriteLine("Genre Successfully Removed.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task InsertMovie()
        {
            Genre g = new Genre();
            Console.Write("Enter Name = ");
            g.Name = Console.ReadLine();            
            var result = await genreRepository.InsertAsync(g);
            if (result > 0)
                Console.WriteLine("Genre Added Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task UpdateMovie()
        {
            Genre g = new Genre();
            Console.Write("Enter ID = ");
            g.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name = ");
            g.Name = Console.ReadLine();            
            var result = await genreRepository.UpdataAsync(g);
            if (result > 0)
                Console.WriteLine("Genre Updated Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task PrintAll()
        {
            var movieCollection = await genreRepository.GetAllAsync();
            foreach (var item in movieCollection)
            {
                Console.WriteLine("{0} \t {1}",
                    item.Id, item.Name);
            }
        }
        public async Task PrintById()
        {
            Console.WriteLine("Enter the ID of genre = ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = await genreRepository.GetByIdAsync(id);
            Console.WriteLine("{0} \t {1}",
                    item.Id, item.Name);
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
