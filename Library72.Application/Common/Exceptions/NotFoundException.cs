using System.Xml.Linq;

namespace Library72.Application.Common.Exceptions;

public class NotFoundException : Exception
{
	public NotFoundException(string name, int id) : this(name, id.ToString())
	{

	}

	public NotFoundException(string name, string id) : base($"Entity {name} with id {id} was not found")
	{
	}
}
