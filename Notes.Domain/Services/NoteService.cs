using Notes.Domain.Entities;
using Notes.Domain.Ports;
using Notes.Domain.Services.Base;

namespace Notes.Domain.Services;

[DomainService]
public class NoteService
{
    private readonly IGenericRepository<Note> _noteRepository;
    public NoteService(IGenericRepository<Note> noteRepository)
    {
        _noteRepository = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository), "No repository available");
    }

    public async Task<IEnumerable<Note>> GetNotesAsync(Guid categoryId)
    {
        return await _noteRepository.GetAsync(x => x.Id == categoryId);
    }
    public async Task<IEnumerable<Note>> GetNoteByIdAsync(Guid Id)
    {
        return await _noteRepository.GetAsync(x => x.Id == Id);
    }

    public async Task<Note> AddNoteAsync(Note note)
    {
        return await _noteRepository.AddAsync(note);
    }

    public async Task UpdateNoteAsync(Note note)
    {
        await _noteRepository.UpdateAsync(note);
    }

    public async Task DeleteNoteAsync(Note note)
    {
        await _noteRepository.DeleteAsync(note);
    }
}
