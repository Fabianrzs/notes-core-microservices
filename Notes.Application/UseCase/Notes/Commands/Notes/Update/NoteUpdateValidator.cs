namespace Notes.Application.UseCase.Notes.Commands.Notes.Update;

public class NoteUpdateValidator : AbstractValidator<NoteUpdateCommand>
{
    public NoteUpdateValidator()
    {
        RuleFor(_ => _.Title).NotNull().NotEmpty();
        RuleFor(_ => _.Id).NotEmpty();
        RuleFor(_ => _.CategoryId).NotEmpty();
    }
}