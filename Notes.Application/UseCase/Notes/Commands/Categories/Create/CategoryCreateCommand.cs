using Notes.Application.UseCase.Notes.Dtos;

namespace Notes.Application.UseCase.Notes.Commands.Categories.Create;
public record CategoryCreateCommand(
        string Title,
        string? Description,
        Guid UserId
    ) : IRequest<CategoryDto>;
