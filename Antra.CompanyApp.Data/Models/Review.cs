using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.CompanyApp.Data.Models
{
    public class Review
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }
    }
}
