using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Application.Exceptions
{
    internal class UnAuthorizedException : Exception
    {
        public UnAuthorizedException()
        {

        }
        public UnAuthorizedException(int code, string description) : base(description)
        {
            Code = code;
            Description = description;
        }
        public UnAuthorizedException(string description) : base(description)
        {
            Description = description;
        }

        public int Code { get; set; } = 401;
        public string Description { get; set; }
    }
}
