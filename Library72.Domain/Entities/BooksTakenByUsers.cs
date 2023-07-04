using Microsoft.EntityFrameworkCore;

namespace Library72.Domain.Entities;

[Keyless]
public class BooksTakenByUsers
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public long UserId { get; set; }
	public int CountOfBooks { get; set; }
	public int TotalCountOfDays { get; set; }
}