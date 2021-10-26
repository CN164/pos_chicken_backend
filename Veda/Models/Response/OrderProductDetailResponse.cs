using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    public class OrderProductDetailResponse
    {
        public int totalPrice { get; set; }
        public int quantity{ get; set; }
        public string stockName { get; set; }
    }
}
