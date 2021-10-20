using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pos_chicken_backend.Models;
using pos_chicken_backend.Repository;
using pos_chicken_backend.BussinessLogic;

namespace pos_chicken_backend.BussinessFlow
{
    public class StockFlowBussinessFlow
    {
        private readonly IBaseRepository baseRepository;
        public StockFlowBussinessFlow(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public List<StockEntity> Stock()
        {
            return this.baseRepository.Gets<StockEntity>();
        }
        public StockResponse resgisstock(StockRequest request)
        {
            StockLogic callogic = new StockLogic();
            StockEntity stockRequestDB = callogic.calunitprice(request);
            StockEntity stockResponseDB = this.baseRepository.Create(stockRequestDB);

            StockResponse response = callogic.convertDataResponse(stockResponseDB);

            return response;
        }
    }
}
