using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedData.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
    // REST (Representational State Transfer)
    // 공식 표준 스펙은 아님
    // 원래 있던 HTTP 통신에서 기능을 '재사용'해서 데이터 송수신 규칙을 만든 것

    // CRUD

    // www.naver.com > 현대 백화점 지하 1층
    // www.naver.com/sprots/ > 현대 백화점 지하 1층 일식당 XXX
    // verb (GET, POST, PUT ...)

    // Create
    // POST /api/ranking
    // -- 아이템 생성 요청 (Body에 실제 정보)

    // Read
    // GET /api/rainking
    // 모든 아이템을 주세요
    // GET /api/rainking/1
    // 아이디 값이 1번인 아이템을 주세요.

    // Update
    // PUT /api/ranking (보안 문제로 웹에선 활용 X)
    // 아이템 갱신 요청 (Body에 실제 정보)

    // Delete
    // DELETE /api/ranking/1 (DELETE도 보안 문제로 웹에서 활용 X)
    // id가 1번인 아이를 삭제해주세요.

    // APIController 특징
    // 그냥 C# 객체를 반환해도 된다.
    // null 반환하면 > 클라에 204 Response (No Content)
    // string > text/plain
    // 나머지 (int, bool) > application/json

    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        ApplicationDbContext _context;

        public RankingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE
        [HttpPost]
        public GameResult AddGameResult([FromBody] GameResult gameReslut)
        {
            _context.GameResults.Add(gameReslut);
            _context.SaveChanges();

            return gameReslut;
        }

        // READ
        [HttpGet]
        public List<GameResult> GetGameResults()
        {
            List<GameResult> results = _context.GameResults
                .OrderByDescending(item => item.Score)
                .ToList();

            return results;
        }

        [HttpGet("{id}")]
        public GameResult GetGameResults(int id)
        {
            GameResult result = _context.GameResults
                .Where(item => item.Id == id)
                .FirstOrDefault();

            return result;
        }

        // UPDATE
        [HttpPut]
        public bool UpdateGameReslut([FromBody] GameResult gameResult)
        {
            var findResult = _context.GameResults
                .Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if (findResult == null)
                return false;

            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;
            _context.SaveChanges();

            return true;
        }

        // DELETE
        [HttpDelete("{id}")]
        public bool DeleteGameResult(int id)
        {
            var findResult = _context.GameResults
                 .Where(x => x.Id == id)
                 .FirstOrDefault();

            if (findResult == null)
                return false;

            _context.GameResults.Remove(findResult);
            _context.SaveChanges();

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi.Data;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

