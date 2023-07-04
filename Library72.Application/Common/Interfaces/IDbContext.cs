using System;
using Library72.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library72.Application.Common.Interfaces;

public interface IDbContext
{
	DbSet<Author> Authors { get; }

	DbSet<Book> Books { get; }

	DbSet<Domain.Entities.BooksTaken> BooksTakens { get; }

	DbSet<User> Users { get; }

	DbSet<BooksTakenByUsers> BooksTakenByUsers { get; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
