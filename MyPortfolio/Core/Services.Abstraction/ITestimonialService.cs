using Contracts;

namespace Services.Abstraction;

public interface ITestimonialService
{
    public Task<IEnumerable<TestimonialDto>> GetAllAsync();
}