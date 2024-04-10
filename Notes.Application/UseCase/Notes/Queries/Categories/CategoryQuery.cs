using Notes.Application.UseCase.Notes.Dtos;

namespace Notes.Application.UseCase.Notes.Queries.Categories;

public record CategoryQuery(Guid IdUser) : IRequest<IEnumerable<CategoryDto>>;
