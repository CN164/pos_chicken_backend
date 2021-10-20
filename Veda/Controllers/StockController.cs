using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pos_chicken_backend.BussinessFlow;
using pos_chicken_backend.Models;

namespace pos_chicken_backend.Controllers
{
    public class StockController : Controller
    {
        private readonly StockFlowBussinessFlow _stockFlowBussinessFlow;

        public StockController(StockFlowBussinessFlow stockFlowBussinessFlow)
        {
            this._stockFlowBussinessFlow = stockFlowBussinessFlow;
        }
        [HttpGet("/Stock")]
        public List<StockEntity> Stock()
        {
            return _stockFlowBussinessFlow.Stock();
        }
        [HttpPost("/StockAdd")]
        public StockResponse regisstock ([FromBody] StockRequest request)
        {
            StockResponse response = _stockFlowBussinessFlow.resgisstock(request);
            return response;
        }
    }
}
