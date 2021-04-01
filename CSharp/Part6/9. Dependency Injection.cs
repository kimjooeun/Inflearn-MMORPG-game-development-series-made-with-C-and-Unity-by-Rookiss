using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorApp.Data;

namespace BlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            // Dependency Injection
            // 의존성      주입
            services.AddSingleton<IFoodService, FastFoodService>();
            // 생성자에서 알아서 연결해준다.
            services.AddSingleton<PaymentService>();

            // 3가지 모드
            services.AddSingleton<SingltonService>();
            services.AddTransient<TransientService>();
            services.AddScoped<ScopedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}


@page "/"

@using BlazorApp.Data;
@inject IFoodService foodService;
@inject PaymentService paymentService;

@*생명주기가 모두 다른 것을 알아야한다.*@
@inject SingltonService singleton;
@*싱글톤은 서버가 시작될때 한번 생성되고 변동이 없다.
누구에게나 똑같은 서비스를 보여줘야 할 때는 싱글톤을 사용한다.*@
@inject TransientService transient;
@*TransientService는 매 요청시에마다 변한다.*@
@inject ScopedService scoped;
@*ScopedService 처음 접속시에만 생성되고 그 다음에는 변하지 않는다.*@

        <div>
            @foreach (var food in foodService.GetFoods())
            {
                < div > @food.Name </ div >
                < div > @food.Price </ div >
            }
        </ div >

        < div >
            < h1 > Singleton </ h1 >
            Guid : @singleton.ID
            <h1> Transient</h1>
            Guid : @transient.ID
            <h1> scoped</h1>
            Guid : @scoped.ID

        </ div >

        @code { // IFoodService _foodService = new FastFoodService();
            // 위에 new FastFoodService();이 매번 new로 생성되는 것을 막기위해
            // Dependency Injection이 생겼다.

protected override void OnInitialized()
{

}

        }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    // Dependency Injection
    public class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public interface IFoodService
    {
        IEnumerable<Food> GetFoods();
    }

    public class FoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            {
                new Food() {Name = "Bibimbap", Price = 7000 },
                new Food() {Name = "Kimbap", Price = 3000 },
                new Food() {Name = "Bossam", Price = 9000 }
            };

            return foods;
        }
    }
    public class FastFoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            {
                new Food() {Name = "Hamburger", Price = 500 },
            };

            return foods;
        }
    }

    public class PaymentService
    {
        IFoodService _service;

        // 생성자
        public PaymentService(IFoodService service)
        {
            _service = service;
        }
        // 건드리지 않아도 알아서 주입된다.

        //TODO
    }

    public class SingltonService : IDisposable
    {
        public Guid ID { get; set; }

        public SingltonService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("SingltonService Disposed");
        }
    }

    public class TransientService : IDisposable
    {
        public Guid ID { get; set; }

        public TransientService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("SingltonService Disposed");
        }
    }
    public class ScopedService : IDisposable
    {
        public Guid ID { get; set; }

        public ScopedService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("SingltonService Disposed");
        }
    }
}
