using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Entity
    {
        private IList<string> _error = new List<string>();

        public Guid Id { get; protected set; }

        public bool IsValid
        {
            get => _error.Any() ? false : true;
        }  
        
        public IList<string> Error
        {
            get => _error;
            protected set => _error = value;
        }
    }
}