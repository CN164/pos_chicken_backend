using Microsoft.EntityFrameworkCore;
using pos_chicken_backend.Models;

namespace pos_chicken_backend.Data
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
