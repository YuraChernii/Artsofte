using Core.Portal.Application.Queries.Employe.GetEmployes;
using Core.Portal.Application.Queries.Sale.GetSale;
using Core.Portal.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.Portal.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class AuctionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuctionController> _logger;

        public AuctionController(
            IMediator mediator,
            ILogger<AuctionController> logger
            )
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet("auctions/{id}")]
        public async Task<IActionResult> GetAuctionById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetSale() { SaleId = id});
            return Ok(result);
        }

        [ResponseCache(CacheProfileName = "Cache2Mins")]
        [HttpGet("auctions")]
        public async Task<IActionResult> GetAuctions(
            [FromQuery] string name,
            [FromQuery] MarketStatus status,
            [FromQuery] SortOrderType sort_order,
            [FromQuery] SaleSortKey sort_key,
            [FromQuery] int limit,
            [FromQuery] int page
            )
        {
            var result = await _mediator.Send(new GetSales()
            {
                 Name = name,
                  Status = status,
                  SortOrder = sort_order,
                  SortKey = sort_key,
                  Limit = limit,
                  Page = page
            });
            return Ok(result);
        }


    }
}
