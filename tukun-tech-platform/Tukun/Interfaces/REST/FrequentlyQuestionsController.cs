using System.Net.Mime;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tukun_tech_platform.Tukun.Application.Internal.CommandServices.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Application.Internal.QueryServices.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Domain.Model.Queries.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Domain.Services.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Interfaces.REST.Transform.FrequentlyQuestions;

namespace tukun_tech_platform.Tukun.Interfaces.REST;

[ApiController]
[Route("api/v1/soporte")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Frequently Questions")]
public class FrequentlyQuestionsController : ControllerBase 
{
    private readonly IFrequentlyQuestionsQueryService _frequentlyQuestionsQueryService;
    private readonly IFrequentlyQuestionsCommandService _frequentlyQuestionsCommandService;

    public FrequentlyQuestionsController(IFrequentlyQuestionsQueryService frequentlyQuestionsQueryService, IFrequentlyQuestionsCommandService frequentlyQuestionsCommandService)
    {
        _frequentlyQuestionsQueryService = frequentlyQuestionsQueryService;
        _frequentlyQuestionsCommandService = frequentlyQuestionsCommandService;
    }

    [HttpGet("faqs")]
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
    
    
    [HttpPost("mensaje")]
    [SwaggerOperation(
        Summary = "Create a Frequently Question",
        Description = "Create a Frequently Question",
        OperationId = "CreateFrequentlyQuestion")]
    [SwaggerResponse(201, "The Frequently Question was created", typeof(FrequentlyQuestionsResource))]
    [SwaggerResponse(400, "Bad request")]
    public async Task<ActionResult<FrequentlyQuestionsResource>> CreateFrequentlyQuestions([FromBody] CreateFrequentlyQuestionResource resource)
    {
        var createFrequentlyQuestionsCommand = CreateFrequentlyQuestionsCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _frequentlyQuestionsCommandService.Handle(createFrequentlyQuestionsCommand);
        
        if (result == null) 
        {
            return BadRequest("Failed to create .");
        }

        return CreatedAtAction(nameof(CreateFrequentlyQuestions), new { Id = result.Id }, 
            FrequentlyQuestionsResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    
    
    
}