using Reservar.Common.Domain.Entities.Subscription;
using Common.Communication.Publisher.Integration;
using Notes.Domain.Services;

namespace Notes.Application.UseCase.Notes.Commands.Notes.Delete;

public class NoteDeleteHandler : IRequestHandler<NoteDeleteCommand, Unit>
{
    private readonly NoteService _noteService;
    private readonly IIntegrationMessagePublisher _messagePublisher;

    public NoteDeleteHandler(NoteService noteService, IIntegrationMessagePublisher messagePublisher)
    {
        _noteService = noteService ?? throw new ArgumentNullException(nameof(noteService));
        _messagePublisher = messagePublisher ?? throw new ArgumentNullException(nameof(messagePublisher));
    }

    public async Task<Unit> Handle(NoteDeleteCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request), "Request object needed to handle this task");
        var find = (await _noteService.GetNoteByIdAsync(request.Id)).FirstOrDefault();
        await _noteService.DeleteNoteAsync(find);
        var email = new EmailCommand(request.Email, "Eliminaste la Nota ", $"{find.Title}", null);
        await _messagePublisher.Publish(email);
        return Unit.Value;
    }
}