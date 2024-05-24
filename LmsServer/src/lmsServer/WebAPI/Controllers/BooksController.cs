using Application.Features.Books.Commands.Create;
using Application.Features.Books.Commands.Delete;
using Application.Features.Books.Commands.Update;
using Application.Features.Books.Queries.GetById;
using Application.Features.Books.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.Books.Queries.GetDynamic;

using Application.Features.Books.Queries.GetListBookByAuthorIdQuery;
using Application.Features.Books.Queries.GetListBookByIdQuery;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookCommand createBookCommand)
    {
        CreatedBookResponse response = await Mediator.Send(createBookCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookCommand updateBookCommand)
    {
        UpdatedBookResponse response = await Mediator.Send(updateBookCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBookResponse response = await Mediator.Send(new DeleteBookCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBookResponse response = await Mediator.Send(new GetByIdBookQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookQuery getListBookQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBookListItemDto> response = await Mediator.Send(getListBookQuery);
        return Ok(response);
    }

    [HttpPost("dynamic")]
    public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamic)
    {
        GetDynamicBookQuery query = new() { Dynamic = dynamic, PageRequest = pageRequest };
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("getbooksbycategoryid")]
    public async Task<IActionResult> GetListBookByCategoryId([FromQuery] PageRequest pageRequest, Guid categoryId)
    {
        GetListBookByCategoryIdQuery query = new() { PageRequest = pageRequest, CategoryId = categoryId };
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("getbooksbyauthorid")]
    public async Task<IActionResult> GetListBookByAuthorId([FromQuery] PageRequest pageRequest, Guid authorId)
    {
        GetListBookByAuthorIdQuery query = new() { PageRequest = pageRequest, AuthorId = authorId };
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}