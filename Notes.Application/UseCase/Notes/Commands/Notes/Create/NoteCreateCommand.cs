using Notes.Application.UseCase.Notes.Dtos;

namespace Notes.Application.UseCase.Notes.Commands.Notes;
public record NoteCreateCommand(
        string Title,
        string? Description,
        Guid CategoryId
    ) : IRequest<NoteDto>;
