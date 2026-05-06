using EMRSimulation.Domain.Dtos;

namespace EMRSimulationWebApp.Models
{
    public class PatientIvFluidChartViewModel
    {
        public PatientDto patientDto { get; set; }
        public IvFluidChartDto ivFluidChartDto { get; set; }
        public IEnumerable<IvFluidChartDto> ivFluidChartDtoList { get; set; }
    }
}
