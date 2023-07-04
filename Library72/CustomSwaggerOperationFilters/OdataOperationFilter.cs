using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Library72.CustomSwaggerOperationFilters;

public class OdataOperationFilter : IOperationFilter
{
	public void Apply(OpenApiOperation operation, OperationFilterContext context)
	{
		var controllerActionDescriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
		if (controllerActionDescriptor != null)
		{
			var enableQueryAttribute = controllerActionDescriptor.MethodInfo.GetCustomAttribute<EnableQueryAttribute>();
			if (enableQueryAttribute != null)
			{
				operation.Parameters ??= new List<OpenApiParameter>();
				operation.Parameters = operation.Parameters.Where(x => !x.Schema.Reference.ReferenceV3.EndsWith("ODataQueryOptions")).ToList();

				operation.Parameters.Add(new OpenApiParameter
				{
					Name = "$select",
					Description = "Specifies the comma-separated list of properties to select in the response.",
					Required = false,
					In = ParameterLocation.Query,
					Schema = new OpenApiSchema { Type = "string" }
				});

				operation.Parameters.Add(new OpenApiParameter
				{
					Name = "$filter",
					Description = "Specifies the filter expression to apply to the response.",
					Required = false,
					In = ParameterLocation.Query,
					Schema = new OpenApiSchema { Type = "string" }

				});

				operation.Parameters.Add(new OpenApiParameter
				{
					Name = "$orderby",
					Description = "Specifies the property to sort the response by.",
					Required = false,
					In = ParameterLocation.Query,
					Schema = new OpenApiSchema { Type = "string" }
				});

				operation.Parameters.Add(new OpenApiParameter
				{
					Name = "$skip",
					Description = "Specifies the number of items to skip in the response.",
					Example = new OpenApiString("0"),
					Required = false,
					In = ParameterLocation.Query,
					Schema = new OpenApiSchema { Type = "int" }
				});

				operation.Parameters.Add(new OpenApiParameter
				{
					Name = "$top",
					Description = "Specifies the maximum number of items to return in the response.",
					Example = new OpenApiString("25"),
					Required = false,
					In = ParameterLocation.Query,
					Schema = new OpenApiSchema { Type = "int" }
				});
			}
		}
	}
}