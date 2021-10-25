using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    public class OrderResponse
    {
        public int queueOrder { get; set; }
        public int stockId { get; set; }
        public int quantityOrder { get; set; }
        public int stateId { get; set; }
        public int typeMenu { get; set; }
        public DateTime createAt { get; set; }
    }
}
