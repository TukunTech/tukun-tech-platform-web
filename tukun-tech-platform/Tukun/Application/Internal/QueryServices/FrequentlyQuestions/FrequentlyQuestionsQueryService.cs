using tukun_tech_platform.Tukun.Domain.Model.Queries.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Domain.Repositories.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Domain.Services.FrequentlyQuestions;

namespace tukun_tech_platform.Tukun.Application.Internal.QueryServices.FrequentlyQuestions;

public class FrequentlyQuestionsQueryService(IFrequentlyQuestionsRepository frequentlyQuestionsRepository) : IFrequentlyQuestionsQueryService
{
    public async Task<Domain.Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions?> Handle(
        GetFrequentlyQuestionsById query)
    {
        return await frequentlyQuestionsRepository.FindByFrequentlyQuestionsIdAsync(query.Id);
    }
 
    
}