using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosys.Shared.Exceptions
{
    public class NotFoundInRepositoryException : Exception
    {
        public NotFoundInRepositoryException()
        {
        }

        public NotFoundInRepositoryException(string message)
            : base(message)
        {
        }

        public NotFoundInRepositoryException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
