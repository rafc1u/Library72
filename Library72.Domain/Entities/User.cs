using System;
using System.Collections.Generic;

namespace Library72.Domain.Entities;

public class User
{
	public long Id { get; private set; }

	public string FirstName { get; private set; } = null!;

	public string LastName { get; private set; } = null!;

	public string Email { get; private set; } = null!;
}
