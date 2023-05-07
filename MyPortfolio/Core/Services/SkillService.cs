using Contracts;
using Contracts.Admin.Skill;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class SkillService : ISkillService
{
    private readonly IRepositoryManager _repositoryManager;

    public SkillService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task DeleteAsync(int id)
    {
        await _repositoryManager.SkillRepository.DeleteAsync(id);
    }

    public async Task EditAsync(EditSkillDto dto,CancellationToken cancellation = default)
    {
        var skill = new Skill
        {
            Id = dto.Id,
            Name = dto.Name,
            Score = dto.Score,
        };
        await _repositoryManager.SkillRepository.EditAsync(skill);
    }

    public async Task AddAsync(AddSkillDto dto, CancellationToken cancellation = default)
    {
        var skill = new Skill
        {
            Name = dto.Name,
            Score = dto.Score,
        };
        await _repositoryManager.SkillRepository.AddAsync(skill);
    }

    public async Task<IEnumerable<SkillDto>> GetAllAsync()
    {
        var entities = await _repositoryManager.SkillRepository.GetAllAsync();

        return entities.Select(x => new SkillDto
        {
            Id = x.Id,
            Name = x.Name,
            Score = x.Score
        });
    }
}