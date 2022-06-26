using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Configuration;
using Alachisoft.NCache.AspNetCore.SignalR;
using NCacheSignalR.NCacheHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<NCacheConfiguration>(builder.Configuration.GetSection("NCacheConfiguration"));
builder.Services.AddSignalR().AddNCache(ncacheOptions =>
{
    ncacheOptions.CacheName = builder.Configuration["NCacheConfiguration:CacheName"];
    ncacheOptions.ApplicationID = builder.Configuration["NCacheConfiguration:ApplicationID"];

    // In case of enabled cache security specify the security credentials
    //ncacheOptions.UserId = builder.Configuration["NCacheConfiguration:UserID"];
    //ncacheOptions.Password = builder.Configuration["NCacheConfiguration:Password"];

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapHub<SampleHub>("/messages");
app.Run();
