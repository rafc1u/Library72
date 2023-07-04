using Library72.Application.Books.GetBooksList;
using Library72.Application.Books.GetBookWithInvertedTitle;
using Library72.Application.BooksTaken.GetBooksTakenByUser;
using Library72.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Library72.Controllers;

[ApiController]
[Route("api")]
public class BooksController : ODataController
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("search")]
    [EnableQuery]
    public Task<IQueryable<GetBooksListQueryDto>> Get([FromQuery] GetBooksListQuery query)
    {
        return _mediator.Send(query);
    }

    [HttpGet("invertedwords")]
    public async Task<ActionResult<GetBookWithInvertedTitleDto>> GetInvertedWords([FromQuery] GetBookWithInvertedTitleQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("report")]
    public async Task<ActionResult<IEnumerable<GetBooksTakenByUsersDto>>> GetBooksTakeByUsersReport([FromQuery] GetBooksTakenQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
