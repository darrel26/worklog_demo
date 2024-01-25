using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using worklog_demo.Data;
using worklog_demo.Models.DTO.Responses;
using worklog_demo.Models.DTO.Requests;
using Swashbuckle.AspNetCore.Annotations;
using Serilog;
using System.Linq;
using Sentry;

namespace worklog_demo.Controllers
{
    [Route("[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IHub _sentryHub;

        private LoginContext _context;

        public LoginController(IHub sentryHub, LoginContext context)
        {
            _sentryHub = sentryHub;
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(LoginResponse))]
        [SwaggerResponse(401, "Invalid Credentials")]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<LoginResponse>> Login([FromBody] LoginRequest login)
        {
            var childSpan = _sentryHub.GetSpan()?.StartChild("login-sentry-work");

            LoginResponse response = new LoginResponse
            {
                Success = true,
                Errors = null,
                messages = null
            };

            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => $"{x.Key} : {x.Value.Errors}")
                        .ToList();

                    response.Success = false;
                    response.Errors = errors;

                    Log.Error("{HttpMethod} {Route} | {@ErrorCause}", HttpContext.Request.Method, HttpContext.Request.Path, response.Errors);

                    childSpan?.Finish(SpanStatus.Ok);

                    return BadRequest(response);
                }

                _context = HttpContext.RequestServices.GetService(typeof(LoginContext)) as LoginContext;
                var existingUser = _context.Login(login);

                if (existingUser.Username == null && existingUser.FullName == null)
                {
                    response.Errors = new List<string>()
                {
                    "Invalid Login Request!"
                };

                    response.messages = new UsersResponse()
                    {
                        UserId = 401,
                        FullName = "Invalid Credentials",
                        Username = "Invalid Credentials",
                    };

                    response.Success = false;

                    Log.Warning("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, response);

                    childSpan?.Finish(SpanStatus.Ok);

                    return new JsonResult(response)
                    { StatusCode = 401 };
                }

                response.messages = existingUser;

                Log.Information("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, response);

                childSpan?.Finish(SpanStatus.Ok);

                return Ok(response);
            }
            catch (System.Exception e)
            {

                childSpan?.Finish(e);
                throw;
            }
        }
    }
}
