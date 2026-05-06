using System;

namespace EMRSimulation.Domain.Dtos
{
    public class FallRiskDto
    {
        public int Id { get; set; }   

        public int LabId { get; set; }
        public int PatientId { get; set; }

        // Section scores
        public int RecentFallsScore { get; set; }
        public int MedicationsScore { get; set; }
        public int PsychologicalScore { get; set; }
        public int CognitiveScore { get; set; }

        // Calculated
        public int TotalScore { get; set; }
        public string RiskLevel { get; set; } = string.Empty;

        // Automatic High Risk flags (Step 2b)
        public bool AutoCondChange { get; set; }
        public bool AutoDizziness { get; set; }
        public bool AutoAnaesthetic { get; set; }

        // Intervention strategies (Step 3)
        public string InterventionNotes { get; set; } = string.Empty;

        // Optional metadata
        public DateTime AssessedAt { get; set; } = DateTime.UtcNow;
        public string Assessor { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
