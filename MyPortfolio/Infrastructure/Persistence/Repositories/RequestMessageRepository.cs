using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories;

public class RequestMessageRepository : IRequestMessageRepository
{
    private readonly PortfolioDbContext _dbContext;

    public RequestMessageRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(RequestMessage requestMessage)
    {
        await _dbContext.RequestMessages.AddAsync(requestMessage);
    }
}