using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pos_chicken_backend.BussinessFlow;
using pos_chicken_backend.Models;

namespace pos_chicken_backend.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderBussinessFlow _orderBussinessFlow;

        public OrderController(OrderBussinessFlow orderBussinessFlow)
        {
            this._orderBussinessFlow = orderBussinessFlow;
        }
        [HttpGet("/order")]
        public List<QueueOrderResponse> Ordedr()
        {
            return _orderBussinessFlow.Order();
        }
        [HttpPost("/Order/buy")]
        public List<OrderResponse> OrderBuy ([FromBody] List<OrderRequest> request)
        {
            List<OrderResponse> response = _orderBussinessFlow.Orderbuy(request);
            return response;
        }
        [HttpPost("/Order/state")]
        public string OrderUpdate([FromBody] OrderStateRequest request)
        {
            string response = this._orderBussinessFlow.Ordersteat(request);
            return response;
        }
        [HttpGet("/Order/report")]
        public List<OrderReportResponse> orderReportResponse(DateTime scope)
        {
            List<OrderReportResponse> response = _orderBussinessFlow.orderReportResponse(scope);
            return response;
        }
    }
}
