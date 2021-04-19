using Application.Features.ProductFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class JoinProductIngredientController:BaseApiController
    {
        public JoinProductIngredientController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJoinProductIngredientCommand command)
        {
            return Ok(await mediator.Send(command));
        }

      

        

        [HttpPut]
        public async Task<IActionResult> Update(int idProduct,int idIngredient, [FromBody] UpdateJoinProductIngredientCommand command)
        {
            if (idProduct != command.ProductsId || idIngredient!=command.IngredientsId)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idProduct,int idIngredient)
        {
            return Ok(await mediator.Send(new DeleteJoinProductIngredientCommand { ProductsId=idProduct,IngredientsId=idIngredient }));
        }
    }
}
