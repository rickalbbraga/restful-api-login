using System;
using System.Collections.Generic;
using System.Text;

namespace Restful.Login.Domain.Contracts.Requests
{
    public class StudentGroupRequest
    {
        public string Name { get; set; }

        public Guid CourseId { get; set; }
    }
}
