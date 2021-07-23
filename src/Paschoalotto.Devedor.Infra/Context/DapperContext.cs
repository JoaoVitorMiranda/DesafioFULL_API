using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Paschoalotto.Devedor.Infra.Context
{
    public class DapperContext
    {
        private readonly IDbConnection _conn;

        public DapperContext(IDbConnection conn)
        {
            _conn = conn;
        }

        public IDbConnection DapperConnection
        {
            get
            {
                return _conn;
            }
        }
    }
}
