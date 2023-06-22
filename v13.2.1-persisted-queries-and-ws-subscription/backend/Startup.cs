using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebSocketAndPersistedQueriesBug
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
            services
                .AddGraphQLServer()
                .UsePersistedQueryPipeline()
                .AddQueryType<Query>()
                .AddSubscriptionType<Subscription>()
                .AddReadOnlyFileSystemQueryStorage("./PersistedQueries");

            services
                .AddCors(options =>
                {
                    options.AddDefaultPolicy(policy =>
                    {
                        policy.WithOrigins("http://localhost:7000").AllowAnyHeader().AllowAnyMethod();
                    });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/api/graphql");
            });
        }
    }
}
