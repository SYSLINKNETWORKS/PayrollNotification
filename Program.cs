using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TWP_API_Notification.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddControllers();
builder.Services.AddRazorPages();
//builder.Services.AddControllersWithViews();
// builder.Services.AddSignalR();
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

//app.UseHttpsRedirection();
//app.UseAuthorization();

//app.MapControllers();

app.UseCors(x => x
   .AllowAnyMethod()
   .AllowAnyHeader()
   .SetIsOriginAllowed(origin => true) // allow any origin
   .AllowCredentials()); // allow credentials



//app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    //  endpoints.MapControllers();
    endpoints.MapRazorPages();
    //endpoints.MapHub<EmailHub>("/emailHub");
    //endpoints.MapHub<NotificationMessageHub>("/notificationMessageHub");

});

app.Run();
