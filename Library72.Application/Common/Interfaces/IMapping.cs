using System.Linq.Expressions;

namespace Library72.Application.Common.Interfaces;

public interface IMapping<TSource, TDestination>
{
	Expression<Func<TSource, TDestination>> Map();
}

public interface IMapping<TSource1, TSource2, TDestination>
{
	Expression<Func<TSource1, TSource2, TDestination>> Map();
}
