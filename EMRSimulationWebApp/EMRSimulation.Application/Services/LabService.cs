using EMRSimulation.Application.Interfaces;
using EMRSimulation.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Application.Services
{
    public class LabService : ILabService
    {
        private readonly ILabRepository _LabRepository;

        public LabService(ILabRepository LabRepository)
        {
            _LabRepository = LabRepository;
        }

        public async Task<LabDto> GetLabById(int Id)
        {
            return await _LabRepository.GetLabById(Id);
        }
    }
}
