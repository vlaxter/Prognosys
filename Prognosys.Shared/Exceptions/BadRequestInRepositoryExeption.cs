using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosys.Shared.Exceptions
{
    public class BadRequestInRepositoryExeption : Exception
    {
        public BadRequestInRepositoryExeption()
        {
        }

        public BadRequestInRepositoryExeption(string message)
            : base(message)
        {
        }

        public BadRequestInRepositoryExeption(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}