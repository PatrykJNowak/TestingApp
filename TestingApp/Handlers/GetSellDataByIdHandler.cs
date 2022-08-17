using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestingApp.DataModels;
using TestingApp.Queries;

namespace TestingApp.Handlers
{
    public class GetSellDataByIdHandler : IRequestHandler<GetSellDataByIdQuery, SellData>
    {
        private readonly Context _context;

        public GetSellDataByIdHandler(Context context) => _context = context;

        public async Task<SellData> Handle(GetSellDataByIdQuery request, CancellationToken cancellationToken)
        {
            var results = _context.SellData
                .FirstOrDefault(x => x.Id == 2);
            
            return results;
        }

    }
}