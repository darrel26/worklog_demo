using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using worklog_demo.Data;
using worklog_demo.Models;

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
        [ProducesResponseType(200, Type = typeof(TbUser))]
        [SwaggerResponse(204, "No Content")]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<TbUser>> GetUsersItem()
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

    }
}
