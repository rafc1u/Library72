using System.Linq.Expressions;
using Library72.Application.Common.Interfaces;
using Library72.Domain.Entities;

namespace Library72.Application.Books.GetBooksList;

public class BookTakenToBookSearchListDtoMapping : IMapping<Book, IEnumerable<Domain.Entities.BooksTaken>, GetBooksListQueryDto>
{
	public Expression<Func<Book, IEnumerable<Domain.Entities.BooksTaken>, GetBooksListQueryDto>> Map()
	{
		return (book, booksTakens) => new GetBooksListQueryDto()
		{
			Id = book.Id,
			Title = book.Title,
			Description = book.Description,
			AuthorId = book.Author.Id,
			AuthorFirstName = book.Author.FirstName,
			AuthorLastName = book.Author.LastName,
			AuthorMiddleName = book.Author.MiddleName,
			UserId = booksTakens.Any() ? booksTakens.Single().UserId : null,
			FirstName = booksTakens.Any() ? booksTakens.Single().User.FirstName : null,
			LastName = booksTakens.Any() ? booksTakens.Single().User.LastName : null,
		};
	}
}
