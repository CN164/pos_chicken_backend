﻿using System;
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
        public List<OrderEntity> Ordedr()
        {
            return _orderBussinessFlow.Order();
        }
        [HttpPost("/Order/buy")]
        public List<OrderResponse> OrderBuy ([FromBody] List<OrderRequest> request)
        {
            List<OrderResponse> response = _orderBussinessFlow.Orderbuy(request);
            return response;
        }
    }
}