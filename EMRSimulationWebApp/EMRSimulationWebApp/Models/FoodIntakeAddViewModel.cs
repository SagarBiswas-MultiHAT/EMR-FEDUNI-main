namespace EMRSimulationWebApp.Models
{
    public class FoodIntakeAddViewModel
    {
        public int LabId { get; set; }
        public int PatientId { get; set; }

        public string? Day { get; set; }
        public DateTime? Date { get; set; }

        public string? Shift1Signature { get; set; }
        public string? Shift1Designation { get; set; }
        public string? Shift2Signature { get; set; }
        public string? Shift2Designation { get; set; }
        public string? Shift3Signature { get; set; }
        public string? Shift3Designation { get; set; }
    }
}
