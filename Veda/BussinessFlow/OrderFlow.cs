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
        public List<OrderEntity> OrderDataQ;
        public OrderBussinessFlow(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public List<OrderEntity> Order()
        {
            return this.baseRepository.Gets<OrderEntity>();
        }
        public List<OrderResponse> Orderbuy(List<OrderRequest> request)
        {
            List<OrderEntity> OrderData = this.baseRepository.Gets<OrderEntity>();
            List<StockEntity> StockData = this.baseRepository.Gets<StockEntity>();
            if (OrderData.Count > 0)
            {
                this.queueID = this.baseRepository.Gets<OrderEntity>().LastOrDefault().queueOrder;
            }

            OrderLogic orderLogic = new OrderLogic();
            List<StockEntity> stockEntity = orderLogic.calStockLogic(StockData, request);
            List<OrderEntity> OrderEntity = orderLogic.calOrderLogic(OrderData, stockEntity, request, queueID);

            List<OrderEntity> orderResponses = this.baseRepository.CreateList(OrderEntity);
            List<StockEntity> stockResponses = this.baseRepository.UpdateRange(stockEntity);

            List<OrderResponse> results = orderLogic.convertData(orderResponses);
            return results;
        }
        public List<OrderStateResponse> Ordersteat(List<OrderStateRequest> request)
        {
            //IList<OrderEntity> OrderEntitys;
            foreach (OrderStateRequest item in request)
            {
               this.OrderDataQ = (List<OrderEntity>)this.baseRepository.Gets<OrderEntity>().Where(x => x.queueOrder == item.queueOrder).ToList();
            }

            OrderLogic orderLogic = new OrderLogic();
            IList<OrderEntity> orderResponses = orderLogic.setstateData(request, OrderDataQ);
            
            List<OrderEntity> orderResponseDB = this.baseRepository.Update(orderResponses).ToList();
            
            

            return null;
        }
    }
}
