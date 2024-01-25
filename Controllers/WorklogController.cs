using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using worklog_demo.Data;
using worklog_demo.Models.DTO.Requests;
using worklog_demo.Models.DTO.Responses;

namespace worklog_demo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ProducesResponseType(400)]
    public class WorklogController : ControllerBase
    {
        private WorklogContext _context;

        public WorklogController(WorklogContext worklogContext)
        {
            this._context = worklogContext;
        }

        [HttpPost]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(500, "Internal Server Error")]
        public ActionResult<WorklogResponse> CreateWorklog([FromBody] WorklogRequest worklog)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => $"{x.Key} : {x.Value.Errors}")
                    .ToList();

                Log.Error("{HttpMethod} {Route} | {@errors}", HttpContext.Request.Method, HttpContext.Request.Path, errors);

                return BadRequest(new WorklogResponse()
                {
                    Errors = errors,
                    Messages = "Failed to add data!",
                    Success = false
                });
            }

            _context = HttpContext.RequestServices.GetService(typeof(WorklogContext)) as WorklogContext;
            var exisitingWorklog = _context.CreateWorklog(worklog);

            if(exisitingWorklog == "Failed to add data!")
            {
                Log.Error("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, exisitingWorklog);

                return new JsonResult(new WorklogResponse()
                {
                    Errors = new List<string> {
                        exisitingWorklog
                    },
                    Messages = "Internal Server Error!",
                    Success = false
                })
                { StatusCode = 500 };
            } else if(exisitingWorklog == "Data successfully added!")
            {
                Log.Information("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, exisitingWorklog);

                return Created("Added", new WorklogResponse()
                {
                    Errors = null,
                    Messages = "Data successfully added",
                    Success = true
                });
            }

            Log.Error("{HttpMethod} {Route} | {@existingWorklog}", HttpContext.Request.Method, HttpContext.Request.Path, exisitingWorklog);

            return BadRequest(new WorklogResponse()
            {
                Errors = new List<string> {
                        exisitingWorklog
                    },
                Messages = "Internal Server Error!",
                Success = false
            });
        }
    }
}
