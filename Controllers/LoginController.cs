using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worklog_demo.Data;
using worklog_demo.Models.DTO.Responses;
using worklog_demo.Models.DTO.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace worklog_demo.Controllers
{
    [Route("[Controller]")]
    public class LoginController : ControllerBase
    {
        private LoginContext _context;

        public LoginController(LoginContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(UsersResponse))]
        [SwaggerResponse(404, "Not Found")]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<LoginResponse>> Login([FromBody] LoginRequest login)
        {
            _context = HttpContext.RequestServices.GetService(typeof(LoginContext)) as LoginContext;
            var existingUser = _context.Login(login);


            if (existingUser == null)
            {
                return BadRequest(new LoginResponse()
                    {
                        Errors = new List<string>() {
                            "Invalid login request"
                        },
                        Success = false
                    });
            }

            return Ok(new LoginResponse { 
                Success = true,
                Errors = null,
                messages = existingUser
            });
        }
    }
}
