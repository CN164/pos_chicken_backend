using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    public class OrderStateRequest
    {
        public int queueOrder { get; set; }
        public int stateId { get; set; }
    }
}
