using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRSimulation.Domain.Dtos
{
    public class NeurologicalChartDto
    {
        public int Id { get; set; }
        public int? LabId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public int? EyesOpenScore { get; set; }
        public string VerbalResponseScore { get; set; } // Keep as string for 'T'
        public int? MotorResponseScore { get; set; }
        public int? TotalComaScale { get; set; }
        public bool? EndotrachealTube { get; set; }
        public int? RightPupilSize { get; set; }
        public string RightPupilReaction { get; set; }
        public int? LeftPupilSize { get; set; }
        public string LeftPupilReaction { get; set; }
        public string RightArmResponse { get; set; }
        public string RightLegResponse { get; set; }
        public string LeftArmResponse { get; set; }
        public string LeftLegResponse { get; set; }
        public string OfficerSign { get; set; }
    }
}
