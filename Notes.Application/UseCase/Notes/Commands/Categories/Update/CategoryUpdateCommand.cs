using Notes.Application.UseCase.Notes.Dtos;

namespace Notes.Application.UseCase.Notes.Commands.Categories.Update;
public record CategoryUpdateCommand(
        Guid Id,
        string Title,
        string? Description,
        Guid UserId
    ) : IRequest<CategoryDto>;
