using Contracts;
using Contracts.Admin.Skill;

namespace Services.Abstraction;

public interface ISkillService
{
    public Task<IEnumerable<SkillDto>> GetAllAsync();
    public Task AddAsync(AddSkillDto skillDto, CancellationToken cancellation =default);

    public Task EditAsync(EditSkillDto skillDto,CancellationToken cancellation=default);
    public Task DeleteAsync(int id);
}