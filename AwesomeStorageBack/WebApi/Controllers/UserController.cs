using System.ComponentModel.DataAnnotations;
using Application.Elements.Commands.DeleteElement;
using Application.Elements.Commands.UpdateElement;
using Application.Elements.Queries.GetElement;
using Application.Elements.Queries.GetElements;
using Application.Elements.Queries.GetElementsWithContext;
using Application.Objects.Commands.AddElement;
using Domain;
using Microsoft.AspNetCore.Mvc;



namespace WebApi.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class UserController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Element>>> GetAllElements()
    {
        var query = new GetElementsQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Element>>> GetAllElementsWithContext([FromQuery, Required] string searchTerm)
    {
        var query = new GetElementsWithContextQuery()
        {
            SearchTerm = searchTerm
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet]
    public async Task<ActionResult<Element>> GetElement([FromQuery, Required]  Guid id)
    {
        var query = new GetElementQuery()
        {
            Id = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddElement([FromQuery, Required] string details)
    {
        var command = new AddElementCommand()
        {
            Details = details
        };
        var vm = await Mediator.Send(command);
        return Ok(vm);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateElement([FromQuery, Required] Guid id, [FromQuery, Required] string details)
    {
        var command = new UpdateElementCommand()
        {
            Id = id,
            Details = details
        };
        await Mediator.Send(command);
        return NoContent();
    }
    

    [HttpDelete]
    public async Task<ActionResult> DeleteElement([FromQuery, Required] Guid id )
    {
        var command = new DeleteElementCommand()
        {
            Id = id
        };
        await Mediator.Send(command);
        return NoContent();
    }
}