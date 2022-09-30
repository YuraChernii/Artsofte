using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Builder;

//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Portal.Application
{
    public static class Extensions
    {
        public static void AddApplication(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            builder.Services.AddHttpContextAccessor();
        }
    }
}
