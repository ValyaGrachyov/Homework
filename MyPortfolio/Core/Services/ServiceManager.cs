using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IExperienceService> _lazyExperienceService;
    private readonly Lazy<IEducationService> _lazyEducationService;
    private readonly Lazy<IRequestMessageService> _lazyRequestMessageService;
    private readonly Lazy<IUserService> _lazyUserService;
    private readonly Lazy<IFactService> _lazyFactService;
    private readonly Lazy<ISkillService> _lazySkillService;
    private readonly Lazy<IServiceService> _lazyServiceService;
    private readonly Lazy<ITestimonialService> _lazyTestimonialService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyExperienceService = new Lazy<IExperienceService>(() => new ExperienceService(repositoryManager));
        _lazyEducationService = new Lazy<IEducationService>(() => new EducationService(repositoryManager));
        _lazyRequestMessageService = new Lazy<IRequestMessageService>(() => new RequestMessageService(repositoryManager));
        _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager));
        _lazyFactService = new Lazy<IFactService>(() => new FactService(repositoryManager));
        _lazySkillService = new Lazy<ISkillService>(() => new SkillService(repositoryManager));
        _lazyServiceService = new Lazy<IServiceService>(() => new ServiceService(repositoryManager));
        _lazyTestimonialService = new Lazy<ITestimonialService>(() => new TestimonialService(repositoryManager));
    }

    public IExperienceService ExperienceService => _lazyExperienceService.Value;
    public IEducationService EducationService => _lazyEducationService.Value;
    public IRequestMessageService RequestMessageService => _lazyRequestMessageService.Value;
    public IUserService UserService => _lazyUserService.Value;
    public IFactService FactService => _lazyFactService.Value;
    public ISkillService SkillService => _lazySkillService.Value;
    public IServiceService ServiceService => _lazyServiceService.Value;
    public ITestimonialService TestimonialService => _lazyTestimonialService.Value;
}