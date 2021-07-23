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
    public class DevedorRepository : EntityBaseRepository<Domain.Models.Database.Devedor>, IDevedorRepository
    {
        private readonly DapperContext _dapperContext;

        public DevedorRepository(EntityContext context, DapperContext dapperContext)
            : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Domain.Models.Database.Devedor>> GetAllAsync()
        {
            var query = @"SELECT * FROM Devedor";
            return await _dapperContext.DapperConnection.QueryAsync<Domain.Models.Database.Devedor>(query,null,null,null,null);
        }
    }
}
