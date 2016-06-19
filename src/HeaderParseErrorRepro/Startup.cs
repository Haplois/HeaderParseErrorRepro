using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HeaderParseErrorRepro
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions() { SourceCodeLineCount = 20 })
               .UseStatusCodePages()
               .UseMvc();
        }
    }
}
