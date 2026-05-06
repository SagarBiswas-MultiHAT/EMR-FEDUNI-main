using EMRSimulation.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Application.Services
{
    public interface ILabService
    {
        Task<LabDto> GetLabById(int Id);
    }
}
