using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tukun_tech_platform.Tukun.Domain.Model.Queries.CriticalAlerts;
using tukun_tech_platform.Tukun.Domain.Services.CriticalAlerts;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.CriticalAlerts;
using tukun_tech_platform.Tukun.Interfaces.REST.Transform.CriticalAlerts;

namespace tukun_tech_platform.Tukun.Interfaces.REST;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Tags("CriticalAlerts")]
public class CriticalAlertsController : ControllerBase
{
    private readonly ICriticalAlertsQueryService _criticalAlertsQueryService;
    private readonly ICriticalAlertsCommandService _criticalAlertsCommandService;

    public CriticalAlertsController(ICriticalAlertsQueryService criticalAlertsQueryService, ICriticalAlertsCommandService criticalAlertsCommandService)
    {
        _criticalAlertsQueryService = criticalAlertsQueryService;
        _criticalAlertsCommandService = criticalAlertsCommandService;
    }

    // Ruta para Adultos Mayores
    [HttpGet("api/v1/adultos-mayores/{id}/alertas/estado-critico")]
    [SwaggerOperation(
        Summary = "Gets Critical Alerts by id for Elderly",
        Description = "Gets a Critical Alert for an elderly by given identifier",
        OperationId = "GetCriticalAlertsByIdForElderly")]
    [SwaggerResponse(200, "The alert was found", typeof(CriticalAlertsResource))]
    public async Task<ActionResult> GetCriticalAlertsByIdForElderly(int id)
    {
        var getCriticalAlertsQuery = new GetCriticalAlertsById(id);
        var result = await _criticalAlertsQueryService.Handle(getCriticalAlertsQuery);
        if (result is null) return NotFound();
        var resource = CriticalAlertsResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    // Ruta para Pacientes de Clínica
    [HttpGet("api/v1/pacientes/{id}/alertas/estado-critico")]
    [SwaggerOperation(
        Summary = "Gets Critical Alerts by id for Clinic Patients",
        Description = "Gets a Critical Alert for a clinic patient by given identifier",
        OperationId = "GetCriticalAlertsByIdForClinicPatient")]
    [SwaggerResponse(200, "The alert was found", typeof(CriticalAlertsResource))]
    public async Task<ActionResult> GetCriticalAlertsByIdForClinicPatient(int id)
    {
        var getCriticalAlertsQuery = new GetCriticalAlertsById(id);
        var result = await _criticalAlertsQueryService.Handle(getCriticalAlertsQuery);
        if (result is null) return NotFound();
        var resource = CriticalAlertsResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}
