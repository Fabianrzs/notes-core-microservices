namespace Notes.Application.UseCase.Notes.Queries.Categories;

public class CategoryQueryValidator : AbstractValidator<CategoryQuery>
{
    public CategoryQueryValidator() { RuleFor(_ => _.IdUser).NotEmpty(); }
}
