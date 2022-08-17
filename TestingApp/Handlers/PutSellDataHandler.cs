using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestingApp.Commands;
using TestingApp.DataModels;

namespace TestingApp.Handlers
{
    public class PutSellDataHandler : IRequestHandler<PutSellDataCommand, int>
    {
        public Context Context { get; }
        private readonly Context _context;

        public PutSellDataHandler(Context context)
        {
            Context = context;
            _context = context;
        }

        public async Task<int> Handle(PutSellDataCommand request, CancellationToken cancellationToken)
        {
            //przez linię 26 i 27 po wykonaniu lini 38 program wykonuje linię 44. Po zakomentowaniu lini 26 i 27 program wykonuje się prawidłowo
            var results = _context.SellData
                .FirstOrDefault(x => x.Id == request.putSellDataDto.Id);
            if (results != null)
            {
                var putSellData = new SellData()
                {
                    Id = request.putSellDataDto.Id,
                    Name = request.putSellDataDto.Name,
                    SurName = request.putSellDataDto.SurName,
                    Age = request.putSellDataDto.Age,
                };

                _context.SellData.Update(putSellData);
                await _context.SaveChangesAsync(cancellationToken);
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}