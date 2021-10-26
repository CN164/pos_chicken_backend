using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pos_chicken_backend.Models;
using pos_chicken_backend.Repository;
using pos_chicken_backend.BussinessLogic;

namespace pos_chicken_backend.BussinessFlow
{
    public class OrderBussinessFlow
    {
        private readonly IBaseRepository baseRepository;
        public int queueID;
        public OrderBussinessFlow(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public List<QueueOrderResponse> Order()
        {
            List<QueueOrderResponse> results = new List<QueueOrderResponse>();
            List<List<OrderEntity>> orderLogic = this.baseRepository.GetInclude<OrderEntity>(null, includeProperties: "stateEntity,typeMenuEntity,stockEntity").GroupBy(x => x.queueOrder).Select(x => x.ToList()).ToList();
            foreach (List<OrderEntity> items in orderLogic)
            {
                QueueOrderResponse queue = new QueueOrderResponse();
                List<OrderProductDetailResponse> productLists = new List<OrderProductDetailResponse>();
                foreach (OrderEntity item in items)
                {
                    queue.queue = item.queueOrder;
                    queue.state = item.stateEntity;
                    productLists.Add(new OrderProductDetailResponse() 
                    { 
                        quantity = item.quantityOrder,
                        stockName = item.stockEntity.stockName,
                        totalPrice = item.stockEntity.stockunitPrice * item.quantityOrder
                    });
                }
                queue.products = productLists;
                results.Add(queue);
            }
            return results;
        }
        public List<OrderResponse> Orderbuy(List<OrderRequest> request)
        {
            List<OrderEntity> OrderData = this.baseRepository.Gets<OrderEntity>();
            List<StockEntity> stockEntities = new List<StockEntity>();
            foreach (OrderRequest item in request)
            {
                stockEntities.Add(this.baseRepository.GetItem<StockEntity>(x => x.id == item.stockId));
            }

            if (OrderData.Count > 0)
            {
                this.queueID = this.baseRepository.Gets<OrderEntity>().LastOrDefault().queueOrder;
            }

            OrderLogic orderLogic = new OrderLogic();
            List<StockEntity> stockEntity = orderLogic.calStockLogic(stockEntities, request);
            List<OrderEntity> OrderEntity = orderLogic.calOrderLogic(OrderData, stockEntity, request, queueID);

            List<OrderEntity> orderResponses = this.baseRepository.CreateList(OrderEntity);
            List<StockEntity> stockResponses = this.baseRepository.UpdateRange(stockEntity);

            List<OrderResponse> results = orderLogic.convertData(orderResponses);
            return results;
        }
        public string Ordersteat(OrderStateRequest request)
        {
            DateTime datetimFormate = DateTime.Today;
            List<OrderEntity> OrderDataQ = this.baseRepository.Gets<OrderEntity>().Where(x => x.queueOrder == request.queueOrder && x.createAt.Date == datetimFormate).ToList();
            foreach (OrderEntity item in OrderDataQ)
            {
                item.stateId = request.stateId;
            }
            List<OrderEntity> orderResponseDB = this.baseRepository.UpdateRange<OrderEntity>(OrderDataQ).ToList();
            
            return "UpdateSuccess !";
        }
        public List<OrderReportResponse> orderReportResponse(DateTime scopeTime)
        {
            List<OrderEntity> OrderDatas = this.baseRepository.Gets<OrderEntity>();
            List<StockEntity> StockDatas = this.baseRepository.Gets<StockEntity>();

            OrderLogic orderLogic = new OrderLogic();
            List<OrderReportResponse> OrderReportResponse = orderLogic.orderReportResponses(OrderDatas, StockDatas, scopeTime);

            return OrderReportResponse;
        }
    }
}
