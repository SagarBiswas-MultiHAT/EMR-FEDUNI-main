using EMRSimulation.Domain.Dtos;

namespace EMRSimulationWebApp.Models
{
    public class PatientNeurologicalChartViewModel
    {

        public PatientDto patientDto { get; set; }
        public NeurologicalChartDto neurologicalChartDto { get; set; }
        public IEnumerable<NeurologicalChartDto> neurologicalChartDtoList { get; set; }

    }


}
