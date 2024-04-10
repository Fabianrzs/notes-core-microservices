using Notes.Application.UseCase.Notes.Dtos;
using Notes.Domain.Services;

namespace Notes.Application.UseCase.Notes.Queries.Categories;

public class CategoryQueryHandler : IRequestHandler<CategoryQuery, IEnumerable<CategoryDto>>
{
    private readonly CategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryQueryHandler(CategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<CategoryDto>> Handle(CategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryService.GetCategoriesByUserIdAsync(request.IdUser);
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }
}
