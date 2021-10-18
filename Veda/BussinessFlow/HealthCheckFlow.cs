using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pos_chicken_backend.Models;
using pos_chicken_backend.Repository;

namespace pos_chicken_backend.BussinessFlow
{
    public class HealthCheckBussinessFlow
    {
        private readonly IBaseRepository baseRepository;
        public HealthCheckBussinessFlow(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public string HealthCheck()
        {
            string reshealthcheck = "I'm still here!";
            return reshealthcheck;
            //return this.baseRepository.Gets<HealthCheckEntity>().FirstOrDefault().statusMessage;
        }
    }
}
