using Core.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Core.Portal.Application.DTOs.Employe;
using Core.Portal.Application.DTOs;
using Core.Portal.Application.Commands.Employe.CreateEmployee;
using AutoMapper;
using Core.Portal.Application.Services.UnitOfWork;

namespace Core.Portal.Application.Commands.Marketing
{
    public class CreateSaleCommand : IRequestHandler<CreateSale, CreateSaleDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSaleCommand(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateSaleDTO> Handle(CreateSale command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
