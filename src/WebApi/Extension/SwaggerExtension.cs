using Microsoft.OpenApi.Models;

namespace WebApi.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwaggerConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRouting(options => options.LowercaseUrls = true);

        var forwardedPrefix = configuration["ForwardedPrefix"];

        services.AddSwaggerGen(options =>
        {
            if (!string.IsNullOrEmpty(forwardedPrefix))
                options.AddServer(new OpenApiServer
                {
                    Url = $"{forwardedPrefix}"
                });

            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Aseguradoras API", Version = "v1" });

            // Bearer Token
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Authorization header using the Bearer scheme. Provide your JWT token.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "Bearer",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });
    }

    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "WebApi v1"); });
    }
}