using System;
using System.Collections.Generic;
using Library72.Application.Common.Interfaces;
using Library72.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library72.Storage.Entities;

public partial class Test72Context : DbContext, IDbContext
{
	public Test72Context()
	{
	}

	public Test72Context(DbContextOptions<Test72Context> options)
		: base(options)
	{
	}

	public DbSet<Author> Authors { get; set; }

	public DbSet<Book> Books { get; set; }

	public DbSet<BooksTaken> BooksTakens { get; set; }

	public DbSet<User> Users { get; set; }

	public DbSet<BooksTakenByUsers> BooksTakenByUsers { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Author>(entity =>
		{
			entity.ToTable("Author");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.FirstName).HasMaxLength(50);
			entity.Property(e => e.LastName).HasMaxLength(50);
			entity.Property(e => e.MiddleName).HasMaxLength(50);
		});

		modelBuilder.Entity<Book>(entity =>
		{
			entity.ToTable("Book");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
			entity.Property(e => e.Description).HasMaxLength(1000);
			entity.Property(e => e.Title).HasMaxLength(250);

			entity.HasOne(d => d.Author).WithMany(p => p.Books)
				.HasForeignKey(d => d.AuthorId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Book_Author");
		});

		modelBuilder.Entity<BooksTaken>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("BooksTaken");

			entity.Property(e => e.BookId).HasColumnName("BookID");
			entity.Property(e => e.DateTaken).HasColumnType("datetime");
			entity.Property(e => e.UserId).HasColumnName("UserID");

			entity.HasOne(d => d.Book).WithMany()
				.HasForeignKey(d => d.BookId)
				.HasConstraintName("FK_BooksTaken_Book");

			entity.HasOne(d => d.User).WithMany()
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("FK_BooksTaken_User");
		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.ToTable("User");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Email).HasMaxLength(250);
			entity.Property(e => e.FirstName).HasMaxLength(250);
			entity.Property(e => e.LastName).HasMaxLength(250);
		});

		modelBuilder.Entity<BooksTakenByUsers>(
			entity =>
			{
				entity.HasNoKey();
				entity.Property(e => e.FirstName).HasColumnName("FirstName");
				entity.Property(e => e.LastName).HasColumnName("LastName");
				entity.Property(e => e.UserId).HasColumnName("UserId");
				entity.Property(e => e.CountOfBooks).HasColumnName("CountOfBooks");
				entity.Property(e => e.TotalCountOfDays).HasColumnName("TotalCountOfDays");
			});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
