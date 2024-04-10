namespace Notes.Application.UseCase.Notes.Commands.Categories.Delete;

public class CategoryDeleteValidator : AbstractValidator<CategoryDeleteCommand>
{
    public CategoryDeleteValidator()
    {
        RuleFor(_ => _.Id).NotNull().NotEmpty();
    }
}