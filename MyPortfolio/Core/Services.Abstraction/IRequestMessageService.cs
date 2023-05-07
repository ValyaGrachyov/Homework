using Contracts;

namespace Services.Abstraction;

public interface IRequestMessageService
{
    public Task AddAsync(RequestMessageDto requestMessageDto);
}