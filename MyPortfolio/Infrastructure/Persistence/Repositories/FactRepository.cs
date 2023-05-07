using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class FactRepository : IFactRepository
{
    private readonly PortfolioDbContext _dbContext;

    public FactRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Fact>> GetAllAsync()
    {
        return await _dbContext.Facts.ToListAsync();
    }
}