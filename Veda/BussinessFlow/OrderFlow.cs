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

            OrderLogic orderLogic = new OrderLogic();
            OrderEntity orderEntity = orderLogic.orderlogic(OrderData, StockData);
            
            return null;
        }
    }
}
