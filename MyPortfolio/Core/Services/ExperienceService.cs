using Contracts;
using Contracts.Admin.Education;
using Contracts.Admin.Experience;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstraction;

namespace Services
{
    public class ExperienceService: IExperienceService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ExperienceService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task EditAsync(EditExperienceDto dto)
        {
            var education = new Experience
            {
                Id = dto.Id,
                Specialization = dto.Specialization,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Description = dto.Description,
                OrganizationName = dto.OrganizationName
            };

            await _repositoryManager.ExperienceRepository.EditAsync(education);

        }

        public async Task DeleteAsync(int id)
        {
            await _repositoryManager.ExperienceRepository.DeleteAsync(id);
        }


        public async Task AddAsync(AddExperienceDto dto, CancellationToken cancellationToken = default)
        {
            var education = new Experience
            {
                Specialization = dto.Specialization,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Description = dto.Description,
                OrganizationName = dto.OrganizationName
            };

            await _repositoryManager.ExperienceRepository.AddAsync(education, cancellationToken);

        }




        public async Task<IEnumerable<ExperienceDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _repositoryManager.ExperienceRepository.GetAllAsync(cancellationToken);

            return entities
            .OrderByDescending(x => (x.EndDate ?? DateTime.Now, x.StartDate))
            .Select(e => new ExperienceDto
            {
                Id = e.Id,
                Specialization = e.Specialization,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description,
                OrganizationName = e.OrganizationName
            });
        }
    }
}
