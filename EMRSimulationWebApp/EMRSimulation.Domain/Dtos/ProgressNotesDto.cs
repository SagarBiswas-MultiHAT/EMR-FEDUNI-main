using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Domain.Dtos
{
    public record ProgressNotesDto
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public int PatientId { get; set; }
        public string Notes { get; set; }
        public string Sign { get; set; }
        public DateTime? NotesDate { get; set; }
        public string NotesFrom { get; set; }
    }
}
