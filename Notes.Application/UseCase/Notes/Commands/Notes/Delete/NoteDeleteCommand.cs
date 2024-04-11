namespace Notes.Application.UseCase.Notes.Commands.Notes.Delete;
public record NoteDeleteCommand(
        Guid Id,
        string Email
    ) : IRequest<Unit>;
