using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TestProject.EntityFrameworkCore
{
    public static class TestProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TestProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TestProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
