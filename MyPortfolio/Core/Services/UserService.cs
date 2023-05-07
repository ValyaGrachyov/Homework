using Contracts;
using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var userEntity = await _repositoryManager.UserRepository.GetByIdAsync(id);

        return new UserDto
        {
            Age = userEntity.Age,
            City = userEntity.City,
            Freelance = userEntity.Freelance,
            Degree = userEntity.Degree,
            Phone = userEntity.Phone,
            BirthDate = userEntity.BirthDate,
            PhEmailone = userEntity.PhEmailone,
            Website = userEntity.Website
        };
    }
}