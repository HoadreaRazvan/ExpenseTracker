using ExpenseTracker.Data;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ExpenseService>();

builder.Services.AddDbContext<ExpenseTrackerContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ExpenseTrackerDatabase")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
