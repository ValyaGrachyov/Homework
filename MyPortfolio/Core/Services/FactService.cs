using Contracts;
using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class FactService : IFactService
{
    private readonly IRepositoryManager _repositoryManager;

    public FactService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<FactDto>> GetAllAsync()
    {
        var entities = await _repositoryManager.FactRepository.GetAllAsync();

        return entities.Select(x => new FactDto
        {
            Count = x.Count,
            Description = x.Description,
            Name = x.Name
        });
    }
}