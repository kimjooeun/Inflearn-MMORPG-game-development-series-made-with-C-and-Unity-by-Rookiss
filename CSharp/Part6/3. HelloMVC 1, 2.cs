@homeController.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloEmpty.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloEmpty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HelloMessage msg = new HelloMessage()
            {
                Message = "Welcome to Asp.Net MVC"
            };

            ViewBag.Noti = "Input message and click submit";

            return View(msg);
        }

        // POST를 처리하는 Index
        [HttpPost]
        public IActionResult Index(HelloMessage obj)
        {
            ViewBag.Noti = "Message Changed";
            return View(obj);
        }

    }
}

HelloMessage.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloEmpty.Models
{
    public class HelloMessage
    {
        public string Message { get; set; }
    }
}

Index.cshtml
@model HelloEmpty.Models.HelloMessage

<html>
 <head>
     <title>Hello MVC!</title>
 </head>
<body>
    <h1>@Model.Message</h1>
    <hr /> 
    <h2>@ViewBag.Noti</h2>

    <form asp-controller= "Home" asp-action= "Index" method= "post" >
        < label asp-for="Message">Enter Message</label>
        <br />
        <input type = "text" asp-for="Message" />
        <br />
        <button type = "submit" > Submit </ button >
    </ form >

</ body >
</ html >

_ViewImports.cshtml
@using HelloEmpty
@using HelloEmpty.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HelloEmpty
{
    // M (Model)         데이터 (원자재)
    // V (View)          UI (인테리어)
    // C (Controller)    Controller (액션)

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

Startup.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloEmpty
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
