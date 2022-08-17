using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingApp.Commands;
using TestingApp.DataModels;
using TestingApp.Handlers.Dto;

namespace TestingApp.Handlers
{
    public class AddSellDataHandler : IRequestHandler<AddSellDataCommand, int> 
    {
        public Context Context { get; }


        private readonly Context _context;
        
        public AddSellDataHandler(Context context)
        {
            Context = context;
            _context = context;
        }

        public async Task<int> Handle(AddSellDataCommand request, CancellationToken cancellationToken)
        {
            var addSellData = new SellData()
            {
                Name = request.PostSellDataDto.Name,
                SurName = request.PostSellDataDto.SurName,
                Age = request.PostSellDataDto.Age,
            };

            var result = _context.SellData.Add(addSellData);
            await _context.SaveChangesAsync(cancellationToken);
            return result.Entity.Id;
        }
    }
}