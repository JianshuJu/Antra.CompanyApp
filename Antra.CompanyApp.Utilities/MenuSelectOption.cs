using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.CompanyApp.Utilities
{
    public class MenuSelectOption
    {
        string[] names = Enum.GetNames(typeof(MenuOptions.Options));
        int[] values = (int[])Enum.GetValues(typeof(MenuOptions.Options));
        public int Show()
        {
            int length = names.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Enter {0} for {1}", names[i], values[i]);
            }
            Console.Write("Please Enter Your Choice => ");
            Console.Clear();
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
    }
}
