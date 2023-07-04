namespace Library72.Application.Common.Exceptions;

public class BusinessValidationException : Exception
{
	public uint HttpErrorCode { get; }

	public BusinessValidationException(uint httpErrorCode, string message = null!) : base(message)
	{
		HttpErrorCode = httpErrorCode;
	}
}
