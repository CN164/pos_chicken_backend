using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    public class StockRequest
    {
        public string stockName { get; set; }
        public int stockTotal { get; set; }
        public int stockunitPrice { get; set; }
        public int pointtoBuy { get; set; }
        public string parthUrl { get; set; }
    }
}
