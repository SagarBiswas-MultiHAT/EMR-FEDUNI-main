using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EMRSimulation.Infrastructure.Connection
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IDbConnection> CreateAsync()
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("EmrSimulationConnection"));
            await connection.OpenAsync();

            return connection;
        }
    }
}
