using EMRSimulation.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMRSimulation.Infrastructure.Connection;
using EMRSimulation.Domain.Models;
using System.Text.RegularExpressions;
using System.Reflection.Emit;

namespace EMRSimulation.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public LoginRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<(int labId, string labName, int supervisorId, string supervisorName, string resultMessage)> ValidateSupervisorAsync(LoginRequest loginRequest)
        {
            int labId = 0;
            string labName = "";
            int supervisorId = 0;
            string supervisorName = "";
            string resultMessage = "NotValid";

            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (SqlCommand cmd = (SqlCommand)connection.CreateCommand())
                {
                    cmd.CommandText = "ValidateSupervisorLogin"; // Assuming stored procedure name is GetPatients
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add input parameters
                    cmd.Parameters.AddWithValue("@UserLogin", loginRequest.Username);
                    cmd.Parameters.AddWithValue("@UserPassword", loginRequest.Password);

                    // Define output parameters
                    SqlParameter outputLabId = new SqlParameter("@LabID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputLabId);

                    SqlParameter outputLabName = new SqlParameter("@LabName", SqlDbType.VarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputLabName);

                    SqlParameter outputLoginId = new SqlParameter("@SupervisorID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputLoginId);

                    SqlParameter outputSupervisorName = new SqlParameter("@UserName", SqlDbType.VarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputSupervisorName);

                    SqlParameter outputMessage = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputMessage);

                    await cmd.ExecuteNonQueryAsync();

                    // Get output values
                    labId = (int)outputLabId.Value;
                    labName = (string)outputLabName.Value;
                    supervisorId = (int)outputLoginId.Value;
                    supervisorName = (string)outputSupervisorName.Value;
                    resultMessage = (string)outputMessage.Value;
                }
            }

            return (labId, labName, supervisorId, supervisorName, resultMessage);
        }

        public async Task<(int labId, string labName, string resultMessage)> ValidateLabAsync(LoginRequest loginRequest)
        {
            int labId = 0;
            string labName = "";
            string resultMessage = "";

            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (SqlCommand cmd = (SqlCommand)connection.CreateCommand())
                {
                    cmd.CommandText = "ValidateLabLogin"; // Assuming stored procedure name is GetPatients
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add input parameters
                    cmd.Parameters.AddWithValue("@Login", loginRequest.Username);
                    cmd.Parameters.AddWithValue("@Password", loginRequest.Password);

                    // Define output parameters
                    SqlParameter outputLabId = new SqlParameter("@LabID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputLabId);

                    SqlParameter outputLabName = new SqlParameter("@LabName", SqlDbType.VarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputLabName);

                    SqlParameter outputMessage = new SqlParameter("@ResultMessage", SqlDbType.VarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputMessage);

                    await cmd.ExecuteNonQueryAsync();

                    // Get output values
                    labId = (int)outputLabId.Value;
                    labName = (string)outputLabName.Value;
                    resultMessage = (string)outputMessage.Value;
                }
            }

            return (labId, labName, resultMessage);
        }
    }
}