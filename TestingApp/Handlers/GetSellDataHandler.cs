using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestingApp.DataModels;
using TestingApp.Queries;

namespace TestingApp.Handlers
{
    public class GetSellDataHandler : IRequestHandler<GetSellDataQuery, IEnumerable<SellData>>
    {
        private readonly Context _context;
        public GetSellDataHandler(Context context) => _context = context;

        public async Task<IEnumerable<SellData>> Handle(GetSellDataQuery request, CancellationToken cancellationToken)
        {
            var  results  = _context.SellData
                .ToList();
            
            return results;
        }
    }
}