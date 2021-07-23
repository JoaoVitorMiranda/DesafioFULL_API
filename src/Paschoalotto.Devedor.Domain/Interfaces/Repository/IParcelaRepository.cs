using System.Collections.Generic;
using System.Threading.Tasks;
using Paschoalotto.Devedor.Domain.Models;
using Paschoalotto.Devedor.Domain.Models.Dapper;

namespace Paschoalotto.Devedor.Domain.Interfaces.Repository
{
    public interface IParcelaRepository : IEntityBaseRepository<Models.Database.Parcela>
    {
        Task<IEnumerable<Models.Database.Parcela>> GetAllByDevedorId(int idDevedor);

        Task<Models.Database.Parcela> GetById(int id);
    }
}
