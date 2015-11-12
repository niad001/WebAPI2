using System.Linq;
using System.Timers;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiPractice.Models;
using WebApiPractice.Tests.Attributes;
using WebApiPractice.Tests.Fixtures;
using Xunit;

namespace WebApiPractice.Tests
{
    public class ProductsTests : IClassFixture<ProductsControllerFixture>
    {
        ProductsControllerFixture fixture;

        public ProductsTests(ProductsControllerFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void GetAllProducts_ReturnsAllProducts()
        {
            var result = fixture.Controller.GetAllProducts();

            Assert.Equal(fixture.Products, result);
        }

        [Theory]
        [RangeData(1, 3)]
        public void GetProduct_ReturnsProduct(int id)
        {
            var testProduct = fixture.Products.FirstOrDefault(x => x.Id == id);

            IHttpActionResult actionResult = fixture.Controller.GetProduct(id);
            var result = (actionResult as OkNegotiatedContentResult<Product>).Content;

            Assert.Same(testProduct, result);
        }

        [Theory]
        [InlineData(4)]
        public void GetProduct_ReturnsProductNotFound(int id)
        {
            IHttpActionResult actionResult = fixture.Controller.GetProduct(id);

            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public void GetAllProducts_TakesLessThanOrEqualToOneSecond()
        {
            Timer callTimer = new Timer();

            callTimer.Start();
            var result = fixture.Controller.GetAllProducts();
            callTimer.Stop();

            Assert.True(callTimer.Interval <= 1000);
        }

        [Theory]
        [RangeData(1, 4)]
        public void GetProduct_TakesLessThanOrEqualToOneSecond(int id)
        {
            Timer callTimer = new Timer();

            callTimer.Start();
            IHttpActionResult actionResult = fixture.Controller.GetProduct(id);
            callTimer.Stop();

            Assert.True(callTimer.Interval <= 1000);
        }
    }
}
