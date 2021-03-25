using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.CompanyApp.UI.Utilities
{
    public class MenuSelectEntity
    {
        string[] names = Enum.GetNames(typeof(MenuOptions.Entities));
        int[] values = (int[])Enum.GetValues(typeof(MenuOptions.Entities));
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
