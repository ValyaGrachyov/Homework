using Domain.Entities;

namespace Domain.Repositories
{
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>> GetAllAsync(CancellationToken cancellationToken = default);

        Task AddAsync(Experience experience, CancellationToken cancellationToken = default);

        Task EditAsync(Experience experience);

        Task DeleteAsync(int id);
    }
}
