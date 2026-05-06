namespace EMRSimulation.Domain.Dtos
{
    public class BradenDto
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateOfAssessment { get; set; }
        public string NurseInitials { get; set; }
        public int Sensory { get; set; }
        public int Moisture { get; set; }
        public int Activity { get; set; }
        public int Mobility { get; set; }
        public int Nutrition { get; set; }
        public int Friction { get; set; }
        public int TotalScore { get; set; }
        public string RiskKey { get; set; }
        public string? Shift { get; set; }

    }
}
