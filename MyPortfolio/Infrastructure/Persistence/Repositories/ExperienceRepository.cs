using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ExperienceRepository: IExperienceRepository
    {
        private readonly PortfolioDbContext _dbContext;

        public ExperienceRepository(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Experience>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Experiences.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Experience experience, CancellationToken cancellationToken = default)
        {
            await _dbContext.Experiences.AddAsync(experience, cancellationToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Experience dto)
        {
            Experience newEducation = await _dbContext.Experiences.FindAsync(dto.Id);
            newEducation = EditEducation(newEducation, dto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Experience education = await _dbContext.Experiences.FindAsync(id);
            _dbContext.Experiences.Remove(education);
            await _dbContext.SaveChangesAsync();
        }

        private Experience EditEducation(Experience oldEducation, Experience newEducation)
        {
            oldEducation.Specialization = newEducation.Specialization;
            oldEducation.OrganizationName = newEducation.OrganizationName;
            oldEducation.StartDate = newEducation.StartDate;
            oldEducation.EndDate = newEducation.EndDate;
            oldEducation.Description = newEducation.Description;
            return oldEducation;
        }
    }
}
