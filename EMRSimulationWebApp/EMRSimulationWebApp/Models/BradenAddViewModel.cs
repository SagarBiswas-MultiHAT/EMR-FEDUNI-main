namespace EMRSimulationWebApp.Models
{
    public class BradenAddViewModel
    {
        public int LabId { get; set; }
        public int PatientId { get; set; }
        public string? UriNumber { get; set; }
        public string? Surname { get; set; }
        public string? GivenNames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }

        public string DobDisplay => DateOfBirth?.ToString("dd/MM/yyyy") ?? "";
    }
}
