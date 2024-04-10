namespace Notes.Application.UseCase.Notes.Commands.Notes;

public class NoteCreateValidator : AbstractValidator<NoteCreateCommand>
{
    public NoteCreateValidator()
    {
        RuleFor(_ => _.Title).NotNull().NotEmpty();
        RuleFor(_ => _.CategoryId).NotEmpty();
    }
}
