using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly PortfolioDbContext _dbContext;

    public SkillRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task EditAsync(Skill dto,CancellationToken cancellationToken = default)
    {
        Skill newSkill = await _dbContext.Skills.FindAsync(dto.Id);
        newSkill = EditEducation(newSkill, dto);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Skill skill = await _dbContext.Skills.FindAsync(id);
        _dbContext.Skills.Remove(skill);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(Skill skill, CancellationToken cancellation = default)
    {
        await _dbContext.AddAsync(skill, cancellation);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<Skill>> GetAllAsync()
    {
        return await _dbContext.Skills.ToListAsync();
    }

    private Skill EditEducation(Skill oldSkill, Skill newSkill)
    {
        oldSkill.Name= newSkill.Name;
        oldSkill.Score= newSkill.Score;
        return oldSkill;
    }
}