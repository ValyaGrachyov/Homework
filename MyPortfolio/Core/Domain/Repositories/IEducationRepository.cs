using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> GetAllAsync(CancellationToken cancellationToken = default);

        Task AddAsync(Education education, CancellationToken cancellationToken = default);

        Task EditAsync(Education education);

        Task DeleteAsync(int id);
    }
}
