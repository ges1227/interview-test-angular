using StudentApi.Models.Students;
using StudentApi.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Students
{

    public class AddStudentRequest : IRequest<AddStudentResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Major { get; set; }

        public float AverageGrade { get; set; }

    }

    public class AddStudentResponse
    {
        public bool Success { get; set; }
    }

    public class AddStudentHandler : IRequestHandler<AddStudentRequest, AddStudentResponse>
    {
        private readonly IStudentsService _studentsService;

        public AddStudentHandler(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public Task<AddStudentResponse> Handle(AddStudentRequest request, CancellationToken cancellationToken)
        {

            var student = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Major = request.Major,
                AverageGrade = request.AverageGrade
            };

            var response = new AddStudentResponse
            {
                Success = _studentsService.AddStudent(student)
            };

            return Task.FromResult(response);
        }
    }
}
