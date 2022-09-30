using AutoMapper;
using Core.Portal.Application.DTOs;
using Core.Portal.Application.DTOs.Employe;
using Core.Portal.Core.Entities;

namespace Core.Portal.Infrastructure.Services.Mapping
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, GetSaleDTO>();
        }
    }
}
