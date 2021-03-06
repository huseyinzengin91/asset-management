﻿using Business.Abstract;
using Entities.Dtos.ProjectUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/project-user")]
    public class ProjectUserController : BaseApiController
    {
        IProjectUserService _projectUserService;
        public ProjectUserController(IProjectUserService projectUserService, IHttpContextAccessor _context) : base(_context)
        {
            _projectUserService = projectUserService;
        }

        [SwaggerResponse(200, type: typeof(CreateResponse))]
        [HttpPost("add")]
        public IActionResult Add([FromBody] ProjectUserAddDto value)
        {
            var addResult = _projectUserService.Add(value, base._Id.Value);
            
            if (!addResult.Success)
                return Error(addResult.Message, addResult.Code);

            return Success(new CreateResponse { Id = addResult.Data });
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] ProjectUserDeleteDto value)
        {
            var deleteResult = _projectUserService.Delete(value, base._Id.Value);

            if (!deleteResult.Success)
                return Error(deleteResult.Message, deleteResult.Code);

            return Success();
        }
    }
}