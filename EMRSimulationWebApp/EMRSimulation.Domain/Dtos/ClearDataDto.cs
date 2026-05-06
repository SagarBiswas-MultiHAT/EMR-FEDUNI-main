using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Domain.Dtos
{
    public class ClearDataDto
    {
        public string ModuleName { get; set; }
        public int RowsDeleted { get; set; }
    }
}
