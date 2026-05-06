using EMRSimulation.Domain.Dtos;

namespace EMRSimulationWebApp.Models
{
    public class PatientFluidBalanceChartViewModel
    {
        public PatientDto patientDto { get; set; }
        public FluidBalanceChartDto FluidBalanceChartDto { get; set; }
        public IEnumerable<FluidBalanceChartDto> FluidBalanceChartDtoList { get; set; }
    }
}

