using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    public class OrderRequest
    {
        public int stockId { get; set; }
        public int totalPromotion { get; set; }
        public int quantityOrder { get; set; }
        public int typeMenu { get; set; }
    }
}
