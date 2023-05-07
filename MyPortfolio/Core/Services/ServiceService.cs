using Contracts;
using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class ServiceService : IServiceService
{
    private readonly IRepositoryManager _repositoryManager;

    public ServiceService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<ServiceDto>> GetAllAsync()
    {
        var entities = await _repositoryManager.ServiceRepository.GetAllAsync();

        return entities.Select(x => new ServiceDto
        {
            Description = x.Description,
            Name = x.Name
        });
    }
}