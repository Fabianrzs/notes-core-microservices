using Notes.Application.UseCase.Notes.Dtos;
using Notes.Domain.Entities;
using Notes.Domain.Services;

namespace Notes.Application.UseCase.Notes.Commands.Notes.Update;

public class NoteUpdateHandler : IRequestHandler<NoteUpdateCommand, NoteDto>
{
    private readonly NoteService _noteService;
    private readonly IMapper _mapper;

    public NoteUpdateHandler(NoteService noteService, IMapper mapper)
    {
        _noteService = noteService ?? throw new ArgumentNullException(nameof(noteService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<NoteDto> Handle(NoteUpdateCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request), "Request object needed to handle this task");
        var note = _mapper.Map<NoteUpdateCommand, Note>(request);
        await _noteService.UpdateNoteAsync(note);
        return _mapper.Map<NoteDto>(request);
    }
}