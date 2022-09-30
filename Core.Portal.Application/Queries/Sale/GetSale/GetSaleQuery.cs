using AutoMapper;
using Core.Portal.Application.DTOs.Employe;
using Core.Portal.Application.Services.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Application.Queries.Sale.GetSale
{
    internal class GetSaleQuery : IRequestHandler<GetSale, GetSaleDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetSaleQuery(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetSaleDTO> Handle(GetSale request, CancellationToken cancellationToken)
        {
            var sale = await _unitOfWork.SaleRepository.GetByIdAsync(request.SaleId);

            return _mapper.Map<GetSaleDTO>(sale);
        }
    }
}
