using System.Data;

namespace EMRSimulation.Infrastructure.Connection
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateAsync();
    }
}
