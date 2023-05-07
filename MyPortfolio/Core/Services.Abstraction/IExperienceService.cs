using Contracts.Admin.Experience;

namespace Services.Abstraction
{
    public interface IExperienceService
    {
        public Task<IEnumerable<ExperienceDto>> GetAllAsync(CancellationToken cancellationToken = default);

        public Task AddAsync(AddExperienceDto dto, CancellationToken cancellationToken = default);
        public Task EditAsync(EditExperienceDto dto);
        public Task DeleteAsync(int id);
    }
}
