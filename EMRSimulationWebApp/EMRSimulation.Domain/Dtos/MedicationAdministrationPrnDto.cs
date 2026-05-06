using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Domain.Dtos
{
    public class MedicationAdministrationPrnDto
    {
        public int Id { get; set; }
        public int? LabId { get; set; }
        public int? PatientId { get; set; }
        public int? PatientMedicationChartId { get; set; }
        public DateTime? DoseDate { get; set; }
        public string? DoseTime { get; set; }
        public string? Dose { get; set; }
        public string? Route { get; set; }
        public string? StudentSign { get; set; }
        public string? Reason { get; set; }
        public string? CoSign { get; set; }
    }

}
