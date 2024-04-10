using Notes.Domain.Services;

namespace Notes.Application.UseCase.Notes.Commands.Notes.Delete;

public class NoteDeleteHandler : IRequestHandler<NoteDeleteCommand, Unit>
{
    private readonly NoteService _noteService;

    public NoteDeleteHandler(NoteService noteService)
    {
        _noteService = noteService ?? throw new ArgumentNullException(nameof(noteService));
    }

    public async Task<Unit> Handle(NoteDeleteCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request), "Request object needed to handle this task");
        var find = (await _noteService.GetNoteByIdAsync(request.Id)).FirstOrDefault();
        await _noteService.DeleteNoteAsync(find);
        return Unit.Value;
    }
}