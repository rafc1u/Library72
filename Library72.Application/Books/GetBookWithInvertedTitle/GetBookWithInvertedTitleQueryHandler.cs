using Library72.Application.Common.Exceptions;
using Library72.Application.Common.Interfaces;
using Library72.Application.Helpers;
using Library72.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library72.Application.Books.GetBookWithInvertedTitle;

internal class GetBookWithInvertedTitleQueryHandler : IRequestHandler<GetBookWithInvertedTitleQuery, GetBookWithInvertedTitleDto>
{
	private readonly ILibrary72DbContext _dbContext;
	private readonly BookToGetBookWithInvertedTitleDtoMapping _bookToGetBookWithInvertedTitleDtoMapping;

	public GetBookWithInvertedTitleQueryHandler(ILibrary72DbContext dbContext, BookToGetBookWithInvertedTitleDtoMapping bookToGetBookWithInvertedTitleDtoMapping)
	{
		_dbContext = dbContext;
		_bookToGetBookWithInvertedTitleDtoMapping = bookToGetBookWithInvertedTitleDtoMapping;
	}

	public async Task<GetBookWithInvertedTitleDto> Handle(GetBookWithInvertedTitleQuery request, CancellationToken cancellationToken)
	{
		var book = await _dbContext
			.Books
			.AsNoTracking()
			.Where(x => x.Id == request.Id)
			.Select(_bookToGetBookWithInvertedTitleDtoMapping.Map())
			.SingleOrDefaultAsync(cancellationToken);

		if (book == null)
		{
			throw new NotFoundException(nameof(Book), request.Id);
		}

		book.Title = book.Title.InvertWords();

		return book;
	}
}
