using Contracts;

namespace Services.Abstraction;

public interface IServiceService
{
    public Task<IEnumerable<ServiceDto>> GetAllAsync();
}