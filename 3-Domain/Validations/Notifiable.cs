using System.Collections.Generic;
using System.Linq;

namespace Domain.Validations
{
    public class Notifiable
    {
        private IList<string> _error = new List<string>();

        public bool IsValid
        {
            get => _error.Any() ? false : true;
        }            
        
        public IList<string> Error
        {
            get => _error;
            protected set => _error = value;
        }

        public void AddError(string error)
        {
            _error.Add(error);
        }

        public void AddErrors(IList<string> errors)
        {
            errors
                .ToList()
                .ForEach(e => _error.Add(e));
        }
    }
}