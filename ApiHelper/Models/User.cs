using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper.Models
{
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public List<int>  myMovie { get; }

    }
}
