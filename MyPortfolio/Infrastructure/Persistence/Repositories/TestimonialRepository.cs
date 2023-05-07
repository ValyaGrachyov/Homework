using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class TestimonialRepository : ITestimonialRepository
{
    private readonly PortfolioDbContext _dbContext;

    public TestimonialRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Testimonial>> GetAllAsync()
    {
        return await _dbContext.Testimonials.ToListAsync();
    }
}