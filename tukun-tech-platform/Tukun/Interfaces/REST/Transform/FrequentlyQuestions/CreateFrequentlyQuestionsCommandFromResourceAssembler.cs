using tukun_tech_platform.Tukun.Domain.Model.Commands.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.FrequentlyQuestions;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.FrequentlyQuestions;

public static class CreateFrequentlyQuestionsCommandFromResourceAssembler
{
    public static CreateFrequentlyQuestionsCommand
        ToCommandFromResource(CreateFrequentlyQuestionResource resource) =>
        new CreateFrequentlyQuestionsCommand(resource.Id, resource.Text);
}