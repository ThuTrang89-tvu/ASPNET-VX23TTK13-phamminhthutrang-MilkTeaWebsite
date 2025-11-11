using MilkTeaWebsite.Entity.Entity;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee?> GetByUserIdAsync(int userId);
    }
}
