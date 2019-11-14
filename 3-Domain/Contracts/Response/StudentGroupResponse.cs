using Restful.Login.Domain.Entities;
using System;

namespace Restful.Login.Domain.Contracts.Response
{
    public class StudentGroupResponse
    {
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public CourseResponse Course { get; private set; }

    }
}
