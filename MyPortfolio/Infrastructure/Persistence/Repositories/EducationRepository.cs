using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class EducationRepository : IEducationRepository
{
    private readonly PortfolioDbContext _dbContext;

    public EducationRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Education>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Educations.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Education education, CancellationToken cancellationToken = default)
    {
        await _dbContext.Educations.AddAsync(education, cancellationToken);
        await _dbContext.SaveChangesAsync();    
    }

    public async Task  EditAsync(Education dto)
    {
        Education newEducation = await _dbContext.Educations.FindAsync(dto.Id);        
        newEducation = EditEducation(newEducation,dto);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Education education = await _dbContext.Educations.FindAsync(id);
        _dbContext.Educations.Remove(education);
        await _dbContext.SaveChangesAsync();
    }

    private Education EditEducation(Education oldEducation, Education newEducation) 
    {
        oldEducation.Specialization = newEducation.Specialization;
        oldEducation.OrganizationName = newEducation.OrganizationName;
        oldEducation.Degree = newEducation.Degree;
        oldEducation.StartDate = newEducation.StartDate;
        oldEducation.EndDate = newEducation.EndDate;
        oldEducation.Description= newEducation.Description;
        return oldEducation;
    }
}