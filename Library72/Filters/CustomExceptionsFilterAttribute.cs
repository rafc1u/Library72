using Library72.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library72.Filters;

public class CustomExceptionsFilterAttribute : ExceptionFilterAttribute
{
	public override void OnException(ExceptionContext context)
	{
		if (context.Exception.GetType() == typeof(NotFoundException))
		{
			HandleNotFoundException(context);
			return;
		}

		base.OnException(context);
	}

	private void HandleNotFoundException(ExceptionContext context)
	{
		var exception = (NotFoundException)context.Exception;

		var details = new ProblemDetails()
		{
			Detail = exception.Message
		};

		context.Result = new NotFoundObjectResult(details);

		context.ExceptionHandled = true;
	}
}
