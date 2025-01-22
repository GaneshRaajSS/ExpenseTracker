using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using static WebApplication1.Constants.MultiValues;

namespace WebApplication1.Constants
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                // For specific enums like UserRole, handle it separately
                if (context.Type == typeof(UserRole))
                {
                    schema.Enum = Enum.GetValues(typeof(UserRole))
                                      .Cast<UserRole>()
                                      .Select(x => (IOpenApiAny)new OpenApiString(x.ToString()))
                                      .ToList();
                    schema.Type = "string"; // Ensure it's displayed as a string in Swagger
                    schema.Format = null;
                }
                else
                {
                    schema.Enum = context.Type.GetEnumNames().Select(x => (IOpenApiAny)new OpenApiString(x)).ToList();
                    schema.Type = "string";
                    schema.Format = null;
                }
            }
        }
    }
}
