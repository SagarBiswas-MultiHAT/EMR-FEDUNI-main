using EMRSimulation.Domain.Dtos;

namespace EMRSimulationWebApp.Models
{
    public class PatientMedicationRegularListViewModel
	{
        public PatientDto patientDto { get; set; }
        public MedicationRegularChartDto MedicationRegularChartDto { get; set; }
        public IEnumerable<MedicationRegularChartDto> MedicationRegularChartDtoList { get; set; }
        
    }
}
