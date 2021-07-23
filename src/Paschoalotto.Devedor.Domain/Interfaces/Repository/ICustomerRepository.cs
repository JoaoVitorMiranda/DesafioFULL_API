using System.Collections.Generic;
using System.Threading.Tasks;
using Paschoalotto.Devedor.Domain.Models;
using Paschoalotto.Devedor.Domain.Models.Dapper;

namespace Paschoalotto.Devedor.Domain.Interfaces.Repository
{
    public interface ICustomerRepository : IEntityBaseRepository<Customer>, IDapperReadRepository<Customer>
    {
        Task<IEnumerable<CustomerAddress>> GetAllAsync();
        Task<CustomerAddress> GetAddressByIdAsync(int id);
        Task<CustomerAddress> GetByNameAsync(string name);
    }
}
