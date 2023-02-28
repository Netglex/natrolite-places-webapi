using NatrolitePlacesWebApi.Configurations;

namespace NatrolitePlacesWebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var apiSettings = builder.Configuration.GetSection(nameof(ApiSettings)).Get<ApiSettings>()!;

        builder.Services.AddSingleton<Random>();
        builder.Services.AddCors(options =>
            options.AddDefaultPolicy(policy => policy.WithOrigins(apiSettings.FrontendDomain))
        );
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        foreach (var webApiUrl in apiSettings.WebApiUrls)
        {
            app.Urls.Add(webApiUrl);
        }
        app.UseCors();
        app.UseHttpsRedirection();
        // app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
