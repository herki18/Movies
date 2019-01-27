using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Movies.Api.BLL;
using Movies.Api.Contracts;
using Movies.Api.Contracts.Interfaces.Repositories;
using Movies.Api.Contracts.Interfaces.Services;
using Movies.Api.Contracts.Queries;
using Movies.Api.DAL;
using Movies.Api.DAL.Repositories;
using Movies.Api.Validators;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Movies.Api
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
            services.AddDbContext<ApiContext>(opt => opt.UseSqlite("Data Source=Movies.db;"));

            // Validation rules
            services.AddSingleton<IValidator<MoviesQuery>,MoviesQueryValidator>();
            services.AddSingleton<IValidator<RatingBody>,RatingBodyValidator>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            
            // Set Adapter pattern
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Set Up Repositories
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IRatingsRepository, RatingsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            // Set Up Services
            services.AddScoped<IMovieService, MoviesService>();
            services.AddScoped<IRatingsService, RatingsService>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Movies API",
                    Description = "Movies API"
                });
            });

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApiContext apiContext)
        {
            if (env.IsDevelopment())
            {
                apiContext.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                apiContext.Database.Migrate();
            }
            
            app.UseCors("SiteCorsPolicy");
            app.UseSwagger();
            app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}