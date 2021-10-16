using Microsoft.AspNetCore.Mvc;
using Veda.BussinessFlow;

namespace Veda.Controllers
{

    public class HealthCheckController : Controller
    {
        private readonly HealthCheckBussinessFlow _healthCheckBussinessFlow;

        public HealthCheckController(HealthCheckBussinessFlow healthCheckBussinessFlow)
        {
            this._healthCheckBussinessFlow = healthCheckBussinessFlow;
        }
        [HttpGet("healthcheck")]
        public string HealthCheck()
        {
            return _healthCheckBussinessFlow.HealthCheck();
        }
    }
}
