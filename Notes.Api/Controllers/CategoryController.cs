using Microsoft.AspNetCore.Mvc;
using MediatR;
using Reservar.Common.Domain.Response;
using Notes.Application.UseCase.Notes.Commands.Categories.Create;
using Notes.Application.UseCase.Notes.Commands.Categories.Delete;
using Notes.Application.UseCase.Notes.Commands.Categories.Update;
using Notes.Application.UseCase.Notes.Dtos;
using Notes.Application.UseCase.Notes.Queries.Categories;

namespace Notes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController
{
    readonly IMediator _mediator = default!;

    public CategoryController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{userId}")]
    public async Task<ActionResult<Response<IEnumerable<CategoryDto>>>> GetCategoriesByUserId(Guid userId)
    {
        var response = await _mediator.Send(new CategoryQuery(userId));
        return new Response<IEnumerable<CategoryDto>>(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<CategoryDto>>> CreateCategory(CategoryCreateCommand command)
    {
        var response = await _mediator.Send(command);
        return new Response<CategoryDto>(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<CategoryDto>>> UpdateCategory(CategoryUpdateCommand command)
    {
        var response = await _mediator.Send(command);
        return new Response<CategoryDto>(response);
    }

    [HttpDelete("{Id}/{email}")]
    public async Task<ActionResult<Response<Unit>>> DeleteCategory(Guid Id, string email)
    {
        var response = await _mediator.Send(new CategoryDeleteCommand(Id, email));
        return new Response<Unit>(response);
    }
}
