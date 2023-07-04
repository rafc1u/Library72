using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library72.Application.Books.GetBookWithInvertedTitle;

public class GetBookWithInvertedTitleDto
{
	public long Id { get; set; }

	public string Title { get; set; } = null!;

	public string? Description { get; set; }
}
