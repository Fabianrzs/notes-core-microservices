namespace Notes.Application.UseCase.Notes.Commands.Categories.Create;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateCommand>
{
    public CategoryCreateValidator()
    {
        RuleFor(_ => _.Title).NotNull().NotEmpty();
        RuleFor(_ => _.UserId).NotEmpty();
    }
}