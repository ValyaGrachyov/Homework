using Domain.Entities;

namespace Domain.Repositories;

public interface IFactRepository
{
    public Task<IEnumerable<Fact>> GetAllAsync();
}