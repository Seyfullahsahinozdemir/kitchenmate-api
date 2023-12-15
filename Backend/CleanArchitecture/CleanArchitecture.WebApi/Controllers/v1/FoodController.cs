using CleanArchitecture.Core.Features.Table.Commands.CreateTable;
using CleanArchitecture.Core.Features.Table.Commands.DeleteTableById;
using CleanArchitecture.Core.Features.Table.Commands.UpdateTable;
using CleanArchitecture.Core.Features.Table.Queries.GetAllTables;
using CleanArchitecture.Core.Features.Table.Queries.GetTableById;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Core.Features.FoodImageFiles.Commands.RemoveFoodImage;
using CleanArchitecture.Core.Features.FoodImageFiles.Commands.UploadFoodImage;
using CleanArchitecture.Core.Features.FoodImageFiles.Queries.GetFoodImageById;
using CleanArchitecture.Core.Features.Foods.Commands.CreateFood;
using CleanArchitecture.Core.Features.Foods.Commands.DeleteFoodById;
using CleanArchitecture.Core.Features.Foods.Commands.UpdateFood;
using CleanArchitecture.Core.Features.Foods.Queries.GetAllFoods;
using CleanArchitecture.Core.Features.Foods.Queries.GetFoodById;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FoodController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Get([FromQuery] GetAllFoodsQueryRequest request)
        {
            IList<GetAllFoodQueryResponse> responses = await Mediator.Send(request);
            return Ok(responses);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Waiter")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFoodByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateFoodCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(UpdateFoodCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFoodByIdCommand { Id = id }));
        }

        [HttpPost("image")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Upload([FromQuery] UploadFoodImageCommand uploadFoodImageCommand)
        {
            uploadFoodImageCommand.File = Request.Form.Files[0];
            return Ok(await Mediator.Send(uploadFoodImageCommand));
        }

        //[HttpGet("image")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> GetFoodImageById(int imageId)
        //{
        //    return Ok(await Mediator.Send(new GetFoodByIdQuery { Id = imageId }));
        //}

        [HttpDelete("image")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFoodImageById(int id)
        {
            return Ok(await Mediator.Send(new RemoveFoodImageCommand { ImageId = id }));
        }
    }
}
