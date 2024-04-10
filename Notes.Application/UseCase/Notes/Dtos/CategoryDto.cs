namespace Notes.Application.UseCase.Notes.Dtos;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
}