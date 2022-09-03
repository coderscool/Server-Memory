using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Server.Application.CommentService;
using Server.Application.FriendService;
using Server.Application.PostsService;
using Server.Application.ProfileService;
using Server.Application.UsersService;
using Server.Data.EF;
using Server.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
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
            services.AddDbContext<ServerDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Swagger Pictur Authen", Version = "v2" });
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
           options.WithOrigins("http://localhost:3000")
           .AllowAnyHeader()
           .AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Swagger AuthenApi V2");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
