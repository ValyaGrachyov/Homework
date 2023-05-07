using Contracts;
using Contracts.Admin.Education;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class EducationService : IEducationService
{
    private readonly IRepositoryManager _repositoryManager;

    public EducationService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task EditAsync(EditEducationDto dto)
    {
        var education = new Education
        {
            Id= dto.Id,
            Specialization = dto.Specialization,
            Degree = dto.Degree,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Description = dto.Description,
            OrganizationName = dto.OrganizationName
        };

        await _repositoryManager.EducationRepository.EditAsync(education);

    }

    public async Task DeleteAsync(int id)
    {
        await _repositoryManager.EducationRepository.DeleteAsync(id);
    }


    public async Task AddAsync(AddEducationDto dto, CancellationToken cancellationToken = default)
    {
        var education = new Education
        {
            Specialization = dto.Specialization,
            Degree = dto.Degree,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Description = dto.Description,
            OrganizationName = dto.OrganizationName
        };

        await _repositoryManager.EducationRepository.AddAsync(education, cancellationToken);

    }




    public async Task<IEnumerable<EducationDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _repositoryManager.EducationRepository.GetAllAsync(cancellationToken);

        return entities
            .OrderByDescending(x => (x.EndDate ?? DateTime.Now, x.StartDate))
            .Select(e => new EducationDto
            {
                Id= e.Id,
                Specialization = e.Specialization,
                Degree = e.Degree,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description,
                OrganizationName = e.OrganizationName
            });
    }
}