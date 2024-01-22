using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using worklog_demo.Data;
using worklog_demo.Models;

namespace worklog_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ProjectContext _context;

        public ProjectController(ProjectContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectItem>> GetMovieItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(ProjectContext)) as ProjectContext;
            return _context.GetAllProject();
        }
    }
}
