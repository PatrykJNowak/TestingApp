using System.Collections.Generic;
using MediatR;
using TestingApp.DataModels;

namespace TestingApp.Queries
{
    public class GetSellDataQuery : IRequest<IEnumerable<SellData>>{}
}