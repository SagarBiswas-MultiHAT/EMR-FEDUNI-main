using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Domain.Dtos
{
    public class MedicationRegularChartDto
    {
        public int Id { get; set; }
        public int? LabId { get; set; }
        public int? PatientId { get; set; }
        public int? MedicationId { get; set; }
        public string MedicationName { get; set; }
        public string? Dose { get; set; }
        public string? DoseFrequency { get; set; }
        public DateTime? DoseDate { get; set; }
        public string? DoseTime { get; set; }
        public string? Indication { get; set; }
        public string? Route { get; set; }
        public string? Pharmacy { get; set; }
        public string? Prescriber { get; set; }
        public string? PrescriberSign { get; set; }
    }
}
