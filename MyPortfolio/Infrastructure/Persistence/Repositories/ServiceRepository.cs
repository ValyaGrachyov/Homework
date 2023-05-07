using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly PortfolioDbContext _dbContext;

    public ServiceRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _dbContext.Services.ToListAsync();
    }
}