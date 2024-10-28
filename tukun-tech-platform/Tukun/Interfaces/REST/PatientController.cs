using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tukun_tech_platform.Tukun.Domain.Model.Queries.Patients;
using tukun_tech_platform.Tukun.Domain.Services.Patients;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.Patients;
using tukun_tech_platform.Tukun.Interfaces.REST.Transform.Patients;

namespace tukun_tech_platform.Tukun.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Patient")]

public class PatientController(IPatientCommandService patientCommandService, IPatientQeryService patientQueryService) : ControllerBase
{
    [HttpPost] // 3 tipos > {Post} {Put} {Get} 
    [SwaggerOperation(
        Summary = "Create a Patient",
        Description = "Create a Patient",
        OperationId = "CreatePatient")]
    [SwaggerResponse(201, "The patient was created", typeof(PatientResource))]
    public async Task<ActionResult> CreatePatient([FromBody] CreatePatientResource resource)
    {
        var createPatientCommand = CreatePatientCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await patientCommandService.Handle(createPatientCommand); // handle > manejador de data 
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetAllPatientsByDniQuery), new { dni = result.Dni },
            PatientResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    private async Task<ActionResult> GetAllPatientByDni(string dni)
    {
        var getAllPatientByDniQuery = new GetAllPatientsByDniQuery(dni);
        var result = await patientQueryService.Handle(getAllPatientByDniQuery);
        if (result is null) return NotFound();
        var resource = PatientResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        return Ok(resource);
    }

    private async Task<ActionResult> GetPatientByName(string firstName, string lastName)
    {
        var getPatientByNameQuery = new GetAllPatientsByNameQuery(firstName, lastName);
        var result = await patientQueryService.Handle(getPatientByNameQuery);
        if (result is null) return NotFound();
        var resource = PatientResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("{dni}")]
    [SwaggerOperation(
        Summary = "Gets a Patient by dni",
        Description = "Gets a Patient for a given favorite source identifier",
        OperationId = "GetDoctorByDni")]
    [SwaggerResponse(200, "The favorite source was found", typeof(PatientResource))]
    public async Task<ActionResult> GetPatientByCmp(string dni)
    {
        var getPatentDniQuery = new GetAllPatientsByDniQuery(dni);
        var result = await patientQueryService.Handle(getPatentDniQuery);
        if(result is null) return NotFound();
        var resource = PatientResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("all")]
    [SwaggerOperation(
        Summary = "Get all Patients",
        Description = "Retrieves all Patients from the system",
        OperationId = "GetAllPatients")]
    [SwaggerResponse(200, "Patient found", typeof(IEnumerable<PatientResource>))]
    [SwaggerResponse(404, "No Patients found")]
    public async Task<ActionResult> GetAllPatient()
    {
        var result = await patientQueryService.Handle(new GetAllPatientsQuery());

        if (result == null || !result.Any())
        {
            return NotFound("No Patients found.");
        }

        var resources = result.Select(PatientResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    
    

}