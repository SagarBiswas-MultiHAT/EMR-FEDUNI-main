namespace EMRSimulation.Domain.Dtos
{
    public record PatientDto
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public DateTime? AdmitDate { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }
        public string? Age { get; set; }
        public string? Allergy { get; set; }
        public string? Intolerance { get; set; }
        public string? Alerts { get; set; }
        public string? UriNumber { get; set; }
        public int? Alert { get; set; }
    }
}
