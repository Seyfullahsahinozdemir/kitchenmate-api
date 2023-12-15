using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CleanArchitecture.Core.Features.Table.Commands.CreateTable;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;
using CleanArchitecture.Core.Wrappers;
using System.Collections.Generic;
using CleanArchitecture.Core.Features.Table.Queries.GetAllTables;
using CleanArchitecture.Core.Features.Products.Queries.GetProductById;
using CleanArchitecture.Core.Features.Table.Queries.GetTableById;
using CleanArchitecture.Core.Features.Products.Commands.DeleteProductById;
using CleanArchitecture.Core.Features.Products.Commands.UpdateProduct;
using CleanArchitecture.Core.Features.Table.Commands.DeleteTableById;
using CleanArchitecture.Core.Features.Table.Commands.UpdateTable;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TableController : BaseApiController
    {
        // GET: api/<controller>
        [Authorize(Roles = "Admin, Waiter")]
        [HttpGet]
        public async Task<IList<GetAllTablesViewModel>> Get()
        {
            return await Mediator.Send(new GetAllTablesQuery());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Waiter")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTableByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateTableCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, UpdateTableCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTableByIdCommand { Id = id }));
        }
    }
}
