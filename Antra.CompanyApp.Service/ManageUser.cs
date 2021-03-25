using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repositories;
using Antra.CompanyApp.Data.Models;
using System.Threading.Tasks;
using Antra.CompanyApp.Utilities;

namespace Antra.CompanyApp.Service
{
    public class ManageUser
    {
        private readonly UserRepository userRepository;
        public ManageUser()
        {
            userRepository = new UserRepository();
        }
        public async Task DeleteMovie()
        {
            Console.Write("Enter the ID of the user to be deleted = ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = await userRepository.DeleteAsync(id);
            if (result > 0)
                Console.WriteLine("User Successfully Removed.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task InsertMovie()
        {
            User u = new User();
            Console.Write("Enter Email = ");
            u.Email = Console.ReadLine();
            Console.Write("Enter if Two Factors are enabled = ");
            u.TwoFactorEnabled =Convert.ToBoolean( Console.ReadLine());
            Console.Write("Enter First Name = ");
            u.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name = ");
            u.LastName = Console.ReadLine();
            Console.Write("Enter Date of Birth = ");
            u.DateOfBirth =Convert.ToDateTime( Console.ReadLine());
            Console.Write("Enter Hashed Password = ");
            u.HashedPassword = Console.ReadLine();
            Console.Write("Enter Salt = ");
            u.Salt = Console.ReadLine();
            Console.Write("Enter Phone Number = ");
            u.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Lockout End Date = ");
            u.LockoutEndDate =Convert.ToDateTime( Console.ReadLine());
            Console.Write("Enter Last Login Datetime = ");
            u.LastLoginDateTime = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter if it is Locked = ");
            u.IsLocked = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Enter Times of Failed Access = ");
            u.AccessFailedCount = Convert.ToInt32(Console.ReadLine());
            
            var result = await userRepository.InsertAsync(u);
            if (result > 0)
                Console.WriteLine("User Added Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task UpdateMovie()
        {
            User u = new User();
            Console.Write("Enter ID = ");
            u.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Email = ");
            u.Email = Console.ReadLine();
            Console.Write("Enter if Two Factors are enabled = ");
            u.TwoFactorEnabled = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Enter First Name = ");
            u.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name = ");
            u.LastName = Console.ReadLine();
            Console.Write("Enter Date of Birth = ");
            u.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Hashed Password = ");
            u.HashedPassword = Console.ReadLine();
            Console.Write("Enter Salt = ");
            u.Salt = Console.ReadLine();
            Console.Write("Enter Phone Number = ");
            u.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Lockout End Date = ");
            u.LockoutEndDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Last Login Datetime = ");
            u.LastLoginDateTime = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter if it is Locked = ");
            u.IsLocked = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Enter Times of Failed Access = ");
            u.AccessFailedCount = Convert.ToInt32(Console.ReadLine());
            var result = await userRepository.UpdataAsync(u);
            if (result > 0)
                Console.WriteLine("User Updated Successfully.");
            else
                Console.WriteLine("Some Error Happened.");
        }
        public async Task PrintAll()
        {
            var movieCollection = await userRepository.GetAllAsync();
            foreach (var item in movieCollection)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \t {8} \t {9} \t {10} \t {11} \t {12}",
                    item.Id, item.Email, item.TwoFactorEnabled, item.FirstName, item.LastName, item.DateOfBirth, item.HashedPassword, item.Salt, item.PhoneNumber, item.LockoutEndDate, item.LastLoginDateTime, item.IsLocked, item.AccessFailedCount);
            }
        }
        public async Task PrintById()
        {
            Console.WriteLine("Enter the ID of movie = ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = await userRepository.GetByIdAsync(id);
            Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \t {8} \t {9} \t {10} \t {11} \t {12}",
                    item.Id, item.Email, item.TwoFactorEnabled, item.FirstName, item.LastName, item.DateOfBirth, item.HashedPassword, item.Salt, item.PhoneNumber, item.LockoutEndDate, item.LastLoginDateTime, item.IsLocked, item.AccessFailedCount);

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
