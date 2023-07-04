using System;
using System.Collections.Generic;

namespace Library72.Domain.Entities;

public class Book
{
	public long Id { get; private set; }

	public string Title { get; private set; } = null!;

	public string? Description { get; private set; }

	public long AuthorId { get; private set; }

	public virtual Author Author { get; private set; } = null!;
}
