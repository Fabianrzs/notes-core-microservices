using Notes.Domain.Services;

namespace Notes.Application.UseCase.Notes.Commands.Categories.Delete;

public class CategoryDeleteHandler : IRequestHandler<CategoryDeleteCommand, Unit>
{
    private readonly CategoryService _categoryService;

    public CategoryDeleteHandler(CategoryService categoryService)
    {
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
    }

    public async Task<Unit> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request), "Request object needed to handle this task");
        var find = (await _categoryService.GetCategoriesByIdAsync(request.Id)).FirstOrDefault();
        await _categoryService.DeleteCategoryAsync(find);
        return Unit.Value;
    }
}