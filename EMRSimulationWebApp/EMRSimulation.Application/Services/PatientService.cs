using EMRSimulation.Application.Interfaces;
using EMRSimulation.Domain.Dtos;

namespace EMRSimulation.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // -------------------------
        // Patients & Adds
        // -------------------------
        public Task<int> AddPatientAsync(PatientDto addsDto)
            => _patientRepository.AddPatientAsync(addsDto);

        public Task<PatientDto> GetPatientById(int id, int labId)
            => _patientRepository.GetPatientById(id, labId);

        public Task<IEnumerable<PatientDto>> GetAllPatientsAsync(int labId)
            => _patientRepository.GetAllPatientsAsync(labId);

        public Task<int> DeletePatientAsync(int labId, int id)
            => _patientRepository.DeletePatientAsync(labId, id);

        public Task<int> AddPatientAddsAsync(AddsDto addsDto)
            => _patientRepository.AddPatientAddsAsync(addsDto);

        public Task<IEnumerable<AddsDto>> GetPatientAdds(int labId, int patientId)
            => _patientRepository.GetPatientAdds(labId, patientId);

        public Task<int> DeletePatientAddsAsync(int id)
            => _patientRepository.DeletePatientAddsAsync(id);

        // -------------------------
        // Medication - PRN
        // -------------------------
        public Task<int> AddMedicationPrnChartAsync(MedicationPrnChartDto addsDto)
            => _patientRepository.AddMedicationPrnChartAsync(addsDto);

        public Task<IEnumerable<MedicationPrnChartDto>> GetMedicationPrnChartAsync(int labId, int patientId)
            => _patientRepository.GetMedicationPrnChartAsync(labId, patientId);

        public Task<MedicationPrnChartDto> GetMedicationPrnChartByIdAsync(int id, int labId)
            => _patientRepository.GetMedicationPrnChartByIdAsync(id, labId);

        public Task<int> AddPatientMedicationPrnAdministrationAsync(MedicationAdministrationPrnDto addsDto)
            => _patientRepository.AddPatientMedicationPrnAdministrationAsync(addsDto);

        public Task<IEnumerable<MedicationAdministrationPrnDto>> GetPatientMedicationPrnAdministrationAsync(int labId, int patientId, int patientMedicationChartId)
            => _patientRepository.GetPatientMedicationPrnAdministrationAsync(labId, patientId, patientMedicationChartId);

        public Task<(int id, string resultMessage)> DeleteMedicationPrnChartAsync(int id)
            => _patientRepository.DeleteMedicationPrnChartAsync(id);

        public Task<int> DeleteMedicationPrnAdministrationAsync(int id)
            => _patientRepository.DeleteMedicationPrnAdministrationAsync(id);

        // -------------------------
        // Medication - Regular
        // -------------------------
        public Task<int> AddMedicationRegularChartAsync(MedicationRegularChartDto addsDto)
            => _patientRepository.AddMedicationRegularChartAsync(addsDto);

        public Task<IEnumerable<MedicationRegularChartDto>> GetMedicationRegularChartAsync(int labId, int patientId)
            => _patientRepository.GetMedicationRegularChartAsync(labId, patientId);

        public Task<MedicationRegularChartDto> GetMedicationRegularChartByIdAsync(int id, int labId)
            => _patientRepository.GetMedicationRegularChartByIdAsync(id, labId);

        public Task<int> AddPatientMedicationRegularAdministrationAsync(MedicationAdministrationRegularDto addsDto)
            => _patientRepository.AddPatientMedicationRegularAdministrationAsync(addsDto);

        public Task<IEnumerable<MedicationAdministrationRegularDto>> GetPatientMedicationRegularAdministrationAsync(int labId, int patientId, int patientMedicationChartId)
            => _patientRepository.GetPatientMedicationRegularAdministrationAsync(labId, patientId, patientMedicationChartId);

        public Task<(int id, string resultMessage)> DeleteMedicationRegularChartAsync(int id)
            => _patientRepository.DeleteMedicationRegularChartAsync(id);

        public Task<int> DeleteMedicationRegularAdministrationAsync(int id)
            => _patientRepository.DeleteMedicationRegularAdministrationAsync(id);

        // -------------------------
        // Medication - Master list
        // -------------------------
        public Task<IEnumerable<MedicationDto>> GetMedicationAsync(int labId)
            => _patientRepository.GetMedicationAsync(labId);

        public Task<(int id, string resultMessage)> DeleteMedicationAsync(int id)
            => _patientRepository.DeleteMedicationAsync(id);

        public Task<int> AddMedicationAsync(MedicationDto addsDto)
            => _patientRepository.AddMedicationAsync(addsDto);

        // -------------------------
        // IV Fluids
        // -------------------------
        public Task<int> AddIvFluidChartsync(IvFluidChartDto addsDto)
            => _patientRepository.AddIvFluidChartsync(addsDto);

        public Task<IvFluidChartDto> GetIvFluidChartByIdAsync(int id, int labId)
            => _patientRepository.GetIvFluidChartByIdAsync(id, labId);

        public Task<IEnumerable<IvFluidChartDto>> GetIvFluidChartAsync(int labId, int patientId)
            => _patientRepository.GetIvFluidChartAsync(labId, patientId);

        public Task<IEnumerable<IvFluidAdministrationDto>> GetIvFluidAdministrationAsync(int labId, int patientId, int ivFluidChartId)
            => _patientRepository.GetIvFluidAdministrationAsync(labId, patientId, ivFluidChartId);

        public Task<int> AddPatientIvFluidAdministrationAsync(IvFluidAdministrationDto addsDto)
            => _patientRepository.AddPatientIvFluidAdministrationAsync(addsDto);

        public Task<(int id, string resultMessage)> DeleteIvFluidChartAsync(int id)
            => _patientRepository.DeleteIvFluidChartAsync(id);

        public Task<int> DeleteIvFluidAdministrationAsync(int id)
            => _patientRepository.DeleteIvFluidAdministrationAsync(id);

        // -------------------------
        // Fluid Balance
        // -------------------------
        public Task<int> AddFluidBalanceChartsync(FluidBalanceChartDto addsDto)
            => _patientRepository.AddFluidBalanceChartsync(addsDto);

        public Task<FluidBalanceChartDto> GetFluidBalanceChartByIdAsync(int id, int labId)
            => _patientRepository.GetFluidBalanceChartByIdAsync(id, labId);

        public Task<IEnumerable<FluidBalanceChartDto>> GetFluidBalanceChartAsync(int labId, int patientId)
            => _patientRepository.GetFluidBalanceChartAsync(labId, patientId);

        public Task<IEnumerable<FluidBalanceAdministrationDto>> GetFluidBalanceAdministrationAsync(int labId, int patientId, int fluidBalanceChartId)
            => _patientRepository.GetFluidBalanceAdministrationAsync(labId, patientId, fluidBalanceChartId);

        public Task<int> AddPatientFluidBalanceAdministrationAsync(FluidBalanceAdministrationDto addsDto)
            => _patientRepository.AddPatientFluidBalanceAdministrationAsync(addsDto);

        public Task<(int id, string resultMessage)> DeleteFluidBalanceChartAsync(int id)
            => _patientRepository.DeleteFluidBalanceChartAsync(id);

        public Task<int> DeleteFluidBalanceAdministrationAsync(int id)
            => _patientRepository.DeleteFluidBalanceAdministrationAsync(id);

        // -------------------------
        // Neurological
        // -------------------------
        public Task<int> AddNeurologicalChartsync(NeurologicalChartDto addsDto)
            => _patientRepository.AddNeurologicalChartsync(addsDto);

        public Task<NeurologicalChartDto> GetNeurologicalChartByIdAsync(int id, int labId)
            => _patientRepository.GetNeurologicalChartByIdAsync(id, labId);

        public Task<IEnumerable<NeurologicalChartDto>> GetNeurologicalChartAsync(int labId, int patientId)
            => _patientRepository.GetNeurologicalChartAsync(labId, patientId);

        public Task<IEnumerable<NeurologicalAdministrationDto>> GetNeurologicalAdministrationAsync(int labId, int patientId, int neurologicalChartId)
            => _patientRepository.GetNeurologicalAdministrationAsync(labId, patientId, neurologicalChartId);

        public Task<int> AddPatientNeurologicalAdministrationAsync(NeurologicalAdministrationDto addsDto)
            => _patientRepository.AddPatientNeurologicalAdministrationAsync(addsDto);

        public Task<(int id, string resultMessage)> DeleteNeurologicalChartAsync(int id)
            => _patientRepository.DeleteNeurologicalChartAsync(id);

        public Task<int> DeleteNeurologicalAdministrationAsync(int id)
            => _patientRepository.DeleteNeurologicalAdministrationAsync(id);

        // -------------------------
        // Braden Scale
        // -------------------------
        public Task<int> AddBradenAssessmentAsync(BradenDto dto)
            => _patientRepository.AddBradenAssessmentAsync(dto);

        public Task<int> AddBradenAssessmentFollowUpAsync(BradenDto dto)
            => _patientRepository.AddBradenAssessmentFollowUpAsync(dto);

        public Task<IEnumerable<BradenDto>> GetBradenAssessmentsAsync(int labId, int? patientId)
            => _patientRepository.GetBradenAssessmentsAsync(labId, patientId);

        public Task<BradenDto?> GetBradenAssessmentByIdAsync(int labId, int id)
            => _patientRepository.GetBradenAssessmentByIdAsync(labId, id);

        public Task<int> DeleteBradenAssessmentAsync(int id)
            => _patientRepository.DeleteBradenAssessmentAsync(id);

        // -------------------------
        // FRAT (Fall Risk)
        // -------------------------
        public Task<int> AddPatientFallRiskAsync(FallRiskDto dto)
            => _patientRepository.AddPatientFallRiskAsync(dto);

        public Task<IEnumerable<FallRiskDto>> GetPatientFallRisksAsync(int labId, int patientId)
            => _patientRepository.GetPatientFallRisksAsync(labId, patientId);

        public Task<FallRiskDto?> GetPatientFallRiskByIdAsync(int labId, int id)
            => _patientRepository.GetPatientFallRiskByIdAsync(labId, id);

        public Task<int> DeletePatientFallRiskAsync(int id)
            => _patientRepository.DeletePatientFallRiskAsync(id);

        // -------------------------
        // Progress Notes
        // -------------------------
        public Task<int> AddProgressNotesAsync(ProgressNotesDto addsDto)
            => _patientRepository.AddProgressNotesAsync(addsDto);

        public Task<IEnumerable<ProgressNotesDto>> GetProgressNotesAsync(int labId, int patientId)
            => _patientRepository.GetProgressNotesAsync(labId, patientId);

        public Task<int> DeleteProgressNotesAsync(int id)
            => _patientRepository.DeleteProgressNotesAsync(id);

        // -------------------------
        // Food Intake
        // -------------------------
        public Task<int> AddFoodIntakeAsync(FoodIntakeDto dto)
            => _patientRepository.AddFoodIntakeAsync(dto);

        public Task<IEnumerable<FoodIntakeListDto>> GetFoodIntakeListAsync(int labId, int? patientId)
            => _patientRepository.GetFoodIntakeHeadersAsync(labId, patientId);

        public Task<FoodIntakeDto?> GetFoodIntakeByIdAsync(int labId, int id)
            => _patientRepository.GetFoodIntakeByIdAsync(labId, id);

        public Task<int> DeleteFoodIntakeAsync(int id)
            => _patientRepository.DeleteFoodIntakeAsync(id);

        public Task<int> UpdateFoodIntakeAsync(FoodIntakeDto dto)
            => _patientRepository.UpdateFoodIntakeAsync(dto);

        // -------------------------
        // Riskman
        // -------------------------
        public Task<int> AddRiskmanIncidentAsync(RiskmanDto dto)
            => _patientRepository.AddRiskmanIncidentAsync(dto);

        public Task<IEnumerable<RiskmanDto>> GetRiskmanIncidentsAsync(int labId, int? patientId)
            => _patientRepository.GetRiskmanIncidentsAsync(labId, patientId);

        public Task<RiskmanDto?> GetRiskmanIncidentByIdAsync(int labId, int id)
            => _patientRepository.GetRiskmanIncidentByIdAsync(labId, id);

        public Task<int> DeleteRiskmanIncidentAsync(int id)
            => _patientRepository.DeleteRiskmanIncidentAsync(id);

        // -------------------------
        // Clear Data (maintenance)
        // -------------------------
        public Task<IEnumerable<ClearDataDto>> ClearPatientDataAsync(int labId, int patientId)
            => _patientRepository.ClearPatientDataAsync(labId, patientId);

        public Task<IEnumerable<ClearDataDto>> ClearLabDataAsync(int labId)
            => _patientRepository.ClearLabDataAsync(labId);
    }
}
