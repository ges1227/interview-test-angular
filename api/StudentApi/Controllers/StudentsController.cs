using StudentApi.Mediatr.Students;
using StudentApi.Models.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private IMediator mediator;

        /// <summary>
        /// Gets the Mediator object.
        /// </summary>
        protected IMediator Mediator => mediator ??= (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator))!;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the current students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            var reponse = await Mediator.Send(new GetStudentsRequest());

            return reponse.Students;
        }

        [HttpPost]
        public async Task<bool> AddStudent([FromBody] AddStudentRequest request){
            if(request == null){
                return false;
            }

            var response = await Mediator.Send(request);

            return response.Success;
        }


        [HttpDelete]
        public async Task<bool> DeleteStudent([FromBody] DeleteStudentRequest request){
            
            if(request == null){
                return false;
            }

            var response = await Mediator.Send(request);

            return response.Success;
        }
    }
}
