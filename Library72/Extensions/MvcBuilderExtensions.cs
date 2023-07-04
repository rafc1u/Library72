using Library72.Application.Books.GetBooksList;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace Library72.Extensions;

public static class MvcBuilderExtensions
{
	public static IMvcBuilder AddODataModelBuilder(this IMvcBuilder mvcBuilder)
	{
		return mvcBuilder.AddOData(o =>
		{
			o.Select().Filter().OrderBy().Count().Expand().SetMaxTop(100);

			var modelBuilder = new ODataConventionModelBuilder();
			modelBuilder.EntitySet<GetBooksListQueryDto>("search");
			modelBuilder.EnableLowerCamelCase();
			var model = modelBuilder.GetEdmModel();
			o.AddRouteComponents("api", model);
		});
	}
}
