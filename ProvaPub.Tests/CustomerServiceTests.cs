using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ProvaPub.Interfaces.Services;
using ProvaPub.Repository;
using ProvaPub.Services;
using System.Reflection.PortableExecutable;

namespace ProvaPub.Tests
{
    [TestClass]
    public sealed class CustomerServiceTests
    {
        ICustomerService _customerService;

        private IServiceProvider _services;

        [TestInitialize]
        public void Start()
        {
            var services = new ServiceCollection();
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var teste = builder.GetConnectionString("ctx");

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddDbContext<TestDbContext>(options =>
                     options.UseSqlServer(builder.GetConnectionString("ctx")));

            _services = services.BuildServiceProvider();

            _customerService = _services.GetService<ICustomerService>();
        }

        [TestMethod]
        public async Task CanPurchase()
        {
            var exceptionCustomerId = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await _customerService.CanPurchase(0, 100));
            Assert.AreEqual($"Specified argument was out of the range of valid values. (Parameter 'customerId')", exceptionCustomerId.Message);

            var exceptionPurchaseValue = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await _customerService.CanPurchase(3, 0));
            Assert.AreEqual($"Specified argument was out of the range of valid values. (Parameter 'purchaseValue')", exceptionPurchaseValue.Message);

            var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await _customerService.CanPurchase(100, 100));
            Assert.AreEqual($"Customer Id {100} does not exists", exception.Message);

            var customerServiceTask = await _customerService.CanPurchase(2, 160);

            var value = customerServiceTask;

            Assert.IsNotNull(value);
            Assert.AreEqual(false, value);

            customerServiceTask = await _customerService.CanPurchase(2, 100);

            value = customerServiceTask;

            Assert.IsNotNull(value);
            Assert.AreEqual(true, value);
        }
    }
}
