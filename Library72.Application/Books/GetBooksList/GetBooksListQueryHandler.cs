using System.Linq.Expressions;
using Library72.Application.Common.Interfaces;
using Library72.Domain.Entities;
using MediatR;

namespace Library72.Application.Books.GetBooksList;

public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, IQueryable<GetBooksListQueryDto>>
{
	private readonly IDbContext _dbContext;
	private readonly BookTakenToBookSearchListDtoMapping _bookToBookSearchListDtoMapping;

	public GetBooksListQueryHandler(IDbContext dbContext, BookTakenToBookSearchListDtoMapping bookToBookSearchListDtoMapping)
	{
		_dbContext = dbContext;
		_bookToBookSearchListDtoMapping = bookToBookSearchListDtoMapping;
	}

	public Task<IQueryable<GetBooksListQueryDto>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
	{
		var query = _dbContext.Books
			.GroupJoin(
				_dbContext.BooksTakens,
				book => book.Id,
				bookTaken => bookTaken.BookId,
				_bookToBookSearchListDtoMapping.Map()
				);

		return Task.FromResult(query);
	}
}
