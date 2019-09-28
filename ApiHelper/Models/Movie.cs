using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper.Models
{
    public class Movie
    {
        int id { get; }
        string title { get; set; }
        string description { get; set; }
        string image { get; set; }
        string director { get; set; }
        int  rating { get; set; }
        bool rented { get;}
        List<Review> reviews { get; }
        enum categories { Comedy, Thriller, Drama };
        int until { get; }
        int que { get; }
    }
}
