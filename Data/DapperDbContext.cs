using Microsoft.Data.SqlClient;
using System.Data;

namespace AspNetCoreWebApiDapper.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            this.connectionstring = this._configuration.GetConnectionString("ApplicationDbContextConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionstring);
    }
}
