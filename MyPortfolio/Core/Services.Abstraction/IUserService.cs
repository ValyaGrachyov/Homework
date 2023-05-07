using Contracts;

namespace Services.Abstraction;

public interface IUserService
{
    public Task<UserDto> GetByIdAsync(int id);
}