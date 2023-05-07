using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    public Task<User> GetByIdAsync(int id);
}