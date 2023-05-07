namespace Domain.Repositories;

public interface IRepositoryManager
{
    IExperienceRepository ExperienceRepository { get; }
    IEducationRepository EducationRepository { get; }
    
    IRequestMessageRepository RequestMessageRepository { get; }
    
    IUserRepository UserRepository { get; }

    IUnitOfWork UnitOfWork { get; }
    
    IFactRepository FactRepository { get; }
    
    ISkillRepository SkillRepository { get; }
    
    IServiceRepository ServiceRepository { get; }
    
    ITestimonialRepository TestimonialRepository { get; }
}
