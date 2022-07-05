using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Exceptions
{
    public class VallidationExceptions: Exception
    {
        public VallidationExceptions() : base("Se han producido uno o mas errores de validacion")
        {
            Errors = new List<string>();

        }
        public List<string> Errors { get; set; }

        public VallidationExceptions(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
