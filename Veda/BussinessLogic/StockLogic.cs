using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pos_chicken_backend.Models;

namespace pos_chicken_backend.BussinessLogic
{
    public class StockLogic
    {
        public StockEntity calunitprice(StockRequest request)
        {
            StockEntity stockEntity = new StockEntity();

            stockEntity.stockName = request.stockName;
            stockEntity.stockTotal = request.stockTotal;
            stockEntity.stockunitPrice = request.stockunitPrice;
            stockEntity.pointtoBuy = request.pointtoBuy;
            stockEntity.additionalUnit = (request.pointtoBuy - request.stockTotal);
            stockEntity.parthUrl = request.parthUrl;

            return stockEntity;
        }
        public StockResponse convertDataResponse(StockEntity request)
        {
            StockResponse stockResponse = new StockResponse();

            stockResponse.id = request.id;
            stockResponse.stockName = request.stockName;
            stockResponse.stockTotal = request.stockTotal;
            stockResponse.stockunitPrice = request.stockunitPrice;
            stockResponse.parthUrl = request.parthUrl;

            return stockResponse;
        }
    }
}
