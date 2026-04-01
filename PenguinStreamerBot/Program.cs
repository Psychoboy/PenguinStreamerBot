using Microsoft.EntityFrameworkCore;
using PenguinStreamerBot.Components;
using static PenguinStreamerBot.Provider;
public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        var config = builder.Configuration;
        builder.Services.AddDbContext<PenguinStreamerBot.Models.ApplicationDbContext>(options =>
        {
            var provider = config.GetValue("provider", Sqlite.Name);
            
            if (provider == Postgres.Name)
            {
                options.UseNpgsql(config.GetConnectionString(Postgres.Name)!,
                    x => x.MigrationsAssembly(Postgres.Assembly));
            }
            else //Default to SQLite if provider is not specified or is invalid
            {
                options.UseSqlite(config.GetConnectionString(Sqlite.Name)!,
                    x => x.MigrationsAssembly(Sqlite.Assembly));

            }
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}