using Newtonsoft.Json;
using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RankingApp.Data.Services
{
	public class RankingService
	{
		HttpClient _httpClient;

		public RankingService(HttpClient client)
		{
			_httpClient = client;
		}

		// Create
		public async Task<GameResult> AddGameResult(GameResult gameResult)
		{
			string jsonStr = JsonConvert.SerializeObject(gameResult);
			var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
			var result = await _httpClient.PostAsync("api/ranking", content);

			if (result.IsSuccessStatusCode == false)
				throw new Exception("AddGameResult Failed");

			var resultContent = await result.Content.ReadAsStringAsync();
			GameResult resGameResult = JsonConvert.DeserializeObject<GameResult>(resultContent);
			return resGameResult;
		}

		// Read
		public async Task<List<GameResult>> GetGameResultsAsync()
		{
			var result = await _httpClient.GetAsync("api/ranking");

			var resultContent = await result.Content.ReadAsStringAsync();
			List<GameResult> resGameResults = JsonConvert.DeserializeObject<List<GameResult>>(resultContent);
			return resGameResults;
		}

		// Update
		public async Task<bool> UpdateGameResult(GameResult gameResult)
		{
			string jsonStr = JsonConvert.SerializeObject(gameResult);
			var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
			var result = await _httpClient.PutAsync("api/ranking", content);

			if (result.IsSuccessStatusCode == false)
				throw new Exception("UpdateGameResult Failed");

			return true;
		}

		// Delete
		public async Task<bool> DeleteGameResult(GameResult gameResult)
		{
			var result = await _httpClient.DeleteAsync($"api/ranking/{gameResult.Id}");

			if (result.IsSuccessStatusCode == false)
				throw new Exception("DeleteGameResult Failed");

			return true;
		}
	}
}

@page "/ranking"
@using SharedData.Models
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
	_gameResults = await RankingService.GetGameResultsAsync();
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
	var result = RankingService.DeleteGameResult(gameResult);
	_gameResults = await RankingService.GetGameResultsAsync();
}

async Task SaveGameResult()
{
	if (_gameResult.Id == 0)
	{
		_gameResult.Date = DateTime.Now;
		var result = await RankingService.AddGameResult(_gameResult);
	}
	else
	{
		var result = await RankingService.UpdateGameResult(_gameResult);
	}

	_showPopup = false;
	_gameResults = await RankingService.GetGameResultsAsync();
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

			services.AddHttpClient<RankingService>(c =>
			{
				c.BaseAddress = new Uri("https://localhost:44351");
			});
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
