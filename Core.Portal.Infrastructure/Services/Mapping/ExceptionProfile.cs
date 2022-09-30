using AutoMapper;
using Core.Portal.Application.Exceptions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Infrastructure.Services.Mapping
{
    internal class ExceptionProfile: Profile
    {
        public ExceptionProfile()
        {
            CreateMap<IdentityError, BadRequestException>();
            CreateMap<ValidationFailure, BadRequestException>()
                .ForMember(x=>x.Code, opt=>opt.MapFrom(x=>x.ErrorCode))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.ErrorMessage));
        }
    }
}
