using Contracts;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class RequestMessageService : IRequestMessageService
{
    private readonly IRepositoryManager _repositoryManager;

    public RequestMessageService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task AddAsync(RequestMessageDto requestMessageDto)
    {
        await _repositoryManager.RequestMessageRepository.AddAsync(new RequestMessage
        {
            Message = requestMessageDto.Message,
            Checked = false,
            Date = DateTime.Now,
            Subject = requestMessageDto.Subject,
            UserEmail = requestMessageDto.UserEmail,
            UserName = requestMessageDto.UserName
        });

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}