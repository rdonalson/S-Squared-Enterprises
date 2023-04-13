using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SSE.Data.Context;

namespace SSE.Web
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
			// Setting up Swagger
			services.AddSwaggerGen(s =>
			{
				s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SSE-API", Version = "v1" });
			});



			// Creating policies that wraps the authorization requirements
			services.AddAuthorization();

			services.AddDbContext<SSEContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("SSEContext")));

			services.AddControllers();

			// Allowing CORS for all domains and methods for the purpose of the sample
			// In production, modify this with the actual domains you want to allow
			services.AddCors(o => o.AddPolicy("default", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "SSE-API");
				});

				app.UseDeveloperExceptionPage();
			}

			app.UseCors("default");
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
