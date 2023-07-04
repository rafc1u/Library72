using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library72.Application.BooksTaken.GetBooksTakenByUser;

public class GetBooksTakenByUsersDto
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public long UserId { get; set; }
	public int CountOfBooks { get; set; }
	public int TotalCountOfDays { get; set; }
}
