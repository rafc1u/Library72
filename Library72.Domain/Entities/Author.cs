namespace Library72.Domain.Entities;

public class Author
{
	public long Id { get; set; }

	public string FirstName { get; private set; } = null!;

	public string? MiddleName { get; private set; }

	public string LastName { get; private set; } = null!;

	public virtual ICollection<Book> Books { get; private set; } = new List<Book>();
}
