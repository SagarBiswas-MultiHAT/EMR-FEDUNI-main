using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EMRSimulation.Domain.Dtos
{
    public class RiskmanDto
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public int PatientId { get; set; }
        public DateTime? IncidentDate { get; set; }
        public string IncidentTime { get; set; }

        [Required(ErrorMessage = "Patient Identifier (URI Number) is required.")]
        public string URINumber { get; set; }

        // NEW (nullable to keep backward compatibility)
        public string? Campus { get; set; }
        public string? WardLocationType { get; set; }
        public string? PersonName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Sex { get; set; }
        public string? IndigenousStatus { get; set; }
        public string? BriefSummary { get; set; }
        public string? Details { get; set; }
        public string? EventType { get; set; }
        public string? EventSubType { get; set; }
        // === #4 Clinical Incident
        public bool? IsClinicalIncident { get; set; }
        public bool? Apse { get; set; }
        public string? ClinicalHarmLevel { get; set; }
        public string? HarmDuration { get; set; }
        public string? RequiredCareLevelClinical { get; set; }

        // === #5 Emergency Response
        public string? EmergencyResponseType { get; set; }
        public string? EmergencyResponseOutcome { get; set; }

        // === #6 Contributing Factors
        public List<string>? ContributingFactors { get; set; }
        public string? ContributingAdditionalDetail { get; set; }

        // === #7 OHS
        public bool? ReporterIsAffectedStaff { get; set; }
        public string? OhsTypeOfInjury { get; set; }
        public string? OhsTypeOfInjuryOther { get; set; }
        public string? OhsBodyPartAffected { get; set; }
        public string? OhsBodyPartOther { get; set; }
        public string? OhsLevelOfHarmSustained { get; set; }
        public string? OhsRequiredLevelOfCare { get; set; }
        public string? OhsActionsRequired { get; set; }

        // === Next of Kin Notification
        public DateTime? NextOfKinNotifiedDate { get; set; }
        public string NextOfKinNotifiedTime { get; set; }

        // === Sign Off
        public string? SignedBy { get; set; }
        public DateTime? SignedDate { get; set; }
    }
}