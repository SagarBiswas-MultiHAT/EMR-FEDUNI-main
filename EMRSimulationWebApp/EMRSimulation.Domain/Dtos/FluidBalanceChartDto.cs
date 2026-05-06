using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Domain.Dtos

{
    public class FluidBalanceChartDto
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public int PatientId { get; set; }
        public DateTime? Date { get; set; }
        public int? IV_Fluids { get; set; }
        public int? Oral_Intake { get; set; }
        public int? Enteric_Intake { get; set; }
        public int? Other_Fluids { get; set; }
        public int? Cumulative_Intake { get; set; }
        public int? Urine_Output { get; set; }
        public int? Faecal_Output { get; set; }
        public int? Vomitus { get; set; }
        public int? Drainage { get; set; }
        public int? Gastric_Aspirate { get; set; }
        public int? Bladder_Scan { get; set; }
        public int? Other_Output { get; set; }
        public int? Cumulative_Output { get; set; }
        public int? Difference { get; set; }
    }

}
