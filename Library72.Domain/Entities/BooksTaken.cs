using System;
using System.Collections.Generic;

namespace Library72.Domain.Entities;

public class BooksTaken
{
	public long BookId { get; private set; }

	public long UserId { get; private set; }

	public DateTime DateTaken { get; private set; }

	public Book Book { get; private set; } = null!;

	public User User { get; private set; } = null!;
}