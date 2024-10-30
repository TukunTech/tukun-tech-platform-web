using System.Net.Mime;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tukun_tech_platform.Tukun.Application.Internal.QueryServices.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Domain.Model.Queries.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Domain.Services.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Interfaces.REST.Transform.FrequentlyQuestions;

namespace tukun_tech_platform.Tukun.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Frequently Questions")]
public class FrequentlyQuestionsController : ControllerBase 
{
    private readonly IFrequentlyQuestionsQueryService _frequentlyQuestionsQueryService;

    public FrequentlyQuestionsController(IFrequentlyQuestionsQueryService frequentlyQuestionsQueryService)
    {
        _frequentlyQuestionsQueryService = frequentlyQuestionsQueryService;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets a frequently question according to parameters",
        Description = "Gets a frequently question for given parameters",
        OperationId = "GetFrequentlyQuestionsById")]
    [SwaggerResponse(200, "Result(s) was/were found", typeof(FrequentlyQuestionsResource))]
    public async Task<ActionResult> GetFrequentlyQuestionsById(int id) 
    {
        var getFrequentlyQuestionIdQuery = new GetFrequentlyQuestionsById(id);
        var result = await _frequentlyQuestionsQueryService.Handle(getFrequentlyQuestionIdQuery);
        if (result is null) return NotFound();
        var resource = FrequentlyQuestionsResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource); 
    }
    
}