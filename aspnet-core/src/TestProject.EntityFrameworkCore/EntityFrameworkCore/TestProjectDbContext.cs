using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TestProject.Authorization.Roles;
using TestProject.Authorization.Users;
using TestProject.Models;
using TestProject.MultiTenancy;

namespace TestProject.EntityFrameworkCore
{
    public class TestProjectDbContext : AbpZeroDbContext<Tenant, Role, User, TestProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public  DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<DeviceTypeProperty> DeviceTypeProperties { get; set; }
        public DbSet<DevicePropertyValue> DevicePropertyValues { get; set; }
        
        public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options)
            : base(options)
        {
        }
    }
}
