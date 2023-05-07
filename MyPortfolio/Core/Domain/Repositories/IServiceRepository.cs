using Domain.Entities;

namespace Domain.Repositories;

public interface IServiceRepository
{
    public Task<IEnumerable<Service>> GetAllAsync();
}