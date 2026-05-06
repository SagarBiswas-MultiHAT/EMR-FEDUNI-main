using EMRSimulation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Application.Interfaces
{
    public interface ILoginRepository
    {
        Task<(int labId, string labName, int supervisorId, string supervisorName, string resultMessage)> ValidateSupervisorAsync(LoginRequest loginRequest);
        Task<(int labId, string labName, string resultMessage)> ValidateLabAsync(LoginRequest loginRequest);
    }
}
