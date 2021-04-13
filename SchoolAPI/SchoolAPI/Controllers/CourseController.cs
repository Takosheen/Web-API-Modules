using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SchoolAPI.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {


            private ILoggerManager _logger;
            private IRepositoryManager _repository;
            private readonly IMapper _mapper;
        public CourseController(ILoggerManager logger, IRepositoryManager repository)
            {
                _logger = logger;
                _repository = repository;
            }
            [HttpGet]
            public IActionResult GetAllCourses()
            {
                try
                {
                    var courses = _repository.Course.GetAllCourses(trackChanges: false);
                    _logger.LogInfo($"Returned all courses from database.");
                    return Ok(courses);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Something went wrong inside GetAllCourses action: {ex.Message}");
                    return StatusCode(500, "Internal server error");
                }
            }
        [HttpGet("{id}")]
        public IActionResult GetCourse(Guid id)
        {
            try
            {
                var organization = _repository.Organization.GetOrganization(id, trackChanges: false); if (organization == null)
                {
                    _logger.LogInfo($"Organization with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var organizationDto = _mapper.Map<CourseDto>(organization);
                    return Ok(organizationDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourse)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}

