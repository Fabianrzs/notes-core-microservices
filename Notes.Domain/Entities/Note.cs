using Reservar.Common.Domain.Entities.Base;

namespace Notes.Domain.Entities;

public class Note : EntityBase<Guid>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

}
