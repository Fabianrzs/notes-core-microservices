using Notes.Application.UseCase.Notes.Dtos;

namespace Notes.Application.UseCase.Notes.Queries.Notes;

public record NoteQuery(Guid IdCategory) : IRequest<IEnumerable<NoteDto>>;
