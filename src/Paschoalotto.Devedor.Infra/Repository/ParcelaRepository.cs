using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paschoalotto.Devedor.Domain.Interfaces.Repository;
using Paschoalotto.Devedor.Domain.Models;
using Paschoalotto.Devedor.Domain.Models.Dapper;
using Paschoalotto.Devedor.Infra.Context;

namespace Paschoalotto.Devedor.Infra.Repository
{
    public class ParcelaRepository : EntityBaseRepository<Domain.Models.Database.Parcela>, IParcelaRepository
    {
        private readonly DapperContext _dapperContext;

        public ParcelaRepository(EntityContext context, DapperContext dapperContext)
            : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Domain.Models.Database.Parcela>> GetAllByDevedorId(int idDevedor)
        {
            var query = @"SELECT * FROM Parcela WHERE DevedorId = @idDevedor";

            return await _dapperContext.DapperConnection.QueryAsync<Domain.Models.Database.Parcela>(query, new { idDevedor = idDevedor });
        }

        public async Task<Domain.Models.Database.Parcela> GetById(int id)
        {
            string query = $@"SELECT * FROM Parcela WHERE Id = @Id";

            Domain.Models.Database.Parcela parcela = await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<Domain.Models.Database.Parcela>(query, new { Id = id });

            return parcela;
        }
    }
}
