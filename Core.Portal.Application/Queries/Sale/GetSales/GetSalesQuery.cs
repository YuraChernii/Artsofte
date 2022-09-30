using AutoMapper;
using Core.Portal.Application.DTOs.Employe;
using Core.Portal.Application.Queries.Employe.GetEmployes;
using Core.Portal.Application.Services.UnitOfWork;
using MediatR;

namespace Core.Portal.Application.Queries.GetEmployee
{
    internal class GetSalesQuery : IRequestHandler<GetSales, GetSalesDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetSalesQuery(
            IUnitOfWork unitOfWork, 
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetSalesDTO> Handle(GetSales request, CancellationToken cancellationToken)
        {
            var sales = await _unitOfWork.SaleRepository.GetListAsync(
                request.Name,
                request.Status,
                request.SortOrder,
                request.SortKey,
                request.Limit,
                request.Page
                );

            var res = new GetSalesDTO();
            res.Employees = _mapper.Map<List<GetSaleDTO>>(sales);

            return res;
        }
    }
}
