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
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbUser>> GetMovieItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            return _context.GetAllUsers();
        }

    }
}
