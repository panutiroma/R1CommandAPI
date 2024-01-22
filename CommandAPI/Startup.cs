using CommandAPI.Data;
using CommandAPI.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace CommandAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("CommandApi"));

            // Build an intermediate service provider
            var serviceProvider = services.BuildServiceProvider();
            // Resolve the AppSettings from the service provider
            var settings = serviceProvider.GetService<IOptions<AppSettings>>().Value;

            //services.AddDbContext<CommandContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.Audience = settings.ResourceId;
                    opt.Authority = $"{settings.Instance}{settings.TenantId}";
                });

            services.AddControllers();

            services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context => await context.Response.WriteAsync("Hello World!"));
                endpoints.MapControllers();
            });
        }
    }
}
