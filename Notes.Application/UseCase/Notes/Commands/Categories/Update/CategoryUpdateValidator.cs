namespace Notes.Application.UseCase.Notes.Commands.Categories.Update;

public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateCommand>
{
    public CategoryUpdateValidator()
    {
        RuleFor(_ => _.Title).NotNull().NotEmpty();
        RuleFor(_ => _.Id).NotEmpty();
        RuleFor(_ => _.UserId).NotEmpty();
    }
}