using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worklog_demo.Data;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace worklog_demo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ProducesResponseType(400)]
    public class WorklogController : ControllerBase
    {
        private WorklogContext worklogContext;
    }
}
