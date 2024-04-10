using Notes.Application.UseCase.Notes.Dtos;
using Notes.Domain.Entities;
using Notes.Domain.Services;

namespace Notes.Application.UseCase.Notes.Commands.Categories.Update;

public class CategoryUpdateHandler : IRequestHandler<CategoryUpdateCommand, CategoryDto>
{
    private readonly CategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryUpdateHandler(CategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CategoryDto> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request), "Request object needed to handle this task");
        var category = _mapper.Map<CategoryUpdateCommand, Category>(request);
        await _categoryService.UpdateCategoryAsync(category);
        return _mapper.Map<CategoryDto>(category);
    }
}