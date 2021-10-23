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
        public List<StockEntity> StockData;
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
            foreach (OrderRequest item in request)
            {
                //ดึงข้อมูลมา แล้วไป logic ไปแมพแค่ id เท่านั้นแล้ว ค่อยไป calstock
                //หรือ ก็แอด list นี้ลงให้ได้ในขั้นตอนนี่เพื่อจบทุกอย่างซ่ะ
                List<StockEntity> StockData = this.baseRepository.Gets<StockEntity>(x => x.id == item.stockId);
            }
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
        public List<OrderReportResponse> orderReportResponse()
        {
            List<OrderEntity> OrderDatas = this.baseRepository.Gets<OrderEntity>();
            List<StockEntity> StockDatas = this.baseRepository.Gets<StockEntity>();

            OrderLogic orderLogic = new OrderLogic();
            List<OrderReportResponse> OrderReportResponse = orderLogic.orderReportResponses(OrderDatas, StockDatas);

            return OrderReportResponse;
        }
    }
}
