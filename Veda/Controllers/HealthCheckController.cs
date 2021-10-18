using Microsoft.AspNetCore.Mvc;
using pos_chicken_backend.BussinessFlow;

namespace pos_chicken_backend.Controllers
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
