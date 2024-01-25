using Microsoft.AspNetCore.Mvc;
using Serilog;
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
                Log.Information("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, projects);
                return NoContent();
            }

            if(!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => $"{x.Key} : {x.Value.Errors}")
                    .ToList();

                Log.Error("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, errors);

                return BadRequest(errors);
            }

            Log.Information("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, projects);
            return Ok(projects);
        }

        [HttpGet("{projectId}")]
        public ActionResult<List<string>> GetUsernameByProjectId(int projectId)
        {
            _context = HttpContext.RequestServices.GetService(typeof(ProjectContext)) as ProjectContext;
            var users = _context.GetUsernameByProjectId(projectId);

            if (users.Count == 0)
            {
                Log.Information("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, users);

                return NoContent();
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => $"{x.Key} : {x.Value.Errors}")
                    .ToList();

                Log.Error("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, errors);

                return BadRequest(errors);
            }

            Log.Information("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, users);

            return Ok(users);
        }

    }
}
