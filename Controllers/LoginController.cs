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
        [ProducesResponseType(200, Type = typeof(LoginResponse))]
        [SwaggerResponse(401, "Invalid Credentials")]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<LoginResponse>> Login([FromBody] LoginRequest login)
        {
            _context = HttpContext.RequestServices.GetService(typeof(LoginContext)) as LoginContext;
            var existingUser = _context.Login(login);

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (existingUser.Username == null && existingUser.FullName == null)
            {
                return new JsonResult(new LoginResponse()
                {
                    messages = new UsersResponse()
                    {
                        UserId = 401,
                        FullName = "Invalid Credentials",
                        Username = "Invalid Credentials",
                    },
                    Errors = new List<string>() {
                            "Invalid login request"
                        },
                    Success = false
                })
                { StatusCode = 401 };
            }

            return Ok(new LoginResponse { 
                Success = true,
                Errors = null,
                messages = existingUser
            });
        }
    }
}
