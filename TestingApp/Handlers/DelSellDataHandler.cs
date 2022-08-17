using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.CodeAnalysis;
using TestingApp.Commands;
using TestingApp.DataModels;

namespace TestingApp.Handlers
{
    public class DelSellDataHandler : IRequestHandler<DelSellDataCommand, int>
    {
        public Context Context { get; }

        private readonly Context _context;

        public DelSellDataHandler(Context context)
        {
            _context = context;
            Context = context;
        }


        public async Task<int> Handle(DelSellDataCommand request, CancellationToken cancellationToken)
        {
            var addSellData = new SellData()
            {
                Id = 20
            };
                
            var resultsss = _context.SellData.Remove(addSellData);
            await _context.SaveChangesAsync(cancellationToken);
            return resultsss.Entity.Id;
        }
    }
}