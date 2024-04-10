namespace Notes.Application.UseCase.Notes.Dtos;

public class NoteDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
}