namespace Notes.Application.UseCase.Notes.Commands.Notes.Delete;

public class NoteDeleteValidator : AbstractValidator<NoteDeleteCommand>
{
    public NoteDeleteValidator()
    {
        RuleFor(_ => _.Id).NotNull().NotEmpty();
    }
}