﻿using System;
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
        public List<OrderEntity> Order()
        {
            return this.baseRepository.GetInclude<OrderEntity>(null, includeProperties: "stateEntity,typeMenuEntity").OrderBy(x => x.queueOrder == 1).ToList();
            //sort by state 3>2>1  
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
