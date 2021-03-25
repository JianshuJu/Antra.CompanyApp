using System;
using Antra.CompanyApp.UI;

namespace Antra.CompanyApp
{
    class MovieShopProgram
    {
        static void Main(string[] args)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDashboard();
            Console.ReadLine();
        }
    }
}
