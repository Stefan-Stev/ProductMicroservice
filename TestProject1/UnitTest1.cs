using Domain;
using FakeItEasy;
using FluentAssertions;
using Persistence.Context;
using Persistence.Repository.v1;
using Xunit;

namespace TestProject1
{
    public class UnitTest1:DatabaseBaseTest
    {
        private readonly ProductContext context;
        private readonly Repository<Product> repository;
        private readonly Product newProduct;
        public UnitTest1()
        {
            context = A.Fake<ProductContext>();
            repository = new Repository<Product>(context);
            newProduct = new Product
            {
                Id = 123,
                Name = "Pizza",
                Description = "Best",
                Discount = 0,
                Price = 10,


            };
        }
        [Fact]
        public async void Given_NewProduct_WhenProductIsNotNull_Then_AddAsyncShouldReturnNewProduct()
        {
            var result = await repository.AddAsync(newProduct);
            result.Should().BeOfType<Product>();


        }
    }
}
