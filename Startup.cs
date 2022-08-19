using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestProjectGraphQL.application.graphql.Mutations;
using TestProjectGraphQL.application.graphql.Queries;
using TestProjectGraphQL.data;
using TestProjectGraphQL.data.interfaces;
using TestProjectGraphQL.data.models;

namespace TestProjectGraphQL
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType(descriptor => descriptor.Name("Query"))
                .AddTypeExtension<OrderQueries>()
                .AddTypeExtension<TrainQueries>()
                .AddMutationType(descriptor => descriptor.Name("Mutation"))
                .AddTypeExtension<OrderMutations>()
                .AddTypeExtension<TrainMutations>();
            services
                .AddEntityFrameworkSqlServer()
                .AddSingleton<IOrderRepository, SQLRepository>()
                .AddSingleton<ITrainRepository, SQLRepository>()
                .AddDbContext<dbContext>(x => x.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TestProjectSQL;Trusted_Connection=True;"), ServiceLifetime.Singleton);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/");
            });
        }
    }
}
