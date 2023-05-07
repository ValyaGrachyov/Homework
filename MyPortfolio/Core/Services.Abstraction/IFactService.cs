using Contracts;

namespace Services.Abstraction;

public interface IFactService
{
    public Task<IEnumerable<FactDto>> GetAllAsync();
}