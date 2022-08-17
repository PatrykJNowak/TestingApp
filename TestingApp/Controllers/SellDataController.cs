using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingApp.Commands;
using TestingApp.DataModels;
using TestingApp.Handlers.Dto;
using TestingApp.Notifications;
using TestingApp.Queries;

namespace TestingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellDataController : ControllerBase
    {
        //api/GET
        [HttpGet]
        public async Task<ActionResult> GetSellData([FromServices] IMediator _sender)
        {
            var resultsGetSellData = await _sender.Send(new GetSellDataQuery());
            return Ok(resultsGetSellData);
        }

        //api/GET/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSellDataById([FromServices] IMediator _sender, int id)
        {
            var resultsGetSellDataById = await _sender.Send(new GetSellDataByIdQuery());
            return Ok(resultsGetSellDataById);
        }

        //api/Post 
        [HttpPost]
        public async Task<ActionResult<int>> AddSellData([FromBody] PostSellDataDto postSellDataDto,
            [FromServices] IMediator _sender)
        {
            var respons = await _sender.Send(new AddSellDataCommand() { PostSellDataDto = postSellDataDto });
            return Ok(respons);
        }

        //api/Put
        [HttpPut]
        public async Task<ActionResult<int>> PutSellData([FromBody] PutSellDataDto putSellDataDto,
            [FromServices] IMediator _sender)
        {
            var resultsPutSellData = await _sender.Send(new PutSellDataCommand() { putSellDataDto = putSellDataDto });
            if (resultsPutSellData == 1)
            {
                return Ok("Done");
            }
            else
            {
                return Ok("Id doesn't exist");
            }
        }


        //api/Del
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DelSellData([FromServices] IMediator _sender, int id)
        {
            var resultsDelSellData = await _sender.Send(new DelSellDataCommand());
            return Ok(resultsDelSellData);
        }
    }
}