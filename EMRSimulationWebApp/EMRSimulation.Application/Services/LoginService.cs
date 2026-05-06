using EMRSimulation.Application.Interfaces;
using EMRSimulation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<(int labId, string labName, int supervisorId, string supervisorName, string resultMessage)> AuthenticateSupervisorAsync(LoginRequest loginRequest)
        {
            // Add any business logic if needed (e.g., validation before querying)
            return await _loginRepository.ValidateSupervisorAsync(loginRequest);
        }

        public async Task<(int labId, string labName, string resultMessage)> AuthenticateLabAsync(LoginRequest loginRequest)
        {
            // Add any business logic if needed (e.g., validation before querying)
            return await _loginRepository.ValidateLabAsync(loginRequest);
        }
    }
}
