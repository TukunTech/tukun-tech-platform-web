using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tukun_tech_platform.Tukun.Domain.Services.PendingMedicine;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.PendingMedicine;
using tukun_tech_platform.Tukun.Interfaces.REST.Transform.PendingMedicine;

namespace tukun_tech_platform.Tukun.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Pending Medicine")]
public class PendingMedicineController : ControllerBase
{
    private readonly IPendingMedicineCommandService pendingMedicineCommandService;
    private readonly IPendingMedicineQueryService pendingMedicineQueryService;

    public PendingMedicineController(IPendingMedicineCommandService pendingMedicineCommandService, IPendingMedicineQueryService pendingMedicineQueryService)
    {
        this.pendingMedicineCommandService = pendingMedicineCommandService;
        this.pendingMedicineQueryService = pendingMedicineQueryService;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Pending Medicine",
        Description = "Create a Pending Medicine",
        OperationId = "CreatePendingMedicine")]
    [SwaggerResponse(201, "The Pending Medicine was created", typeof(PendingMedicineResource))]
    [SwaggerResponse(400, "Bad request")]
    public async Task<ActionResult<PendingMedicineResource>> CreatePendingMedicine([FromBody] CreatePendingMedicineResource resource)
    {
        var createPendingCommand = CreatePendingMedicineCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await pendingMedicineCommandService.Handle(createPendingCommand);
        
        if (result == null) 
        {
            return BadRequest("Failed to create pending medicine.");
        }

        return CreatedAtAction(nameof(CreatePendingMedicine), new { Id = result.Id }, 
            PendingMedicineFromEntityAssembler.ToResourceFromEntity(result));
    }
}