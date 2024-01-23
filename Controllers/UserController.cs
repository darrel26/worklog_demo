using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using worklog_demo.Data;
using worklog_demo.Models;
using worklog_demo.Models.DTO.Flattening;
using worklog_demo.Models.DTO.Responses;

namespace worklog_demo.Controllers
{
    [Route("[controller]")]
    [ProducesResponseType(400)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private UserContext _userContext;
        private ProjectContext _projectsContext;
        private WorklogContext _worklogsContext;

        public UserController(IMapper mapper, UserContext userContext, ProjectContext projectsContext, WorklogContext worklogsContext)
        {
            this._mapper = mapper;
            this._userContext = userContext;
            this._projectsContext = projectsContext;
            this._worklogsContext = worklogsContext;
        }


        [HttpGet]
        [SwaggerResponse(204, "No Content")]
        public ActionResult<IEnumerable<UsersResponse>> GetUsersItem()
        {
            _userContext = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            var data = _userContext.GetAllUsers();

            if (data.Count == 0)
            {
                return NoContent();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UsersResponse))]
        [SwaggerResponse(404, "Not Found")]
        public ActionResult<IEnumerable<UsersResponse>> GetSpecificUser(int id)
        {
            _userContext = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            var user = _userContext.GetSpecificUser(id);
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
        [ProducesResponseType(200, Type = typeof(UserDetailsDTO))]
        [SwaggerResponse(404, "Not Found")]
        public ActionResult<IEnumerable<UserDetailsDTO>> GetUserDetail(int id)
        {
            _userContext = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            _projectsContext = HttpContext.RequestServices.GetService(typeof(ProjectContext)) as ProjectContext;
            _worklogsContext = HttpContext.RequestServices.GetService(typeof(WorklogContext)) as WorklogContext;

            var user = _userContext.GetUserDetail(id);
            var projects = _projectsContext.GetProjectForSpecificUser(id);
            var worklogs = _mapper.Map<List<WorklogDTO>>(_worklogsContext.GetWorklogsByUserId(id));


            if (user == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(new UserDetailsDTO()
            {
                UserId = user.UserId,
                Username = user.Username,
                FullName = user.FullName,
                Projects = projects,
                Worklogs = worklogs

            });
        }
    }
}
