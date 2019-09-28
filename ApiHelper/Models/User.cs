using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper.Models
{
    public class User
    {
        int id { get;}
        string username { get; set; }
        string email { get; set; }
        string city { get; set; }
        string street { get; set; }
        string number { get; set; }
        List<int>  myMovie { get; }
    }
}
