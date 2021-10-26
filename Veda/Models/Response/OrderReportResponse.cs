using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    public class OrderReportResponse
    {
        public int id { get; set; }
        public string stokcName { get; set; }
        public int totalUnit { get; set; }
        public int totalPrice { get; set; }

    }
}
