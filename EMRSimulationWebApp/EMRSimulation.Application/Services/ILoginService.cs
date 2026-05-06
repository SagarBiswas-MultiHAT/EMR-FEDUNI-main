using EMRSimulation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Application.Services
{
    public interface ILoginService
    {
        Task<(int labId, string labName, int supervisorId, string supervisorName, string resultMessage)> AuthenticateSupervisorAsync(LoginRequest loginRequest);
        Task<(int labId, string labName, string resultMessage)> AuthenticateLabAsync(LoginRequest loginRequest);
    }
}
