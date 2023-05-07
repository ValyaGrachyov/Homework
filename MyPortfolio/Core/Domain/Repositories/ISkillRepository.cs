using Domain.Entities;

namespace Domain.Repositories;

public interface ISkillRepository
{
    public Task<IEnumerable<Skill>> GetAllAsync();
    public Task AddAsync(Skill skill, CancellationToken cancellation = default);
    public Task EditAsync(Skill skill, CancellationToken cancellation = default);
    public Task DeleteAsync(int id);
}