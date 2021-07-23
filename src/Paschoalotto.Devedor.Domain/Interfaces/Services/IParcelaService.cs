using System.Collections.Generic;
using System.Threading.Tasks;
using Paschoalotto.Devedor.Domain.Models.Services;

namespace Paschoalotto.Devedor.Domain.Interfaces.Services
{
    public interface IParcelaService : IServiceBase
    {
        Task<IEnumerable<Models.Parcela.ParcelaModel>> GetAllByDevedorId(int idDevedor);

        Task<Models.Parcela.ParcelaModel> Post(Models.Parcela.ParcelaAddModel model);

        Task<Models.Parcela.ParcelaModel> GetById(int id);
    }
}
