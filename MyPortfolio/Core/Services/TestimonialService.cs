using Contracts;
using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class TestimonialService : ITestimonialService
{
    private readonly IRepositoryManager _repositoryManager;

    public TestimonialService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<TestimonialDto>> GetAllAsync()
    {
        var entities = await _repositoryManager.TestimonialRepository.GetAllAsync();

        return entities.Select(x => new TestimonialDto
        {
            Content = x.Content,
            AuthorName = x.AuthorName,
            AuthorOccupation = x.AuthorOccupation
        });
    }
}