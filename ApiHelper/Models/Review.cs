using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper.Models
{
    public class Review
    {
      int id { get; }
      string from { get; set; }
      string posted { get; set; }
      int rating { get; set; }
      string text { get; set; }
    }
}
