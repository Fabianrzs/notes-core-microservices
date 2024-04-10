namespace Notes.Application.UseCase.Notes.Queries.Notes;

public class NoteQueryValidator : AbstractValidator<NoteQuery>
{
    public NoteQueryValidator() { RuleFor(_ => _.IdCategory).NotEmpty(); }
}
