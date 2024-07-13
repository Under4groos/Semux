using SemuxBlazorShared.Components;

namespace SemuxBlazorShared
{
    public class DLLImportLib
    {
        public CancellationTokenSource Init(string[]? args = default, string host = "https://localhost:9127/", Action<string>? loaded = default)
        {
            if (args == null)
                args = new string[0];

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            TaskFactory factory = new TaskFactory(token);
            factory.StartNew(() =>
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddRazorComponents()
                    .AddInteractiveServerComponents();

                var app = builder.Build();

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

                app.Run(host);
            });

            return source;

        }
    }
}
