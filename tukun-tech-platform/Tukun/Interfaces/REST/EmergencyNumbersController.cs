using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tukun_tech_platform.Tukun.Domain.Model.Queries.EmergencyNumbers;
using tukun_tech_platform.Tukun.Domain.Services.EmergencyNumbers;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.EmergencyNumbers;
using tukun_tech_platform.Tukun.Interfaces.REST.Transform.EmergencyNumbers;

namespace tukun_tech_platform.Tukun.Interfaces.REST;

[ApiController]
[Route("api/v1/adultos-mayores")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("EmergencyNumbers")]

public class EmergencyNumbersController : ControllerBase
{
    private readonly IEmergencyNumbersCommandService emergencyNumbersCommandService;
    private readonly IEmergencyNumbersQueryService emergencyNumbersQueryService;

    public EmergencyNumbersController(IEmergencyNumbersCommandService emergencyNumbersCommandService,
        IEmergencyNumbersQueryService emergencyNumbersQueryService)
    {
        this.emergencyNumbersCommandService = emergencyNumbersCommandService;
        this.emergencyNumbersQueryService = emergencyNumbersQueryService;
    }

    [HttpPost("{id}/emergencyNumbers")]
    [SwaggerOperation(
        Summary = "Create a Emergency Number",
        Description = "Create a Emergency Number",
        OperationId = "CreateEmergencyNumber")]
    [SwaggerResponse(201, "The Emergency Number was created", typeof(EmergencyNumbersResource))]
    [SwaggerResponse(400, "Bad request")]

    public async Task<ActionResult<EmergencyNumbersResource>> CreateEmergencyNumbers(
        [FromBody] CreateEmergencyNumbersResource resource)
    {
        var createEmergencyNumbersCommand = CreateEmergencyNumbersCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await emergencyNumbersCommandService.Handle(createEmergencyNumbersCommand);

        if (result == null)
        {
            return BadRequest("Failed to create emergency number.");
        }

        return CreatedAtAction(nameof(CreateEmergencyNumbers), new { id = result.Id },
            EmergencyNumbersFromEntityAssembler.ToResourceFromEntity(result));

    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets an emergency number according to parameters",
        Description = "Gets an emergency number for given parameters",
        OperationId = "GetEmergencyNumberById")]
    [SwaggerResponse(200, "Result(s) was/were found", typeof(EmergencyNumbersResource))]
    public async Task<ActionResult> GetEmergencyNumbersById(int id) 
    {
        var getEmergencyNumbersIdQuery = new GetEmergencyNumbersByIdQuery(id);
        var result = await emergencyNumbersQueryService.Handle(getEmergencyNumbersIdQuery);
        if (result is null) return NotFound();
        var resource = EmergencyNumbersFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource); 
    }
}