using Library72.Application.Books.GetBooksList;
using MediatR;

namespace Library72.Application.Books.GetBooksList;

public class GetBooksListQuery : IRequest<IQueryable<GetBooksListQueryDto>>
{

}
