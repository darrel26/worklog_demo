using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using worklog_demo.Data;
using worklog_demo.Models;
using worklog_demo.Models.DTO.Responses;

namespace worklog_demo.Controllers
{
    [Route("[controller]")]
    [ProducesResponseType(200, Type = typeof(TbUser))]
    [ProducesResponseType(400)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(UsersResponse))]
        [SwaggerResponse(204, "No Content")]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<UsersResponse>> GetUsersItem()
        {
            _context = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            var data = _context.GetAllUsers();

            if(data.Count == 0)
            {
                return NoContent();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UsersResponse))]
        [SwaggerResponse(404, "Not Found")]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<UsersResponse>> GetSpecificUser(int id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            var user = _context.GetSpecificUser(id);
            if (user == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpGet("details/{id}")]
        [ProducesResponseType(200, Type = typeof(UserDetailResponse))]
        [SwaggerResponse(404, "Not Found")]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<UserDetailResponse>> GetUserDetail(int id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            var user = _context.GetUserDetail(id);
            if(user == null)
            {
                return NotFound();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(user);
        }
    }
}
