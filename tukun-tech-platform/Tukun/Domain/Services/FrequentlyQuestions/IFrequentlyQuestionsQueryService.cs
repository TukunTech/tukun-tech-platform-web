using tukun_tech_platform.Tukun.Domain.Model.Queries.FrequentlyQuestions;

namespace tukun_tech_platform.Tukun.Domain.Services.FrequentlyQuestions;

public interface IFrequentlyQuestionsQueryService
{
    Task<Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions?> Handle(GetFrequentlyQuestionsById query);
}