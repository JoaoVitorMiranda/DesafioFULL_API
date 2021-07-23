using System.Collections.Generic;
using System.Threading.Tasks;


namespace Paschoalotto.Devedor.Domain.Interfaces.Services
{
    public interface IDevedorService : IServiceBase
    {
        Task<IEnumerable<Models.Devedor.DevedorModel>> GetAllAsync();

        Task<Models.Devedor.DevedorModel> Post(Models.Devedor.DevedorModel model);
    }
}
