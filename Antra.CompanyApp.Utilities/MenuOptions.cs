using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.CompanyApp.Utilities
{
    public class MenuOptions
    {
        public enum Options
        {
            Insert = 1,
            Delete,
            Update,
            PrintAll,
            PrintById,
            Exit

        }
        public enum Entities
        {
            Movie = 1,
            User,
            Cast,
            Genre,            
            MovieCast,
            MovieGenre,
            Review,
            Exit
        }
    }
}
