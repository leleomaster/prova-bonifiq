using Bogus;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProvaPub.Repository
{

	public class TestDbContext : DbContext
	{
		public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CustomerModel>().HasData(getCustomerSeed());
			modelBuilder.Entity<ProductModel>().HasData(getProductSeed());

			modelBuilder.Entity<RandomNumberModel>().HasIndex(s => s.Number).IsUnique();
		}

		private CustomerModel[] getCustomerSeed()
		{
			List<CustomerModel> result = new();
			for (int i = 0; i < 20; i++)
			{
				result.Add(new CustomerModel()
				{
					 Id = i+1,
					Name = new Faker().Person.FullName,
				});
			}
			return result.ToArray();
		}
		private ProductModel[] getProductSeed()
		{
			List<ProductModel> result = new();
			for (int i = 0; i < 20; i++)
			{
				result.Add(new ProductModel()
				{
					Id = i + 1,
					Name = new Faker().Commerce.ProductName()
				});
			}
			return result.ToArray();
		}

		public DbSet<CustomerModel> Customers{ get; set; }
		public DbSet<ProductModel> Products{ get; set; }
		public DbSet<OrderModel> Orders { get; set; }

        public DbSet<RandomNumberModel> Numbers { get; set; }

    }
}
