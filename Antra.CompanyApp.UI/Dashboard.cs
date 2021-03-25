using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Utilities;
using Antra.CompanyApp.Service;

namespace Antra.CompanyApp.UI
{
    public class Dashboard
    {
        public void ShowDashboard()
        {
            int entity = 0;
            do
            {               
                MenuSelectEntity menuSelectEntity = new MenuSelectEntity();
                entity = menuSelectEntity.Show();
                switch (entity)
                {
                    case (int)MenuOptions.Entities.Movie:
                        ManageMovie manageMovie = new ManageMovie();
                        manageMovie.Run();
                        break;
                    case (int)MenuOptions.Entities.User:
                        ManageUser manageUser = new ManageUser();
                        manageUser.Run();
                        break;
                    case (int)MenuOptions.Entities.Genre:
                        ManageGenre manageGenre = new ManageGenre();
                        manageGenre.Run();
                        break;
                    case (int)MenuOptions.Entities.MovieCast:
                        ManageMovieCast manageMovieCast = new ManageMovieCast();
                        manageMovieCast.Run();
                        break;
                    case (int)MenuOptions.Entities.MovieGenre:
                        ManageMovieGenre manageMovieGenre = new ManageMovieGenre();
                        manageMovieGenre.Run();
                        break;
                    case (int)MenuOptions.Entities.Review:
                        ManageReview manageReview = new ManageReview();
                        manageReview.Run();
                        break;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;

                }
                Console.WriteLine("Press Enter to continue ...");
                Console.ReadLine();
                Console.Clear();
            }
            while (entity != (int)MenuOptions.Entities.Exit);
        }
    }
}
