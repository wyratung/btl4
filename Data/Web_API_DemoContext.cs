using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_API_Demo.Models;

namespace Web_API_Demo.Data
{
    public class Web_API_DemoContext : DbContext
    {
        public Web_API_DemoContext (DbContextOptions<Web_API_DemoContext> options)
            : base(options)
        {
        }

        public DbSet<Web_API_Demo.Models.SensorData> SensorData { get; set; }
    }
}
