using Notes.Application.UseCase.Notes.Dtos;
using Notes.Domain.Entities;
using Notes.Domain.Services;

namespace Notes.Application.UseCase.Notes.Commands.Categories.Create;

public class CategoryCreateHandler : IRequestHandler<CategoryCreateCommand, CategoryDto>
{
    private readonly CategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryCreateHandler(CategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CategoryDto> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request), "Request object needed to handle this task");

        var category = _mapper.Map<CategoryCreateCommand, Category>(request);
        var createdCategory = await _categoryService.AddCategoryAsync(category);
        return _mapper.Map<CategoryDto>(createdCategory);
    }
}