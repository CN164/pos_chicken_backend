using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    public class QueueOrderResponse
    {
        public int queue { get; set; }
        public List<StockEntity> products { get; set; }
        public StateEntity state { get; set; }
    }
}
