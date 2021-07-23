using System.Collections.Generic;
using System.Threading.Tasks;


namespace Paschoalotto.Devedor.Domain.Interfaces.Repository
{
    public interface IDevedorRepository : IEntityBaseRepository<Models.Database.Devedor>
    {
        Task<IEnumerable<Models.Database.Devedor>> GetAllAsync();
    }
}
