using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Property_API.Models;
using Property_API.Repository;

namespace Property_API
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddDbContext<DBContext>(o => o.UseNpgsql(Configuration.GetConnectionString("PropertyDB")));
            services.AddDbContext<DBContext>(o => o.UseSqlServer(Configuration.GetConnectionString("PropertySQL")));

            services.AddTransient<IRepository<Property>, PropertyRepository>();
            services.AddTransient<IRepository<PropertyImage>, PropertyImageRepository>();
            services.AddTransient<IRepository<PropertyType>, PropertyTypeRepository>();
            services.AddTransient<IRepository<PropertyUserField>, PropertyUserFieldRepository>();
            services.AddTransient<IRepository<UserDefinedField>, UserDefinedFieldRepository>();
            services.AddTransient<IUserDefinedGroupRepository, UserDefinedGroupRepository>();

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");
            app.UseMvc();
        }
    }
}
