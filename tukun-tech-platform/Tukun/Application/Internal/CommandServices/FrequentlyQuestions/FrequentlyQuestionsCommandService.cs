using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Commands.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Domain.Repositories.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Domain.Services.FrequentlyQuestions;

namespace tukun_tech_platform.Tukun.Application.Internal.CommandServices.FrequentlyQuestions;

public class FrequentlyQuestionsCommandService(IFrequentlyQuestionsRepository frequentlyQuestionsRepository, IUnitOfWork unitOfWork) : IFrequentlyQuestionsCommandService 
{
    public async Task<Domain.Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions?> Handle(
        CreateFrequentlyQuestionsCommand command)
    {
        var frequentlyQuestions = await
            frequentlyQuestionsRepository.FindByFrequentlyQuestionsIdAsync(command.Id);
        if (frequentlyQuestions != null)
            throw new Exception($"Frequently questions with the id {command.Id} already exists.");
        frequentlyQuestions = new Domain.Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions(command);
        try
        {
            await frequentlyQuestionsRepository.AddAsync(frequentlyQuestions);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return frequentlyQuestions;
    }
    
}