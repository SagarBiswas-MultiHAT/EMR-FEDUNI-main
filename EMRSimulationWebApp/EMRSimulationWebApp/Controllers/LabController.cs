using EMRSimulation.Application.Services;
using EMRSimulation.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace EMRSimulationWebApp.Controllers
{
    [Authorize]
    public class LabController : Controller
    {
        private readonly ILabService _LabService;

        public LabController(ILabService LabService)
        {
            _LabService = LabService;
        }
        public async Task<IActionResult> GetLabRecord(int Id)
        {
            LabDto Lab;

            Lab = await _LabService.GetLabById(Id);
            return PartialView("~/views/Lab/_LabRecord.cshtml", Lab);
        }
    }
}
