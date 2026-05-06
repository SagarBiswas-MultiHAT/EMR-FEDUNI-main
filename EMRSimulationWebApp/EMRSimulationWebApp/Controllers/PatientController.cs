using EMRSimulation.Application.Services;
using EMRSimulation.Domain.Dtos;
using EMRSimulationWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace EMRSimulation.WebApp.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<IActionResult> GetPatientList(int labId)
        {
            IEnumerable<PatientDto> lstPatients;

            lstPatients = await _patientService.GetAllPatientsAsync(labId);
            return PartialView("~/views/patient/_patientList.cshtml", lstPatients);
        }

        public async Task<IActionResult> GetPatientRecord(int labId, int patientId)
        {
            PatientDto patient;

            patient = await _patientService.GetPatientById(patientId, labId);
            return PartialView("~/views/patient/_patientRecord.cshtml", patient);
        }

        public async Task<IActionResult> GetPatientADDS(int labId, int patientId)
        {
            PatientDto patient;

            patient = await _patientService.GetPatientById(patientId, labId);
            return PartialView("~/views/patient/_patientAddsChart.cshtml", patient);
        }

        public async Task<IActionResult> GetPatientIvFluidChartList(int labId, int patientId)
        {
            PatientIvFluidChartViewModel patientIvFluidChartViewModel = new PatientIvFluidChartViewModel();

            IEnumerable<IvFluidChartDto> lstIvFluidChartDto;

            lstIvFluidChartDto = await _patientService.GetIvFluidChartAsync(labId, patientId);
            patientIvFluidChartViewModel.ivFluidChartDtoList = lstIvFluidChartDto;


            return PartialView("~/views/patient/_patientIvFluidChartList.cshtml", patientIvFluidChartViewModel);
        }

        public async Task<IActionResult> GetPatientIvFluidChart(int Id, int labId, int patientId)
        {
            PatientDto patient;
            patient = await _patientService.GetPatientById(patientId, labId);

            PatientIvFluidChartViewModel patientIvFluidChartViewModel = new PatientIvFluidChartViewModel();
            patientIvFluidChartViewModel.patientDto = patient;

            IvFluidChartDto lstIvFluidChartDto;

            lstIvFluidChartDto = await _patientService.GetIvFluidChartByIdAsync(Id, labId);
            patientIvFluidChartViewModel.ivFluidChartDto = lstIvFluidChartDto;

            return PartialView("~/views/patient/_patientIvFluidChart.cshtml", patientIvFluidChartViewModel);
        }
        // ====================== FRAT (Fall Risk Assessment) ======================

        // Load FRAT chart (the form/calculator)
        public async Task<IActionResult> GetPatientFallRiskChart(int labId, int patientId)
        {
            ViewBag.LabId = labId;
            ViewBag.PatientId = patientId;
            return PartialView("~/views/patient/_patientFallRiskChart.cshtml");
        }

        // Save a FRAT record (AJAX POST from the chart page)
        [HttpPost]
        public async Task<IActionResult> AddPatientFallRisk([FromBody] FallRiskDto dto)
        {
            if (dto == null) return BadRequest("No payload.");
            if (dto.PatientId <= 0 || dto.LabId <= 0) return BadRequest("Missing LabId or PatientId.");

            if (dto.AssessedAt == default) dto.AssessedAt = DateTime.UtcNow;

            // Server-side scoring (keeps DB consistent)
            dto.TotalScore =
                dto.RecentFallsScore +
                dto.MedicationsScore +
                dto.PsychologicalScore +
                dto.CognitiveScore;

            dto.RiskLevel = dto.TotalScore >= 16 ? "High"
                        : dto.TotalScore >= 12 ? "Medium"
                        : "Low";

            // Auto high-risk override
            if (dto.AutoCondChange || dto.AutoDizziness || dto.AutoAnaesthetic)
                dto.RiskLevel = "High";

            // If Notes empty, mirror intervention text for list view context
            if (string.IsNullOrWhiteSpace(dto.Notes))
                dto.Notes = dto.InterventionNotes ?? string.Empty;

            var newId = await _patientService.AddPatientFallRiskAsync(dto);

            return Ok(new
            {
                success = true,
                id = newId,
                patientId = dto.PatientId,
                labId = dto.LabId,
                total = dto.TotalScore,
                risk = dto.RiskLevel
            });
        }

        // List saved FRAT entries
        public async Task<IActionResult> GetPatientFallRiskList(int labId, int patientId)
        {
            var items = await _patientService.GetPatientFallRisksAsync(labId, patientId);
            return PartialView("~/views/patient/_patientFallRiskList.cshtml", items);
        }
        // =================== end FRAT (Fall Risk Assessment) =====================


        public async Task<IActionResult> AddPatientADDS([FromBody] AddsDto addsDto)
        {
            int result = await _patientService.AddPatientAddsAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> AddPatientIvFluidAdministration([FromBody] IvFluidAdministrationDto addsDto)
        {
            int result = await _patientService.AddPatientIvFluidAdministrationAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> GetIvFluidAdministration(int labId, int patientId, int ivFluidChartId)
        {
            IEnumerable<IvFluidAdministrationDto> lstPatients;

            lstPatients = await _patientService.GetIvFluidAdministrationAsync(labId, patientId, ivFluidChartId);

            return PartialView("~/views/patient/_patientIvFluidChartAdminList.cshtml", lstPatients);
        }

        public async Task<IActionResult> DeleteIvFluidAdministration(int Id)
        {
            int result = await _patientService.DeleteIvFluidAdministrationAsync(Id);
            return Ok(result);
        }


        //update neurological and fluid 
        public async Task<IActionResult> GetPatientFluidBalanceChartList(int labId, int patientId)
        {
            PatientFluidBalanceChartViewModel patientFluidBalanceChartViewModel = new PatientFluidBalanceChartViewModel();

            IEnumerable<FluidBalanceChartDto> lstFluidBalanceChartDto;

            lstFluidBalanceChartDto = await _patientService.GetFluidBalanceChartAsync(labId, patientId);
            patientFluidBalanceChartViewModel.FluidBalanceChartDtoList = lstFluidBalanceChartDto;

            return PartialView("~/views/patient/_patientFluidBalanceChartList.cshtml", patientFluidBalanceChartViewModel);
        }

        // Add this new action method for the blank form
        public async Task<IActionResult> GetPatientFluidBalanceChartAdd(int labId, int patientId)
        {
            PatientDto patient;
            patient = await _patientService.GetPatientById(patientId, labId);

            PatientFluidBalanceChartViewModel patientFluidBalanceChartViewModel = new PatientFluidBalanceChartViewModel();
            patientFluidBalanceChartViewModel.patientDto = patient;

            // Create a new empty DTO for the form
            patientFluidBalanceChartViewModel.FluidBalanceChartDto = new FluidBalanceChartDto();
            patientFluidBalanceChartViewModel.FluidBalanceChartDto.LabId = labId;
            patientFluidBalanceChartViewModel.FluidBalanceChartDto.PatientId = patientId;

            return PartialView("~/views/patient/_patientFluidBalanceChartAdd.cshtml", patientFluidBalanceChartViewModel);
        }

        public async Task<IActionResult> GetPatientFluidBalanceChart(int Id, int labId, int patientId)
        {
            PatientDto patient;
            patient = await _patientService.GetPatientById(patientId, labId);

            PatientFluidBalanceChartViewModel patientFluidBalanceChartViewModel = new PatientFluidBalanceChartViewModel();
            patientFluidBalanceChartViewModel.patientDto = patient;

            FluidBalanceChartDto lstFluidBalanceChartDto;

            lstFluidBalanceChartDto = await _patientService.GetFluidBalanceChartByIdAsync(Id, labId);
            patientFluidBalanceChartViewModel.FluidBalanceChartDto = lstFluidBalanceChartDto;

            return PartialView("~/views/patient/_patientFluidBalanceChart.cshtml", patientFluidBalanceChartViewModel);
        }

        public async Task<IActionResult> AddPatientFluidBalanceAdministration([FromBody] FluidBalanceAdministrationDto addsDto)
        {
            int result = await _patientService.AddPatientFluidBalanceAdministrationAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> GetFluidBalanceAdministration(int labId, int patientId, int fluidBalanceChartId)
        {
            IEnumerable<FluidBalanceAdministrationDto> lstPatients;

            lstPatients = await _patientService.GetFluidBalanceAdministrationAsync(labId, patientId, fluidBalanceChartId);

            return PartialView("~/views/patient/_patientFluidBalanceChartAdminList.cshtml", lstPatients);
        }

        public async Task<IActionResult> DeleteFluidBalanceAdministration(int Id)
        {
            int result = await _patientService.DeleteFluidBalanceAdministrationAsync(Id);
            return Ok(result);
        }



        public async Task<IActionResult> GetPatientNeurologicalChartList(int labId, int patientId)
        {
            PatientNeurologicalChartViewModel patientNeurologicalChartViewModel = new PatientNeurologicalChartViewModel();

            IEnumerable<NeurologicalChartDto> lstNeurologicalChartDto;

            lstNeurologicalChartDto = await _patientService.GetNeurologicalChartAsync(labId, patientId);
            patientNeurologicalChartViewModel.neurologicalChartDtoList = lstNeurologicalChartDto;

            return PartialView("~/Views/patient/_patientNeurologicalChartList.cshtml", patientNeurologicalChartViewModel);
        }

        // Add this new action method for the blank form
        public async Task<IActionResult> GetPatientNeurologicalChartAdd(int labId, int patientId)
        {
            PatientDto patient;
            patient = await _patientService.GetPatientById(patientId, labId);

            PatientNeurologicalChartViewModel patientNeurologicalChartViewModel = new PatientNeurologicalChartViewModel();
            patientNeurologicalChartViewModel.patientDto = patient;

            // Create a new empty DTO for the form
            patientNeurologicalChartViewModel.neurologicalChartDto = new NeurologicalChartDto();
            patientNeurologicalChartViewModel.neurologicalChartDto.LabId = labId;
            patientNeurologicalChartViewModel.neurologicalChartDto.PatientId = patientId;

            return PartialView("~/views/patient/_patientNeurologicalChartAdd.cshtml", patientNeurologicalChartViewModel);
        }

        public async Task<IActionResult> GetPatientNeurologicalChart(int Id, int labId, int patientId)
        {
            PatientDto patient;
            patient = await _patientService.GetPatientById(patientId, labId);

            PatientNeurologicalChartViewModel patientNeurologicalChartViewModel = new PatientNeurologicalChartViewModel();
            patientNeurologicalChartViewModel.patientDto = patient;

            NeurologicalChartDto lstNeurologicalChartDto;

            lstNeurologicalChartDto = await _patientService.GetNeurologicalChartByIdAsync(Id, labId);
            patientNeurologicalChartViewModel.neurologicalChartDto = lstNeurologicalChartDto;

            return PartialView("~/views/patient/_patientNeurologicalChart.cshtml", patientNeurologicalChartViewModel);
        }

        public async Task<IActionResult> AddPatientNeurologicalAdministration([FromBody] NeurologicalAdministrationDto addsDto)
        {
            int result = await _patientService.AddPatientNeurologicalAdministrationAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> GetNeurologicalAdministration(int labId, int patientId, int neurologicalChartId)
        {
            IEnumerable<NeurologicalAdministrationDto> lstPatients;

            lstPatients = await _patientService.GetNeurologicalAdministrationAsync(labId, patientId, neurologicalChartId);

            return PartialView("~/views/patient/_patientNeurologicalChartAdminList.cshtml", lstPatients);
        }

        public async Task<IActionResult> DeleteNeurologicalAdministration(int Id)
        {
            int result = await _patientService.DeleteNeurologicalAdministrationAsync(Id);
            return Ok(result);
        }


        public async Task<IActionResult> GetPatientADDSList(int labId, int patientId)
        {
            PatientAddsListViewModel patientAddsListViewModel = new PatientAddsListViewModel();

            IEnumerable<AddsDto> lstAddsDto;
            lstAddsDto = await _patientService.GetPatientAdds(labId, patientId);

            patientAddsListViewModel.AddsDtoList = lstAddsDto;

            return PartialView("~/views/patient/_patientAddsChartList.cshtml", patientAddsListViewModel);
        }

        public async Task<IActionResult> DeletePatientADDS(int Id)
        {
            int result = await _patientService.DeletePatientAddsAsync(Id);
            return Ok(result);
        }

        public async Task<IActionResult> GetPatientMedicationPrnList(int labId, int patientId)
        {
            PatientMedicationPrnListViewModel patientMedicationPrnListViewModel = new PatientMedicationPrnListViewModel();

            IEnumerable<MedicationPrnChartDto> lstMedicationPrnChartDto;
            lstMedicationPrnChartDto = await _patientService.GetMedicationPrnChartAsync(labId, patientId);

            patientMedicationPrnListViewModel.MedicationPrnChartDtoList = lstMedicationPrnChartDto;

            return PartialView("~/views/patient/_patientMedicationPrnList.cshtml", patientMedicationPrnListViewModel);
        }

        public async Task<IActionResult> GetPatientMedicationPrn(int Id, int labId, int patientId)
        {
            PatientDto patient;
            patient = await _patientService.GetPatientById(patientId, labId);

            PatientMedicationPrnListViewModel patientMedicationPrnListViewModel = new PatientMedicationPrnListViewModel();
            patientMedicationPrnListViewModel.patientDto = patient;

            MedicationPrnChartDto lstMedicationPrnChartDto;
            lstMedicationPrnChartDto = await _patientService.GetMedicationPrnChartByIdAsync(Id, labId);

            patientMedicationPrnListViewModel.MedicationPrnChartDto = lstMedicationPrnChartDto;

            return PartialView("~/views/patient/_patientMedicationPrn.cshtml", patientMedicationPrnListViewModel);
        }

        public async Task<IActionResult> AddPatientMedicationPrnAdministration([FromBody] MedicationAdministrationPrnDto addsDto)
        {
            int result = await _patientService.AddPatientMedicationPrnAdministrationAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> GetPatientMedicationPrnAdministration(int labId, int patientId, int patientMedicationChartId)
        {
            IEnumerable<MedicationAdministrationPrnDto> lstPatients;

            lstPatients = await _patientService.GetPatientMedicationPrnAdministrationAsync(labId, patientId, patientMedicationChartId);

            return PartialView("~/views/patient/_patientMedicationPrnAdminList.cshtml", lstPatients);
        }

        public async Task<IActionResult> DeletePatientMedicationPrnAdministration(int Id)
        {
            int result = await _patientService.DeleteMedicationPrnAdministrationAsync(Id);
            return Ok(result);
        }

        public async Task<IActionResult> GetPatientMedicationRegularList(int labId, int patientId)
        {
            PatientMedicationRegularListViewModel patientMedicationRegularListViewModel = new PatientMedicationRegularListViewModel();

            IEnumerable<MedicationRegularChartDto> lstMedicationRegularChartDto;
            lstMedicationRegularChartDto = await _patientService.GetMedicationRegularChartAsync(labId, patientId);

            patientMedicationRegularListViewModel.MedicationRegularChartDtoList = lstMedicationRegularChartDto;

            return PartialView("~/views/patient/_patientMedicationRegularList.cshtml", patientMedicationRegularListViewModel);
        }

        public async Task<IActionResult> GetPatientMedicationRegular(int Id, int labId, int patientId)
        {
            PatientDto patient;
            patient = await _patientService.GetPatientById(patientId, labId);

            PatientMedicationRegularListViewModel patientMedicationRegularListViewModel = new PatientMedicationRegularListViewModel();
            patientMedicationRegularListViewModel.patientDto = patient;

            MedicationRegularChartDto lstMedicationRegularChartDto;
            lstMedicationRegularChartDto = await _patientService.GetMedicationRegularChartByIdAsync(Id, labId);

            patientMedicationRegularListViewModel.MedicationRegularChartDto = lstMedicationRegularChartDto;

            return PartialView("~/views/patient/_patientMedicationRegular.cshtml", patientMedicationRegularListViewModel);
        }

        public async Task<IActionResult> AddPatientMedicationRegularAdministration([FromBody] MedicationAdministrationRegularDto addsDto)
        {
            int result = await _patientService.AddPatientMedicationRegularAdministrationAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> GetPatientMedicationRegularAdministration(int labId, int patientId, int patientMedicationChartId)
        {
            IEnumerable<MedicationAdministrationRegularDto> lstPatients;

            lstPatients = await _patientService.GetPatientMedicationRegularAdministrationAsync(labId, patientId, patientMedicationChartId);

            return PartialView("~/views/patient/_patientMedicationRegularAdminList.cshtml", lstPatients);
        }

        public async Task<IActionResult> DeletePatientMedicationRegularAdministration(int Id)
        {
            int result = await _patientService.DeleteMedicationRegularAdministrationAsync(Id);
            return Ok(result);
        }

        public async Task<IActionResult> GetProgressNoteList(int labId, int patientId)
        {
            IEnumerable<ProgressNotesDto> lstPatients;

            lstPatients = await _patientService.GetProgressNotesAsync(labId, patientId);
            return PartialView("~/views/patient/_patientProgressNoteList.cshtml", lstPatients);
        }

        public async Task<IActionResult> GetProgressNote()
        {
            return PartialView("~/views/patient/_patientProgressNote.cshtml");
        }

        public async Task<IActionResult> AddProgressNote([FromBody] ProgressNotesDto addsDto)
        {
            if (User.HasClaim(c => c.Value == "supervisor"))
            {
                addsDto.NotesFrom = "supervisor";
            }
            else if (User.HasClaim(c => c.Value == "student"))
            {
                addsDto.NotesFrom = "student";
            }

            int result = await _patientService.AddProgressNotesAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> DeleteProgressNote(int Id)
        {
            int result = await _patientService.DeleteProgressNotesAsync(Id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddRiskmanIncident([FromBody] RiskmanDto dto)
        {
            int result = await _patientService.AddRiskmanIncidentAsync(dto);
            return Ok(result);
        }
        public IActionResult GetRiskmanIncident()
        {
            return PartialView("~/views/patient/_riskmanAdd.cshtml");
        }

        public async Task<IActionResult> GetRiskmanIncidentList(int labId, int? patientId = null)
        {
            var list = await _patientService.GetRiskmanIncidentsAsync(labId, patientId);


            // pass ids to the partial so JS can use them
            ViewBag.LabId = labId;
            ViewBag.PatientId = patientId; // can be null
            return PartialView("~/Views/Patient/_riskmanList.cshtml", list);
        }

        public async Task<IActionResult> DeleteRiskmanIncident(int id)
        {
            int result = await _patientService.DeleteRiskmanIncidentAsync(id);
            return Ok(result);
        }
        public async Task<IActionResult> ViewRiskmanIncident(int id, int labId)
        {
            var dto = await _patientService.GetRiskmanIncidentByIdAsync(labId, id);

            ViewBag.LabId = labId;

            if (dto == null)
            {
                // super simple not-found response as a partial
                return Content("<div style='padding:12px;'>Incident not found. <a href='javascript:void(0)' onclick=\"$.get('/Patient/GetRiskmanIncidentList',{labId:" + labId + "}, function(html){ $('#content-area').html(html); });\">Back to list</a></div>", "text/html");
            }

            return PartialView("~/Views/Patient/_riskmanView.cshtml", dto);
        }

        public async Task<IActionResult> GetBradenAdd(int labId, int patientId)
        {
            var patient = await _patientService.GetPatientById(patientId, labId);
            if (patient == null)
            {
                return Content("<div class='p-3 text-danger'>Patient not found.</div>", "text/html");
            }

            var vm = new BradenAddViewModel
            {
                LabId = labId,
                PatientId = patient.Id,
                UriNumber = patient.UriNumber,
                Surname = patient.LastName,
                GivenNames = patient.FirstName, 
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender
            };

            return PartialView("~/Views/Patient/_BradenAdd.cshtml", vm);
        }

        // GET: /Patient/GetBradenFollowUpAdd?labId=1&patientId=2
        public async Task<IActionResult> GetBradenFollowUpAdd(int labId, int patientId)
        {
           
            var patient = await _patientService.GetPatientById(patientId, labId);
            if (patient == null)
            {
                return Content("<div class='p-3 text-danger'>Patient not found.</div>", "text/html");
            }

            var vm = new BradenAddViewModel
            {
                LabId = labId,
                PatientId = patient.Id,
               
            };

            return PartialView("~/Views/Patient/_BradenFollowUpAdd.cshtml", vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddBradenAssessment([FromBody] BradenDto dto)
        {
            int result = await _patientService.AddBradenAssessmentAsync(dto);
            return Ok(result);
        }
        public async Task<IActionResult> GetBradenAssessmentList(int labId, int? patientId = null)
        {
            var list = await _patientService.GetBradenAssessmentsAsync(labId, patientId);

            ViewBag.LabId = labId;
            ViewBag.PatientId = patientId; // can be null
            return PartialView("~/Views/Patient/_BradenList.cshtml", list);
        }

        [HttpPost]
        public async Task<IActionResult> AddBradenAssessmentFollowUp([FromBody] BradenDto dto)
        {
            int result = await _patientService.AddBradenAssessmentFollowUpAsync(dto);
            return Ok(result); // -1 => no initial exists, >0 => new Id
        }


        public async Task<IActionResult> DeleteBradenAssessment(int id)
        {
            int result = await _patientService.DeleteBradenAssessmentAsync(id);
            return Ok(result);
        }


        // GET: /Patient/ViewBradenAssessment?id=123&labId=1
        public async Task<IActionResult> ViewBradenAssessment(int labId, int id)
        {
            var dto = await _patientService.GetBradenAssessmentByIdAsync(labId, id);
            if (dto == null) return NotFound();

            ViewBag.LabId = labId;            // for Back button reload
                                             

            return PartialView("_BradenView", dto);
        }
        // GET: /Patient/GetFoodIntakeAdd?labId=1&patientId=5
        [HttpGet]
        public IActionResult GetFoodIntakeAdd(int labId, int patientId)
        {
            var vm = new FoodIntakeAddViewModel
            {
                LabId = labId,
                PatientId = patientId,
                Date = DateTime.Today
            };
            return PartialView("~/Views/Patient/_FoodIntakeAdd.cshtml", vm);
        }

        // PatientController.cs

        [HttpPost]
        public async Task<IActionResult> AddFoodIntake([FromBody] FoodIntakeDto dto)
        {
            var id = await _patientService.AddFoodIntakeAsync(dto);
            return Ok(id); // >0 on success
        }

        // GET: /Patient/GetFoodIntakeList?labId=1&patientId=5
        [HttpGet]
        public async Task<IActionResult> GetFoodIntakeList(int labId, int? patientId = null)
        {
            var list = await _patientService.GetFoodIntakeListAsync(labId, patientId);
            ViewBag.LabId = labId;
            ViewBag.PatientId = patientId;
            return PartialView("~/Views/Patient/_FoodIntakeList.cshtml", list);
        }

        // GET: /Patient/ViewFoodIntake?labId=1&id=10
        [HttpGet]
        public async Task<IActionResult> ViewFoodIntake(int labId, int id)
        {
            var dto = await _patientService.GetFoodIntakeByIdAsync(labId, id);
            if (dto == null) return NotFound();

            ViewBag.LabId = labId;
            ViewBag.PatientId = dto.PatientId;
            return PartialView("~/Views/Patient/_FoodIntakeView.cshtml", dto);
        }

        // GET: /Patient/DeleteFoodIntake?id=10
        [HttpGet]
        public async Task<IActionResult> DeleteFoodIntake(int id)
        {
            var rows = await _patientService.DeleteFoodIntakeAsync(id);
            return Ok(rows);
        }

        // GET: /Patient/GetFoodIntakeEdit?labId=1&id=10
        [HttpGet]
        public async Task<IActionResult> GetFoodIntakeEdit(int labId, int id)
        {
            var dto = await _patientService.GetFoodIntakeByIdAsync(labId, id);
            if (dto == null) return NotFound();
            return PartialView("~/Views/Patient/_FoodIntakeEdit.cshtml", dto); 
        }

        // POST: /Patient/UpdateFoodIntake
        [HttpPost]
        public async Task<IActionResult> UpdateFoodIntake([FromBody] FoodIntakeDto dto)
        {
            var rows = await _patientService.UpdateFoodIntakeAsync(dto);
            return Ok(rows); // 1=success, 0=fail
        }

    }

}
