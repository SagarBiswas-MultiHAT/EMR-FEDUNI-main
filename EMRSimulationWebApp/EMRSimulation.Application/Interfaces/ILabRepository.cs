using EMRSimulation.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Application.Interfaces
{
    public interface ILabRepository
    {
        Task<LabDto> GetLabById(int Id);
    }
}
