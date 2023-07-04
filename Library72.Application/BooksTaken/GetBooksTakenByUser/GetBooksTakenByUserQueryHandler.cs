using Library72.Application.Common.Interfaces;
using Library72.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library72.Application.BooksTaken.GetBooksTakenByUser;

internal class GetBooksTakenByUserQueryHandler : IRequestHandler<GetBooksTakenQuery, IEnumerable<GetBooksTakenByUsersDto>>
{
	private readonly IDbContext _dbContext;

	public GetBooksTakenByUserQueryHandler(IDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<IEnumerable<GetBooksTakenByUsersDto>> Handle(GetBooksTakenQuery request, CancellationToken cancellationToken)
	{
		string sql = @"
WITH BOOKS_GROUPED_BY_USER AS(
	SELECT
		userId,
		COUNT(1) AS CountOfBooks,
		SUM(DATEDIFF(DAY, DateTaken, GETDATE())) AS TotalCountOfDays
	
	FROM[Test72].[dbo].[BooksTaken]
	GROUP BY userId
)
	
SELECT
	Users.FirstName,
	Users.LastName,
	BOOKS_GROUPED_BY_USER.UserId,
	BOOKS_GROUPED_BY_USER.CountOfBooks,
	BOOKS_GROUPED_BY_USER.TotalCountOfDays

FROM BOOKS_GROUPED_BY_USER
INNER JOIN[Test72].[dbo].[User] Users 
	ON BOOKS_GROUPED_BY_USER.userId = Users.id";

		var result = _dbContext.BooksTakenByUsers
			.FromSqlRaw<BooksTakenByUsers>(sql)
			.AsEnumerable()
			.Select(x => new GetBooksTakenByUsersDto()
			{
				CountOfBooks = x.CountOfBooks,
				FirstName = x.FirstName,
				LastName = x.LastName,
				TotalCountOfDays = x.TotalCountOfDays,
				UserId = x.UserId
			});

		return Task.FromResult(result);
	}
}
