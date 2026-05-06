using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Domain.Dtos
{
    public class IvFluidChartDto
    {
        public int Id { get; set; }
        public int? LabId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? Date { get; set; }
        public string? FlaskVol { get; set; }
        public string? Strength { get; set; }
        public string? Rate { get; set; }
        public string? Dose { get; set; }
        public string? OfficerSign { get; set; }
    }

}
