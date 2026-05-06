using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Domain.Dtos
{
    public class MedicationDto
    {
        public int Id { get; set; }
        public int? LabId { get; set; }
        public string Name { get; set; }
    }
}
