using MediatR;
using TestingApp.DataModels;
using TestingApp.Handlers.Dto;

namespace TestingApp.Commands
{
    public class AddSellDataCommand : IRequest<int>
    {
        public PostSellDataDto PostSellDataDto { get; set; }
    }
}