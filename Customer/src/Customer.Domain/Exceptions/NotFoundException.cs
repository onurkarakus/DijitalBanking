using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, object identifier)
            : base($"{entityName} with ID {identifier} not found.")
        {
        }

        public NotFoundException(string entityName, object identifier, Exception innerException)
            : base($"{entityName} with ID {identifier} not found.", innerException)
        {
        }
    }
}
