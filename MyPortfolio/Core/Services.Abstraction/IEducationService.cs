using Contracts;
using Contracts.Admin.Education;

namespace Services.Abstraction;

public interface IEducationService
{
    public Task<IEnumerable<EducationDto>> GetAllAsync(CancellationToken cancellationToken = default);

    public Task AddAsync(AddEducationDto dto, CancellationToken cancellationToken = default);
    public Task EditAsync(EditEducationDto dto);
    public Task DeleteAsync(int id);
}