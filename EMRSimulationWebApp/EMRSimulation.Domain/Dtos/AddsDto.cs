using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Domain.Dtos
{
    public class AddsDto
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public int PatientId { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string EnteredTime { get; set; }
        public string? RespiratoryRate { get; set; }
        public string? HeartRate { get; set; }
        public string? Temperature { get; set; }
        public string? Consciousness { get; set; }
        public string? OxygenSaturation { get; set; }
        public string? OxygenFlow { get; set; }
        public string? BloodPressure { get; set; }
        public string? BloodPressureDiastolic { get; set; }

        public int? RespiratoryRateValue { get; set; }
        public int? OxygenSaturationValue { get; set; }
        public int? BloodPressureValue { get; set; }
        public int? BloodPressureDiastolicValue { get; set; }
        public int? HeartRateValue { get; set; }
        public int? TemperatureValue { get; set; }

        public int? RespiratoryAlert { get; set; }
        public int? OxygenSaturationAlert { get; set; }
        public int? BloodPressureAlert { get; set; }
        public int? HeartRateAlert { get; set; }
        public int? ConsciousnessAlert { get; set; }
        public int? TotalScore {  get; set; }
    }
}
