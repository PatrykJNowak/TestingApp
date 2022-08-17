using System.Reflection.Metadata.Ecma335;
using MediatR;
using TestingApp.DataModels;
using TestingApp.Handlers.Dto;

namespace TestingApp.Queries
{
    public class GetSellDataByIdQuery : IRequest<SellData>
    {
        //public GetElementByIdDto getElementByIdDto { get; set; }
    }
}