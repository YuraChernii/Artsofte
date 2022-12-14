using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Application.Exceptions
{
    internal class ServerException : Exception
    {
        public ServerException()
        {

        }
        public ServerException(int code, string description) : base(description)
        {
            Code = code;
            Description = description;
        }
        public ServerException(string description) : base(description)
        {
            Description = description;
        }

        public int Code { get; set; } = 500;
        public string Description { get; set; }
    }
}
