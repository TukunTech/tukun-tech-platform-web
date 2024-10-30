using tukun_tech_platform.Tukun.Interfaces.REST.Resources.FrequentlyQuestions;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.FrequentlyQuestions;

public interface FrequentlyQuestionsResourceFromEntityAssembler
{
    public static FrequentlyQuestionsResource
        ToResourceFromEntity(Domain.Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions entity) =>
        new FrequentlyQuestionsResource(entity.Id, entity.Text);
}