using Cleo.ChatroomHubs;
using Cleo.Client.Pages;
using Cleo.Client.Services;
using Cleo.Components;
using Cleo.Data;
using Cleo.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<AppDbContext>(o => 
    o.UseSqlite(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddSignalR();
builder.Services.AddScoped<ChatroomService>();
builder.Services.AddScoped<ChatroomRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Cleo.Client._Imports).Assembly);
app.MapHub<CleoHub>("/chatroom-hub");
app.MapControllers();

app.Run();
