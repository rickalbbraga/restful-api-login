using Domain.Contracts.Response;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Validations
{
    public class Notifiable
    {
        private IList<ErrorsResponse> _error = new List<ErrorsResponse>();

        public bool IsValid
        {
            get => _error.Any() ? false : true;
        }            
        
        public IList<ErrorsResponse> Error
        {
            get => _error;
        }

        public void AddError(string error)
        {
            _error.Add(new ErrorsResponse(error));
        }

        public void AddErrors(IList<string> errors)
        {
            errors
                .ToList()
                .ForEach(e => _error.Add(new ErrorsResponse(e)));
        }
    }
}