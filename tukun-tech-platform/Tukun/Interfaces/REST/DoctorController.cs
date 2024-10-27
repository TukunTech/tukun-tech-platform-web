using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tukun_tech_platform.Tukun.Domain.Model.Queries.Doctors;
using tukun_tech_platform.Tukun.Domain.Services.Doctors;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.Doctors;
using tukun_tech_platform.Tukun.Interfaces.REST.Transform.Doctors;

namespace tukun_tech_platform.Tukun.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Doctor")]
public class DoctorController(IDoctorCommandService doctorCommandService, IDoctorQueryService doctorQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Doctor",
        Description = "Create a Doctor",
        OperationId = "CreateDoctor")]
    [SwaggerResponse(201, "The doctor was created", typeof(DoctorResource))]
    public async Task<ActionResult> CreateDoctor([FromBody] CreateDoctorResource resource)
    {
        var createDoctorCommand = CreateDoctorCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await doctorCommandService.Handle(createDoctorCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetDoctorByCmp), new { id = result.Id },
            DoctorResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    private async Task<ActionResult> GetAllDoctorsByDni(string dni)
    {
        var getAllDoctorsByDniQuery = new GetAllDoctorsByDniQuery(dni);
        var result = await doctorQueryService.Handle(getAllDoctorsByDniQuery);
        if (result is null) return NotFound();
        var resource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        return Ok(resource);
    }

    private async Task<ActionResult> GetDoctorByName(string firstName, string lastName)
    {
        var getDoctorByNameQuery = new GetDoctorsByNameQuery(firstName, lastName);
        var result = await doctorQueryService.Handle(getDoctorByNameQuery);
        if (result is null) return NotFound();
        var resource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("{dni}")]
    [SwaggerOperation(
        Summary = "Gets a Doctor by dni",
        Description = "Gets a doctor for a given favorite source identifier",
        OperationId = "GetDoctorByDni")]
    [SwaggerResponse(200, "The favorite source was found", typeof(DoctorResource))]
    public async Task<ActionResult> GetDoctorByCmp(string dni)
    {
        var getDoctorCmpQuery = new GetAllDoctorsByDniQuery(dni);
        var result = await doctorQueryService.Handle(getDoctorCmpQuery);
        if(result is null) return NotFound();
        var resource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("all")]
    [SwaggerOperation(
        Summary = "Get all doctors",
        Description = "Retrieves all doctors from the system",
        OperationId = "GetAllDoctors")]
    [SwaggerResponse(200, "Doctors found", typeof(IEnumerable<DoctorResource>))]
    [SwaggerResponse(404, "No doctors found")]
    public async Task<ActionResult> GetAllDoctors()
    {
        var result = await doctorQueryService.Handle(new GetAllDoctorsQuery());

        if (result == null || !result.Any())
        {
            return NotFound("No doctors found.");
        }

        var resources = result.Select(DoctorResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    
    

}