using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces.Services;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class RandomService: IRandomService
    {
        int seed;
        TestDbContext _ctx;
        public RandomService(TestDbContext ctx)
        {

            seed = Guid.NewGuid().GetHashCode();

            _ctx = ctx;
        }
        public async Task<int> GetRandom()
        {
            var number = new Random(seed).Next(100);

            var hasSalveNumber = await _ctx.Numbers.FirstOrDefaultAsync(x => x.Number == number);

            if (hasSalveNumber == null)
            {
                _ctx.Numbers.Add(new RandomNumberModel() { Number = number });
                _ctx.SaveChanges();
            }
            return number;
        }

    }
}
