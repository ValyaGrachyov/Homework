using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IExperienceRepository> _lazyExperienceRepository;
        private readonly Lazy<IEducationRepository> _lazyEducationRepository;
        private readonly Lazy<IRequestMessageRepository> _lazyRequestMessageRepository;
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        private readonly Lazy<IFactRepository> _lazyFactRepository;
        private readonly Lazy<ISkillRepository> _lazySkillRepository;
        private readonly Lazy<IServiceRepository> _lazyServiceRepository;
        private readonly Lazy<ITestimonialRepository> _lazyTestimonialRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(PortfolioDbContext dbContext)
        {
            _lazyExperienceRepository = new Lazy<IExperienceRepository>(() => new ExperienceRepository(dbContext));
            _lazyRequestMessageRepository = new Lazy<IRequestMessageRepository>(() => new RequestMessageRepository(dbContext));
            _lazyEducationRepository = new Lazy<IEducationRepository>(() => new EducationRepository(dbContext));
            _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
            _lazyFactRepository = new Lazy<IFactRepository>(() => new FactRepository(dbContext));
            _lazySkillRepository = new Lazy<ISkillRepository>(() => new SkillRepository(dbContext));
            _lazyServiceRepository = new Lazy<IServiceRepository>(() => new ServiceRepository(dbContext));
            _lazyTestimonialRepository = new Lazy<ITestimonialRepository>(() => new TestimonialRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }
        
        public IExperienceRepository ExperienceRepository => _lazyExperienceRepository.Value;
        public IEducationRepository EducationRepository => _lazyEducationRepository.Value;
        public IRequestMessageRepository RequestMessageRepository => _lazyRequestMessageRepository.Value;
        public IUserRepository UserRepository => _lazyUserRepository.Value;
        public IFactRepository FactRepository => _lazyFactRepository.Value;
        public ISkillRepository SkillRepository => _lazySkillRepository.Value;
        public IServiceRepository ServiceRepository => _lazyServiceRepository.Value;
        public ITestimonialRepository TestimonialRepository => _lazyTestimonialRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
