using Microsoft.EntityFrameworkCore;
using Veda.Models;

namespace Veda.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
        }
        // เวลาสร้าง model Entity ใหม่ มาใส่ในนี้ด้วย
        //แบบนี้
        public DbSet<HealthCheckEntity> healthCheckEntity { get; set; }

    }
}
