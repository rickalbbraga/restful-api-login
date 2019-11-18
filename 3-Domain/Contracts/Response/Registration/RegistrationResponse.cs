using System;

namespace Domain.Contracts.Response.Registration
{
    public class RegistrationResponse
    {
        public Guid StudentId { get; set; }

        public string StudentName { get; set; }

        public Guid CourseId { get; set; }

        public string CourseName { get; set; }
    }
}