using StudentApi.Models.Students;
using StudentApi.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Students
{

    public class DeleteStudentRequest : IRequest<DeleteStudentResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Major { get; set; }

        public float AverageGrade { get; set; }

    }

    public class DeleteStudentResponse
    {
        public bool Success { get; set; }
    }

    public class DeleteStudentHandler : IRequestHandler<DeleteStudentRequest, DeleteStudentResponse>
    {
        private readonly IStudentsService _studentsService;

        public DeleteStudentHandler(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public Task<DeleteStudentResponse> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {

            var student = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Major = request.Major,
                AverageGrade = request.AverageGrade
            };

            var response = new DeleteStudentResponse
            {
                Success = _studentsService.DeleteStudent(student)
            };

            return Task.FromResult(response);
        }
    }
}
