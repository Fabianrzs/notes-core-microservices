using Reservar.Common.Domain.Entities.Base;

namespace Notes.Domain.Entities;

public class Category : EntityBase<Guid>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public ICollection<Note> Notes { get; set; }
    public Guid UserId { get; set; }
}
