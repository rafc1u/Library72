using MediatR;

namespace Library72.Application.Books.GetBooksList;

public class GetBooksListQueryDto
{
	public long Id { get; set; }
	public string Title { get; set; } = null!;

	public string? Description { get; set; }

	public long AuthorId { get; set; }

	public string AuthorFirstName { get; set; } = null!;

	public string? AuthorMiddleName { get; set; }

	public string AuthorLastName { get; set; } = null!;

	public long? UserId { get; set; }

	public string? FirstName { get; set; } = null!;

	public string? LastName { get; set; } = null!;
}
