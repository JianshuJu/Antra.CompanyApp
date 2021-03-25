using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repositories;
using Antra.CompanyApp.Data.Models;
using System.Threading.Tasks;
using Antra.CompanyApp.Utilities;


namespace Antra.CompanyApp.Service
{
    public class ManageCast
    {
        private readonly CastRepository castRepository;
        public ManageCast()
        {
            castRepository = new CastRepository();
        }
        public async Task DeleteMovie()
        {
            Console.Write("Enter the ID of the cast to be deleted = ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = await castRepository.DeleteAsync(id);
            if (result > 0)
                Console.WriteLine("Cast Successfully Removed.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task InsertMovie()
        {
            Cast c = new Cast();
            Console.Write("Enter Name = ");
            c.Name = Console.ReadLine();
            Console.Write("Enter Gender = ");
            c.Gender = Console.ReadLine();
            Console.Write("Enter Tmdb Url = ");
            c.TmdbUrl = Console.ReadLine();
            Console.Write("Enter Profile Path = ");
            c.ProfilePath = Console.ReadLine();
            Console.Write("Enter Date of Birth = ");           
            var result = await castRepository.InsertAsync(c);
            if (result > 0)
                Console.WriteLine("Cast Added Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task UpdateMovie()
        {
            Cast c = new Cast();
            Console.Write("Enter ID = ");
            c.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name = ");
            c.Name = Console.ReadLine();
            Console.Write("Enter Gender = ");
            c.Gender = Console.ReadLine();
            Console.Write("Enter Tmdb Url = ");
            c.TmdbUrl = Console.ReadLine();
            Console.Write("Enter Profile Path = ");
            c.ProfilePath = Console.ReadLine();
            Console.Write("Enter Date of Birth = ");
            var result = await castRepository.UpdataAsync(c);
            if (result > 0)
                Console.WriteLine("Cast Updated Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task PrintAll()
        {
            var movieCollection = await castRepository.GetAllAsync();
            foreach (var item in movieCollection)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4}",
                    item.Id, item.Name, item.Gender, item.TmdbUrl, item.ProfilePath);
            }
        }
        public async Task PrintById()
        {
            Console.WriteLine("Enter the ID of cast = ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = await castRepository.GetByIdAsync(id);
            Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4}",
                    item.Id, item.Name, item.Gender, item.TmdbUrl, item.ProfilePath);
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
