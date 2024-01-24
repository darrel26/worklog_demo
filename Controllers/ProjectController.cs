using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using worklog_demo.Data;
using worklog_demo.Models;
using worklog_demo.Models.DTO.Flattening;

namespace worklog_demo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ProjectContext _context;

        public ProjectController(ProjectContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ProjectDTO))]
        [SwaggerResponse(204, "No Content")]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjectsItem()
        {
            _context = HttpContext.RequestServices.GetService(typeof(ProjectContext)) as ProjectContext;
            var projects = _context.GetAllProject();

            if (projects.Count == 0) {
                return NoContent();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(projects);
        }

        [HttpGet("{projectId}")]
        public ActionResult<List<string>> GetUsernameByProjectId(int projectId)
        {
            _context = HttpContext.RequestServices.GetService(typeof(ProjectContext)) as ProjectContext;
            var users = _context.GetUsernameByProjectId(projectId);

            if (users.Count == 0)
            {
                return NoContent();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(users);
        }

    }
}
