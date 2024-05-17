using Reservar.Common.Domain.Entities.Subscription;
using Common.Communication.Publisher.Integration;
using Notes.Domain.Services;

namespace Notes.Application.UseCase.Notes.Commands.Categories.Delete;

public class CategoryDeleteHandler : IRequestHandler<CategoryDeleteCommand, Unit>
{
    private readonly CategoryService _categoryService;
    private readonly IIntegrationMessagePublisher _messagePublisher;

    public CategoryDeleteHandler(CategoryService categoryService, IIntegrationMessagePublisher messagePublisher)
    {
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        _messagePublisher = messagePublisher ?? throw new ArgumentNullException(nameof(messagePublisher));
    }

    public async Task<Unit> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request), "Request object needed to handle this task");
        var find = (await _categoryService.GetCategoriesByIdAsync(request.Id)).FirstOrDefault();
        await _categoryService.DeleteCategoryAsync(find);
        var email = new EmailCommand(request.Email, "Eliminaste la Categoria ", $"{find.Title}", null);
        await _messagePublisher.Publish(email);
        return Unit.Value;
    }
}