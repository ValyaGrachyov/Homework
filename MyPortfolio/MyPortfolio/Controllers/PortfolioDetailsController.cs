namespace MyPortfolio.Controllers;

// [Route("/portfolio/details")]
// public class PortfolioDetailsController : Controller
// {
//     private readonly PortfolioDbContext _dbContext;
//     private readonly IMapper _mapper;
//
//     public PortfolioDetailsController(PortfolioDbContext dbContext, IMapper mapper)
//     {
//         _dbContext = dbContext;
//         _mapper = mapper;
//     }
//
//     public async Task<IActionResult> PortfolioDetails()
//     {
//         var project = await _dbContext.Projects.FirstOrDefaultAsync();
//         var model = _mapper.Map<ProjectVM>(project);
//         return View(model);
//     }
// }