namespace Services.Abstraction;

public interface IServiceManager
{
    IExperienceService ExperienceService { get; }
    IEducationService EducationService { get; }
    
    IRequestMessageService RequestMessageService { get; }
    
    IUserService UserService { get; }
    
    IFactService FactService { get; }
    
    ISkillService SkillService { get; }
    
    IServiceService ServiceService { get; }
    
    ITestimonialService TestimonialService { get; }
}