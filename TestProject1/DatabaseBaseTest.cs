using System;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
namespace TestProject1
{
    public class DatabaseBaseTest : IDisposable
    {
        protected readonly ProductContext context;
        public DatabaseBaseTest()
        {
            var options = new DbContextOptionsBuilder<ProductContext>().UseInMemoryDatabase("Test").Options;
            context=new ProductContext(options);
            context.Database.EnsureCreated();
            DataBaseInitializer.Initialize(context);
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
