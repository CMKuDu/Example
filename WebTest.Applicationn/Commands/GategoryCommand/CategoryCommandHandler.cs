using WebAPITest.Infastructure.UnitOfWork;
using WebTest.Applicationn.ICommand;
using WebTest.Domain.IRepository;
using WebTest.Domain.Model;

namespace WebTest.Applicationn.Commands.GategoryCommand
{
    public class CategoryCommandHandler : ICommandHandler<CreateCategoryCommand, string>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }
        public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.CategoryDTO.Name,
                Description = request.CategoryDTO.Description,
            };
            await _categoryRepository.Add(category);
            _unitOfWork.Compele();
            return category.Name;
        }
    }
}
