using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {

        }
        public BadRequestException(int code, string description) : base(description)
        {
            Code = code;
            Description = description;
        }
        public BadRequestException(string description) : base(description)
        {
            Description = description;
        }

        public int Code { get; set; } = 400;
        public string Description { get; set; }
    }
}
