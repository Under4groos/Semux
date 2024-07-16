using SemuxBlazorShared.Components;
using SemuxBlazorShared.Models;

namespace SemuxBlazorShared
{
    public class DLLImportLib
    {
        public CancellationTokenSource Init(string[]? args = default, string host = "https://localhost:9127/", Action<string>? loaded = default)
        {
            if (args == null)
                args = Array.Empty<string>();

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            TaskFactory factory = new TaskFactory(token);
            factory.StartNew(() =>
            {
                WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddRazorComponents()
                    .AddInteractiveServerComponents();

                WebApplication app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Error", createScopeForErrors: true);
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();

                app.UseStaticFiles();
                app.UseAntiforgery();

                app.MapRazorComponents<App>()
                    .AddInteractiveServerRenderMode();

                loaded?.Invoke(host);


                G_.User.Connect();

                app.Run(host);
            });

            return source;

        }
    }
}
