using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadingCorp.Models
{
    public class BookViewModel
    {
        public int Book_id { get; set; }
        public string Book_name { get; set; }
        public string Author { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

    }
}