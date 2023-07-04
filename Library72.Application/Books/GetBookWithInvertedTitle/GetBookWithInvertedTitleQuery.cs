using Library72.Application.Common.Interfaces;
using MediatR;

namespace Library72.Application.Books.GetBookWithInvertedTitle;

public class GetBookWithInvertedTitleQuery : IRequest<GetBookWithInvertedTitleDto>
{
	public int Id { get; set; }
}
