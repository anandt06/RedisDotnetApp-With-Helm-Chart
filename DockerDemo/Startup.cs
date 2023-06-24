using System.Diagnostics.CodeAnalysis;
using StackExchange.Redis;

namespace DockerDemo
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var multiplexer = ConnectionMultiplexer.Connect("demoapp-redis-master:6379,ssl=False,abortConnect=False");

            services.AddScoped(s => multiplexer.GetDatabase());
            services.AddHealthChecks();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(AllowSpecificOrigins);

            app.UseRouting();


            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }
}