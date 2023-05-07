using Domain.Entities;

namespace Domain.Repositories;

public interface IRequestMessageRepository
{
    public Task AddAsync(RequestMessage requestMessage);
}