namespace Notes.Application.UseCase.Notes.Commands;
public record EmailCommand(
    string To,
    string Subject,
    string Body,
    List<string>? Attachments
);

