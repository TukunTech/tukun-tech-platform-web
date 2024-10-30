using tukun_tech_platform.Tukun.Domain.Model.Commands.FrequentlyQuestions;

namespace tukun_tech_platform.Tukun.Domain.Model.Aggregates.FrequentlyQuestions;

public class FrequentlyQuestions
{
    protected FrequentlyQuestions()
    {
        Id = 0;
        Text = string.Empty;
    }

    public FrequentlyQuestions(CreateFrequentlyQuestionsCommand command)
    {
        Id = command.Id;
        Text = command.Text;
    }
    
    public int Id { get; private set; }
    public string Text { get; private set; }
    
    
}