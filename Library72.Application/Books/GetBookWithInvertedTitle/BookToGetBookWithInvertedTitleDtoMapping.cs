using System.Linq.Expressions;
using Library72.Application.Books.GetBookWithInvertedTitle;
using Library72.Application.Common.Interfaces;
using Library72.Domain.Entities;

namespace Library72.Application.Books.GetBookWithInvertedTitle;

public class BookToGetBookWithInvertedTitleDtoMapping : IMapping<Book, GetBookWithInvertedTitleDto>
{
	public Expression<Func<Book, GetBookWithInvertedTitleDto>> Map()
	{
		return book => new GetBookWithInvertedTitleDto()
		{
			Id = book.Id,
			Title = book.Title,
			Description = book.Description
		};
	}
}
