using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.FrequentlyQuestions;


namespace tukun_tech_platform.Tukun.Domain.Repositories.FrequentlyQuestions;

public interface IFrequentlyQuestionsRepository : IBaseRepository<Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions>
{
    Task<Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions?> FindByFrequentlyQuestionsIdAsync(
        int frequentlyQuestionsId);
}
