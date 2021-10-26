using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pos_chicken_backend.Models;

namespace pos_chicken_backend.BussinessLogic
{
    public class OrderLogic
    {
        public List<StockEntity> calStockLogic(List<StockEntity> stockData, List<OrderRequest> requests)
        {
            foreach (var stockAndRes in stockData.Zip(requests, Tuple.Create))
            {
                if (stockAndRes.Item1.id == stockAndRes.Item2.stockId)
                {
                    stockAndRes.Item1.stockTotal = (stockAndRes.Item1.stockTotal - stockAndRes.Item2.quantityOrder);
                    if (stockAndRes.Item1.pointtoBuy > stockAndRes.Item1.stockTotal)
                    {
                        stockAndRes.Item1.additionalUnit = (stockAndRes.Item1.pointtoBuy - stockAndRes.Item1.stockTotal);
                    }
                    else
                    {
                        stockAndRes.Item1.additionalUnit = 0;
                    }
                }
                    
            }

            return stockData;
        }
        public List<OrderEntity> calOrderLogic(List<OrderEntity> orderData, List<StockEntity> stockData, List<OrderRequest> request, int queueID)
        {
            List<OrderEntity> results = new List<OrderEntity>();

            DateTime date = DateTime.Now;

            foreach (OrderRequest item in request)
            {
                OrderEntity orderSet = new OrderEntity()
                {
                    queueOrder = queueID + 1,
                    stockId = item.stockId,
                    quantityOrder = item.quantityOrder,
                    totalPromotion = 0,
                    stateId = 1,
                    typeId = item.typeMenu,
                    createAt = date
                };
                results.Add(orderSet);
            }
            return results;
        }
        public List<OrderResponse> convertData(List<OrderEntity> OrderData)
        {
            List<OrderResponse> results = new List<OrderResponse>();

            foreach (OrderEntity item in OrderData)
            {
                OrderResponse orderSet = new OrderResponse()
                {
                    queueOrder = item.queueOrder,
                    stockId = item.stockId,
                    quantityOrder = item.quantityOrder,
                    stateId = item.stateId,
                    typeMenu = item.typeId,
                    createAt = item.createAt
                };
                results.Add(orderSet);
            }

            return results;
        }
        public List<OrderEntity> setstateData(List<OrderStateRequest> orderStateRequests, List<OrderEntity> OrderDataQ)
        {
            List<OrderEntity> results = new List<OrderEntity>();
            foreach (var resData in orderStateRequests.Zip(OrderDataQ, Tuple.Create))
            {
                OrderEntity setsteat = new OrderEntity()
                {
                    queueOrder = resData.Item1.queueOrder,
                    stockId = resData.Item2.stockId,
                    totalPromotion = resData.Item2.totalPromotion,
                    quantityOrder = resData.Item2.quantityOrder,
                    stateId = resData.Item1.stateId,
                    createAt = resData.Item2.createAt
                };
                results.Add(setsteat);
            }

            return results;
        }
        public List<OrderReportResponse> orderReportResponses(List<OrderEntity> OrderDatas, List<StockEntity> StockDatas, DateTime scopeTime)
        {
            List<OrderReportResponse> results = new List<OrderReportResponse>();
            
            foreach (StockEntity product in StockDatas)
            {
                List<OrderEntity> orders = OrderDatas.Where(x => x.stockId == product.id && x.createAt.Date >= scopeTime.Date).ToList();
                if (orders.Count > 0)
                {
                    OrderReportResponse orderSet = new OrderReportResponse()
                    {
                        id = product.id,
                        stokcName = product.stockName,
                        totalUnit = orders.Sum(x => x.quantityOrder),
                        totalPrice = orders.Sum(x => x.quantityOrder) * product.stockunitPrice
                    };
                    results.Add(orderSet);
                }
            }
            return results;
        }

        public List<OrderGetResponse> orderGetResponse(List<OrderEntity> orderDatas)
        {
            List<OrderGetResponse> results = new List<OrderGetResponse>();

            foreach (OrderEntity orderItems in orderDatas)
            {
                OrderGetResponse orderSet = new OrderGetResponse()
                {
                    quantityOrder = orderItems.quantityOrder,
                    stockId = orderItems.stockId,
                    stockEntity = orderItems.stockEntity,
                    queueOrder = orderItems.queueOrder,
                    stateEntity = orderItems.stateEntity
                };
                results.Add(orderSet);
            }

            return results;
        }
    }
}
