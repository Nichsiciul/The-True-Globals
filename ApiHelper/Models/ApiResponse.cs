using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper.Models
{
    public class ApiResponse
    {
        int code { get; set; }
        string type { get; set; }
        string message { get; set; }
    }
}
