using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    public class OrderGetResponse
    {
        public int queueOrder { get; set; }
        public int stockId { get; set; }
        public StockEntity stockEntity { get; set; }
        public int quantityOrder { get; set; }
        public StateEntity stateEntity { get; set; }
    }
}
