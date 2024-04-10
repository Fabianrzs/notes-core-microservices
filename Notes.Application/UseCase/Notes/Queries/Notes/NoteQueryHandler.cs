using Notes.Application.UseCase.Notes.Dtos;
using Notes.Domain.Services;

namespace Notes.Application.UseCase.Notes.Queries.Notes;

public class NoteQueryHandler : IRequestHandler<NoteQuery, IEnumerable<NoteDto>>
{
    private readonly NoteService _noteService;
    private readonly IMapper _mapper;

    public NoteQueryHandler(NoteService noteService, IMapper mapper)
    {
        _noteService = noteService ?? throw new ArgumentNullException(nameof(noteService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<NoteDto>> Handle(NoteQuery request, CancellationToken cancellationToken)
    {
        var categories = await _noteService.GetNotesAsync(request.IdCategory);
        return _mapper.Map<IEnumerable<NoteDto>>(categories);
    }
}
