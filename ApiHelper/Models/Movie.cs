using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper.Models
{
    public class Movie
    {
        public int id { get; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string director { get; set; }
        public int rating { get; set; }
        public bool rented { get;}
        public List<Review> reviews { get; }

        public List<Category> categories { set; get; } = new List<Category>();

        public enum Category { Comedy, Thriller, Drama };
        public int until { get; }
        public int que { get; }
    }
}
