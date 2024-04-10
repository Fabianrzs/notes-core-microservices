namespace Notes.Application.UseCase.Notes.Commands.Categories.Delete;
public record CategoryDeleteCommand(
        Guid Id
    ) : IRequest<Unit>;
