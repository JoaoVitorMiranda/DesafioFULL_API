using System.Threading.Tasks;
using Paschoalotto.Devedor.Domain.Models.Services;

namespace Paschoalotto.Devedor.Domain.Interfaces.Services
{
    public interface IViaCEPService
    {
        Task<ViaCEP> GetByCEPAsync(string cep);
    }
}
