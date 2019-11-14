using System;

namespace Restful.Login.Domain.Contracts.Response
{
    public class GradeResponse
    {
        public Guid Id { get; set; }
        
        public string Name { get; private set; }
    }
}
