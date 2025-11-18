using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.DAL.Implements
{
    public class ToppingRepository : GenericRepository<Topping>, IToppingRepository
    {
        public ToppingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
