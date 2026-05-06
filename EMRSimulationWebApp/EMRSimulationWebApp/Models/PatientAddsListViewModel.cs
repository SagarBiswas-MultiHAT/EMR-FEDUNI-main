using EMRSimulation.Domain.Dtos;

namespace EMRSimulationWebApp.Models
{
    public class PatientAddsListViewModel
    {
        public IEnumerable<AddsDto> AddsDtoList { get; set; }
        public PatientDto patientDto { get; set; }
    }
}
