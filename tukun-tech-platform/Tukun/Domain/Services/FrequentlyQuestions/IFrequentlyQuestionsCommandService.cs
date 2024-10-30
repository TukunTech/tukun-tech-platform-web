using tukun_tech_platform.Tukun.Domain.Model.Commands.FrequentlyQuestions;

namespace tukun_tech_platform.Tukun.Domain.Services.FrequentlyQuestions;

public interface IFrequentlyQuestionsCommandService
{
    Task<Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions?> Handle(CreateFrequentlyQuestionsCommand command);
}