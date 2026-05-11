using EMRSimulation.Domain.Dtos;

namespace EMRSimulationWebApp.Models
{
    public class VictorianMaternityRecordViewModel
    {
        public PatientDto Patient { get; set; } = new();
        public VictorianMaternityRecordDto Record { get; set; } = new();
        public bool IsSupervisor { get; set; }
    }
}
