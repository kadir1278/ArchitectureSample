using BusinessLayer.Abstract;
using EntityLayer.Dto.ProjectOwner;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectOwnerController : ControllerBase
    {
        private readonly IProjectOwnerService _projectOwnerService;

        public ProjectOwnerController(IProjectOwnerService projectOwnerService)
        {
            _projectOwnerService = projectOwnerService;
        }

        [HttpGet("list-project-owner")]
        public IActionResult GetList()
        {
            try
            {
                var result = _projectOwnerService.GetProjectOwnerCollection();
                if (!result.IsSuccess) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("add-project-owner")]
        public IActionResult Add(ProjectOwnerAddDto model)
        {
            try
            {
                var result = _projectOwnerService.AddProjectOwner(model);
                if (!result.IsSuccess) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
