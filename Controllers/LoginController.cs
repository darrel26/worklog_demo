﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using worklog_demo.Data;
using worklog_demo.Models.DTO.Responses;
using worklog_demo.Models.DTO.Requests;
using Swashbuckle.AspNetCore.Annotations;
using Serilog;
using System.Linq;
using Sentry;
using System;

namespace worklog_demo.Controllers
{
    [Route("[Controller]")]
    public class LoginController : ControllerBase
    {
        private LoginContext _context;

        public LoginController(LoginContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(LoginResponse))]
        [SwaggerResponse(401, "Invalid Credentials")]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<LoginResponse>> Login([FromBody] LoginRequest login)
        {

            LoginResponse response = new LoginResponse
            {
                Success = true,
                Errors = null,
                messages = null
            };

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => $"{x.Key} : {x.Value.Errors}")
                    .ToList();

                response.Success = false;
                response.Errors = errors;

                Log.Error("{HttpMethod} {Route} | {@ErrorCause}", HttpContext.Request.Method, HttpContext.Request.Path, response.Errors);

                return BadRequest(response);
            }

            _context = HttpContext.RequestServices.GetService(typeof(LoginContext)) as LoginContext;
            var existingUser = _context.Login(login);

            if (existingUser.Username == null && existingUser.FullName == null)
            {
                response.Errors = new List<string>()
                {
                    "Invalid Login Request!"
                };

                response.messages = new UsersResponse()
                {
                    UserId = 401,
                    FullName = "Invalid Credentials",
                    Username = "Invalid Credentials",
                };

                response.Success = false;

                Log.Warning("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, response);

                return new JsonResult(response)
                { StatusCode = 401 };
            }

            response.messages = existingUser;

            Log.Information("{HttpMethod} {Route} | {@response}", HttpContext.Request.Method, HttpContext.Request.Path, response);

            return Ok(response);
        }
    }
}
