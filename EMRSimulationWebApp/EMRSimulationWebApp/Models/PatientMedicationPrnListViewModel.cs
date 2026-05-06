using EMRSimulation.Domain.Dtos;

namespace EMRSimulationWebApp.Models
{
    public class PatientMedicationPrnListViewModel
	{
        public PatientDto patientDto { get; set; }
        public MedicationPrnChartDto MedicationPrnChartDto { get; set; }
        public IEnumerable<MedicationPrnChartDto> MedicationPrnChartDtoList { get; set; }
        
    }
}
