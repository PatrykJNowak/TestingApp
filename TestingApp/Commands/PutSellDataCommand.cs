using MediatR;
using TestingApp.Handlers.Dto;

namespace TestingApp.Commands
{
    public class PutSellDataCommand : IRequest<int>
    {
        public PutSellDataDto putSellDataDto { get; set; }
    }
}