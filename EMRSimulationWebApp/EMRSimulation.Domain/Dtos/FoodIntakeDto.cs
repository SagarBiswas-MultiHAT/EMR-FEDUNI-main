// EMRSimulation.Domain.Dtos/FoodIntakeDto.cs
using System.ComponentModel.DataAnnotations;

namespace EMRSimulation.Domain.Dtos
{
    public class FoodIntakeDto
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public int PatientId { get; set; }
        [Required]
        public string DayText { get; set; } = "";

        public DateTime IntakeDate { get; set; }
        public string? Shift1Signature { get; set; }
        public string? Shift1Designation { get; set; }
        public string? Shift2Signature { get; set; }
        public string? Shift2Designation { get; set; }
        public string? Shift3Signature { get; set; }
        public string? Shift3Designation { get; set; }

        // ✅ NEW
        public string? BreakfastComment { get; set; }
        public string? MorningTeaComment { get; set; }
        public string? LunchComment { get; set; }
        public string? AfternoonTeaComment { get; set; }
        public string? DinnerComment { get; set; }
        public string? SupperComment { get; set; }

        public List<FoodIntakeItemDto> Items { get; set; } = new();
    }

    public class FoodIntakeItemDto
    {
        // Keep PascalCase to match SQL OPENJSON
        public string Meal { get; set; } = "";
        public string Label { get; set; } = "";
        public string? Notes { get; set; }
        public string Amount { get; set; } = "";
    }

    // NEW: list row model
    public class FoodIntakeListDto
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public int PatientId { get; set; }
        public string? DayText { get; set; }
        public DateTime IntakeDate { get; set; }
        public string MealsRecordedSummary { get; set; } = "";
    }
}