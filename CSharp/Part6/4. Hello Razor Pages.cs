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

@using HelloEmpty
@using HelloEmpty.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

@page

@model HelloEmpty.Pages.IndexModel

<html>
<head>
    <title>Hello Razor Pages ! </title>
</head>
<body>
    <h1> @Model.HelloMsg.Message</h1>
    <hr />
    <h2> @Model.Noti</h2>
    <form method="post">        
        <label asp-for="HelloMsg.Message">Enter Message</label>
        <br />
        <input type="text" asp-for="HelloMsg.Message" />
        <br />
        <button type="submit">Submit</button>
    </form>
</body>
</html>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloEmpty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloEmpty.Pages
{
    public class IndexModel : PageModel
    {
        // 모델 바인딩 참가 암시
        [BindProperty]
        public HelloMessage HelloMsg { get; set; }

        public string Noti { get; set; }

        public void OnGet()
        {
            this.HelloMsg = new HelloMessage()
            {
                Message = "Hello Razor Pages"
            };
        }

        public void OnPost()
        {
            this.Noti = "Message Changed";
        }
    }
}

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

    // M
    // VC
    // M - V - VM

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
            services.AddRazorPages();
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
                endpoints.MapRazorPages();
            });
        }
    }
}
