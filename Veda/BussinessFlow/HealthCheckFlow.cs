using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veda.Models;
using Veda.Repository;

namespace Veda.BussinessFlow
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
