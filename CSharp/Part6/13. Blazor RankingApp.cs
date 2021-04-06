using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankingApp.Data.Migrations
{
    public partial class RankingService : Migration
    {
        // 버전컨트롤로 인해 Up, Down으로 이용한다.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResults", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameResults");
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApp.Data.Models
{
    // v4.0 GameResult
    // v3.0 으로 수정한다면..?
    public class GameResult
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}


using RankingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApp.Data.Services
{
    public class RankingService
    {
        ApplicationDbContext _context;

        public RankingService(ApplicationDbContext context)
        {
            _context = context;
        }

        // CRUD
        // Create
        public Task<GameResult> AddGameResult(GameResult gameResult)
        {
            _context.GameResults.Add(gameResult);
            _context.SaveChanges();

            return Task.FromResult(gameResult);
        }

        // Read
        public Task<List<GameResult>> GetGameResultAsync()
        {
            List<GameResult> results = _context.GameResults.
                OrderByDescending(item => item.Score).ToList();

            return Task.FromResult(results);
        }

        // Update
        public Task<bool> UpdateGameResult(GameResult gameResult)
        {
            var findReslut = _context.GameResults
                .Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if (findReslut == null)
                return Task.FromResult(false);

            findReslut.UserName = gameResult.UserName;
            findReslut.Score = gameResult.Score;
            _context.SaveChangesAsync();

            return Task.FromResult(true);
        }

        // Delete
        public Task<bool> DeleteGameResult(GameResult gameResult)
        {
            var findReslut = _context.GameResults
                .Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if (findReslut == null)
                return Task.FromResult(false);

            _context.GameResults.Remove(gameResult);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RankingApp.Data.Models;

namespace RankingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<GameResult> GameResults { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}


@page "/ranking"
@using RankingApp.Data.Models
@using RankingApp.Data.Services

@inject RankingService RankingService

<h3>Ranking</h3>

<AuthorizeView>
    <Authorized>
        @if (_gameResults == null)
{
            < p >< em > Loading...</ em ></ p >
        }
        else
{
            < table class= "table" >
 
                 < thead >
 
                     < tr >
 
                         < th > UserName </ th >
 
                         < th > Score </ th >
 
                         < th > Date </ th >
 
                         < th ></ th >
 
                         < th ></ th >
 
                     </ tr >
 
                 </ thead >
 
                 < tbody >
                     @foreach(var gameResult in _gameResults)
                    {
                    < tr >
                        < td > @gameResult.UserName </ td >
                        < td > @gameResult.Score </ td >
                        < td > @gameResult.Date.ToString() </ td >
                        < td >
                            < button class= "btn btn-primary" @onclick = "() => UpdateGameResult(gameResult)" > Edit </ button >
  
                          </ td >
  
                          < td >
  
                              < button class= "btn btn-primary" @onclick = "() => DeleteGameResult(gameResult)" > Delete </ button >
    
                            </ td >
    
                        </ tr >
                    }
                </ tbody >
            </ table >

            < p >
                < button class= "btn btn-primary" @onclick = "AddGameResult" >
                      Add
                  </ button >
  
              </ p >

              @if(_showPopup)
            {
                < div class= "modal" style = "display:block" role = "dialog" >
    
                        < div class= "modal-dialog" >
     
                             < div class= "modal-content" >
      
                                  < div class= "modal-header" >
       
                                       < h3 class= "modal-title" > Add / Update GameResult </ h3 >
             
                                             < button type = "button" class= "close" @onclick = "ClosePopup" >
                 
                                                     < span area - hidden = "true" > X </ span >
                  
                                                  </ button >
                  
                                              </ div >
                  
                                              < div class= "modal-body" >
                   
                                                   < label for= "UserName" > UserName </ label >
                    
                                                    < input class= "form-control" type = "text" placeholder = "UserName" @bind - value = "_gameResult.UserName" />
                          
                                                          < label for= "Score" > Score </ label >
                           
                                                           < input class= "form-control" type = "text" placeholder = "Score" @bind - value = "_gameResult.Score" />
                                 
                                                                 < button class= "btn btn-primary" @onclick = "SaveGameResult" >
                                                                       Save
                                                                   </ button >
                                   
                                                               </ div >
                                   
                                                           </ div >
                                   
                                                       </ div >
                                   

                                                   </ div >
            }
        }
    </ Authorized >
    < NotAuthorized >
        < p > You are not Authorized!</p>
    </NotAuthorized>
</AuthorizeView>

@code {

    List<GameResult> _gameResults;
bool _showPopup;
GameResult _gameResult;

protected override async Task OnInitializedAsync()
{
    _gameResults = await RankingService.GetGameResultAsync();
}

void AddGameResult()
{
    _showPopup = true;
    _gameResult = new GameResult() { Id = 0 };
}

void ClosePopup()
{
    _showPopup = false;
}

void UpdateGameResult(GameResult gameResult)
{
    _showPopup = true;
    _gameResult = gameResult;
}

async Task DeleteGameResult(GameResult gameResult)
{
    var result = RankingService.DeleteGameResult(_gameResult);
    _gameResults = await RankingService.GetGameResultAsync();
}

async Task SaveGameResult()
{
    if (_gameResult.Id == 0)
    {
        _gameResult.Date = DateTime.Now;
        var result = RankingService.AddGameResult(_gameResult);
    }
    else
    {
        var result = RankingService.UpdateGameResult(_gameResult);
    }

    _showPopup = false;
    _gameResults = await RankingService.GetGameResultAsync();
}
}


< div class= "top-row pl-4 navbar navbar-dark" >
 
     < a class= "navbar-brand" href = "" > RankingApp </ a >
   
       < button class= "navbar-toggler" @onclick = "ToggleNavMenu" >
     
             < span class= "navbar-toggler-icon" ></ span >
      
          </ button >
      </ div >
      

      < div class= "@NavMenuCssClass" @onclick = "ToggleNavMenu" >
        
            < ul class= "nav flex-column" >
         
                 < li class= "nav-item px-3" >
          
                      < NavLink class= "nav-link" href = "" Match = "NavLinkMatch.All" >
              
                              < span class= "oi oi-home" aria - hidden = "true" ></ span > Home
                            </ NavLink >
                
                        </ li >
                
                        < li class= "nav-item px-3" >
                 
                             < NavLink class= "nav-link" href = "ranking" >
                   
                                   < span class= "oi oi-list-rich" aria - hidden = "true" ></ span > Ranking
                                 </ NavLink >
                     
                             </ li >
                     
                         </ ul >
                     </ div >

                     @code {
    private bool collapseNavMenu = true;

private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

private void ToggleNavMenu()
{
    collapseNavMenu = !collapseNavMenu;
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RankingApp.Areas.Identity;
using RankingApp.Data;
using RankingApp.Data.Services;

namespace RankingApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            services.AddScoped<RankingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
