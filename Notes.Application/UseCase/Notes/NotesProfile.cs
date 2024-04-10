using Notes.Application.UseCase.Notes.Commands.Categories.Create;
using Notes.Application.UseCase.Notes.Commands.Categories.Update;
using Notes.Application.UseCase.Notes.Commands.Notes;
using Notes.Application.UseCase.Notes.Commands.Notes.Update;
using Notes.Application.UseCase.Notes.Dtos;
using Notes.Domain.Entities;

namespace Notes.Application.UseCase.Notes;

public class NotesProfile: Profile
{
    public NotesProfile()
    {
        CreateMap<CategoryCreateCommand, Category>().ReverseMap();
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<CategoryUpdateCommand, Category>().ReverseMap();


        CreateMap<NoteCreateCommand, Note>().ReverseMap();
        CreateMap<NoteDto, Note>().ReverseMap();
        CreateMap<NoteUpdateCommand, Note>().ReverseMap();
    }
}
