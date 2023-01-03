using Application.Features.Direcciones.Commands.CreateDireccionComand;
using Application.Features.Direcciones.Commands.DeleteDireccionCommand;
using Application.Features.Direcciones.Commands.UpdateDireccionCommand;
using Application.Features.Direcciones.Queries.GetAllDireccionById;
using Application.Features.Direcciones.Queries.GetAllDirecciones;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    public class DireccionesController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> GetDireccion([FromQuery] GetAllDireccionesParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllDireccionesQuery 
            { 
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Ciudad = filter.Ciudad,
                Colonia = filter.Colonia 
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDireccion(int id)
        {
            return Ok(await Mediator.Send(new GetDireccionByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostDireccion(CreateDireccionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDireccion(int id, UpdateDireccionCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDireccion(int id)
        {
            return Ok(await Mediator.Send(new DeleteDireccionCommand { Id = id }));
        }

    }
}
