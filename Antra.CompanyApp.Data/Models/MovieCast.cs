using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.CompanyApp.Data.Models
{
    public class MovieCast
    {
        public int MovieId { get; set; }
        public int CastId { get; set; }
        public string Character { get; set; }
    }
}
