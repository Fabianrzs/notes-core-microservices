using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservar.Common.Domain.Response;
using Notes.Application.UseCase.Notes.Dtos;
using Notes.Application.UseCase.Notes.Queries.Notes;
using Notes.Application.UseCase.Notes.Commands.Notes;
using Notes.Application.UseCase.Notes.Commands.Notes.Update;
using Notes.Application.UseCase.Notes.Commands.Notes.Delete;

namespace Notes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController
{
    readonly IMediator _mediator = default!;

    public NoteController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{categoryId}")]
    public async Task<ActionResult<Response<IEnumerable<NoteDto>>>> GetNotesByUserId(Guid categoryId)
    {
        var response = await _mediator.Send(new NoteQuery(categoryId));
        return new Response<IEnumerable<NoteDto>>(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<NoteDto>>> CreateNote(NoteCreateCommand command)
    {
        var response = await _mediator.Send(command);
        return new Response<NoteDto>(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<NoteDto>>> UpdateCategory(NoteUpdateCommand command)
    {
        var response = await _mediator.Send(command);
        return new Response<NoteDto>(response);
    }

    [HttpDelete("{Id}/{email}")]
    public async Task<ActionResult<Response<Unit>>> DeleteCategory(Guid Id, string email)
    {
        var response = await _mediator.Send(new NoteDeleteCommand(Id, email));
        return new Response<Unit>(response);
    }
}
