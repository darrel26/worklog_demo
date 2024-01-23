using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worklog_demo.Data;
using worklog_demo.Models.DTO.Flattening;
using worklog_demo.Models.DTO.Requests;
using worklog_demo.Models.DTO.Responses;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

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
            _context = HttpContext.RequestServices.GetService(typeof(WorklogContext)) as WorklogContext;
            var exisitingWorklog = _context.CreateWorklog(worklog);

            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new WorklogResponse()
                {
                    Errors = errors,
                    Messages = "Failed to add data!",
                    Success = false
                });
            }

            if(exisitingWorklog == false)
            {
                return new JsonResult(new WorklogResponse()
                {
                    Errors = new List<string> {
                        "Internal Server Error!"
                    },
                    Messages = "Internal Server Error!",
                    Success = false
                })
                { StatusCode = 500 };
            }

            return Created("Added", new WorklogResponse()
            {
                Errors = null,
                Messages = "Data successfully added",
                Success = true
            });
        }
    }
}
