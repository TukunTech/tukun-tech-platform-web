using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tukun_tech_platform.Tukun.Application.Internal.CommandServices.Elders;
using tukun_tech_platform.Tukun.Domain.Model.Commands.Elders;
using tukun_tech_platform.Tukun.Domain.Model.Queries.Elders;
using tukun_tech_platform.Tukun.Domain.Services.Elders;
using tukun_tech_platform.Tukun.Domain.Services.Patients;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.Elders;
using tukun_tech_platform.Tukun.Interfaces.REST.Transform.Elders;

namespace tukun_tech_platform.Tukun.Interfaces.REST;
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Elder")]
public class ElderController(IElderCommandService elderCommandService, IEldersQueryService elderQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Elder",
        Description = "Create a Elder",
        OperationId = "CreateElder")]
    [SwaggerResponse(201, "The Elder was created", typeof(ElderResource))]
    public async Task<ActionResult> CreateElder([FromBody] CreateElderResource resource)
    {
        var createElderCommand = CreateElderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await elderCommandService.Handle(createElderCommand); // handle > manejador de data 
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetAllEldersByIdQuery), new { Id = result.Id },
            ElderResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    private async Task<ActionResult> GetAllEldersById(int Id)
    {
        var getAllElderByIdQuery = new GetAllEldersByIdQuery(Id);
        var result = await elderQueryService.Handle(getAllElderByIdQuery);
        if (result is null) return NotFound();
        var resource = ElderResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        return Ok(resource);
    }

    [HttpGet("{Id}")]
    [SwaggerOperation(
        Summary = "Gets a Elder by Id",
        Description = "Gets a Elder for a given favorite source identifier",
        OperationId = "GetElderById")]
    [SwaggerResponse(200, "The Elder was found", typeof(ElderResource))]

    public async Task<ActionResult> GetElderById(int Id)
    {
        var getElderIdQuery = new GetAllEldersByIdQuery(Id);
        var result = await elderQueryService.Handle(getElderIdQuery);
        if(result is null) return NotFound();
        var resource = ElderResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("all")]
    [SwaggerOperation(
        Summary = "Get all Elders",
        Description = "Retrieves all Elders from the system",
        OperationId = "GetAllElders")]
    [SwaggerResponse(200, "Patient found", typeof(IEnumerable<ElderResource>))]
    [SwaggerResponse(404, "No Elder found")]
    public async Task<ActionResult> GetAllPatient()
    {
        var result = await elderQueryService.Handle(new GetAllEldersQuery());

        if (result == null || !result.Any())
        {
            return NotFound("No Elders found.");
        }

        var resources = result.Select(ElderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    
    
  
  
}