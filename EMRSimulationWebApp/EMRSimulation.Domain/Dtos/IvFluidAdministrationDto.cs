using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Domain.Dtos
{
    public class IvFluidAdministrationDto
    {
        public int Id { get; set; }
        public int? LabId { get; set; }
        public int? PatientId { get; set; }
        public int? IvFluidChartId { get; set; }
        public DateTime? StartDate { get; set; } 
        public string? StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EndTime { get; set; }
        public string? VolGiven { get; set; }
        public string? PharmacistReview { get; set; }
        public string? NurseSign { get; set; }

        public string? CoSign { get; set; }
    }

}
