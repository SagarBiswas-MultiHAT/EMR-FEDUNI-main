using EMRSimulation.Application.Interfaces;
using EMRSimulation.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMRSimulation.Infrastructure.Connection;

namespace EMRSimulation.Infrastructure.Repositories
{
    public class LabRepository : ILabRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public LabRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<LabDto> GetLabById(int Id)
        {
            var patient = new LabDto();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetLab"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            patient.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            patient.LabName = reader.GetString(reader.GetOrdinal("LabName"));
                        }
                    }
                }
            }

            return patient;
        }
    }
}
