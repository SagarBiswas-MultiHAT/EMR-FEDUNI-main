namespace EMRSimulation.Domain.Dtos
{
    public class VictorianMaternityRecordDto
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public int PatientId { get; set; }
        public string FormDataJson { get; set; } = "{}";
        public string? LastUpdatedBy { get; set; }
        public string? LastUpdatedRole { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string? SupervisorReviewNotes { get; set; }
        public string? SupervisorReviewedBy { get; set; }
        public DateTime? SupervisorReviewedAt { get; set; }
    }
}
