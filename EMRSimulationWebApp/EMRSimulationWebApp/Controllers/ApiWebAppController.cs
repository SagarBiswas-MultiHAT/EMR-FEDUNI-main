using EMRSimulation.Application.Services;
using EMRSimulation.Domain.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace EMRSimulationWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiWebAppController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public ApiWebAppController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("authenticatelabasync")]
        public async Task<ActionResult> AuthenticateLabAsync([FromBody] dynamic jsonPostData)
        {
            // Deserialize dynamic data to a strongly-typed object
            string jsonString = Convert.ToString(jsonPostData);
            var loginRequest = JsonConvert.DeserializeObject<LoginRequest>(jsonString);

            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Invalid login data");
            }

            var (labId, labName, resultMessage) = await _loginService.AuthenticateLabAsync(loginRequest);

            if (resultMessage == "Valid")
            {
                // Login success
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "student"),
                    new Claim("Role", "student"),
                    new Claim("labId", "" + labId)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Key property for persistence
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1) // Optional: Set a specific expiration time
                    //ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30) // Optional: Set a specific expiration time
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Return the result as JSON automatically
                return Ok(new { labId = labId, labName = labName, resultMessage = resultMessage });
            }
            else
            {
                return Ok(new { labId = 0, resultMessage = resultMessage });
            }
        }

        [HttpPost("authenticatesupervisorasync")]
        public async Task<ActionResult> AuthenticateSupervisorAsync([FromBody] dynamic jsonPostData)
        {
            // Deserialize dynamic data to a strongly-typed object
            string jsonString = Convert.ToString(jsonPostData);
            var loginRequest = JsonConvert.DeserializeObject<LoginRequest>(jsonString);
            
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Invalid login data");
            }

            var (labId, labName, supervisorId, supervisorName, resultMessage) = await _loginService.AuthenticateSupervisorAsync(loginRequest);
            
            if (resultMessage == "Valid")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "supervisor"),
                    new Claim("Role", "supervisor"),
                    new Claim("labId", "" + labId)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Key property for persistence
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1) // Optional: Set a specific expiration time
                    //ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30) // Optional: Set a specific expiration time
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Return the result as JSON automatically
                return Ok(new { labId = labId, labName = labName, supervisorId = supervisorId, supervisorName = supervisorName, resultMessage = resultMessage });
            }
            else
            {
                return Ok(new { supervisorId = 0, resultMessage = resultMessage });
            }

        }
    }
}
