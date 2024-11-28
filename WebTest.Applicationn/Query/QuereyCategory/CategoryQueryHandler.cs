using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.IQueries;
using WebTest.Domain.IRepository;

namespace WebTest.Applicationn.Query.QuereyCategory
{
    public class CategoryQueryHandler : IQueryHandler<GetAllCategoryQuery, IEnumerable<CategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAllCategory();
            var categoryDto = category.Select(x => new CategoryDTO
            {
                Name = x.Name,
                Description = x.Description,
            }).ToList();
            return categoryDto;
        }
    }
}
