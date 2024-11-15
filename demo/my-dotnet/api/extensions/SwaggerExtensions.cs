using Scalar.AspNetCore;

namespace api.extensions;

public static class SwaggerExtensions
{
    public static void AddSwaggerFeature(this IServiceCollection services)
    {
        //https://localhost:7121/swagger/v1/swagger.json
        services.AddSwaggerGen();
    }

    public static void UseSwaggerFeature(this WebApplication app)
    {
        app.UseSwagger(options =>
        {
            options.RouteTemplate = "/openapi/{documentName}.json"; 
        });

        // swagger
        // http://localhost:5215/swagger
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/openapi/v1.json", "My API V1"));
        
        // scalar/v1
        // http://localhost:5215/scalar/v1
        app.MapScalarApiReference();
    }
}
