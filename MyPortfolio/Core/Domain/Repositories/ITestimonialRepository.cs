using Domain.Entities;

namespace Domain.Repositories;

public interface ITestimonialRepository
{
    public Task<IEnumerable<Testimonial>> GetAllAsync();
}