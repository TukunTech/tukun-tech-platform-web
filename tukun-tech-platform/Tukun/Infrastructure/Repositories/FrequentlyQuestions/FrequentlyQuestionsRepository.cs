using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;
using tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;
using tukun_tech_platform.Tukun.Domain.Repositories.FrequentlyQuestions;

namespace tukun_tech_platform.Tukun.Infrastructure.Repositories.FrequentlyQuestions;

public class FrequentlyQuestionsRepository(AppDbContext context) : BaseRepository<Domain.Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions>(context), IFrequentlyQuestionsRepository
{
    public async Task<Domain.Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions?>
        FindByFrequentlyQuestionsIdAsync(int id)
    {
        return await Context.Set<Domain.Model.Aggregates.FrequentlyQuestions.FrequentlyQuestions>()
            .FirstOrDefaultAsync(f => f.Id == id);
    }
    
}