using Notes.Application.UseCase.Notes.Dtos;

namespace Notes.Application.UseCase.Notes.Commands.Notes.Update;
public record NoteUpdateCommand(
        Guid Id,
        string Title,
        string? Description,
        Guid CategoryId
    ) : IRequest<NoteDto>;



