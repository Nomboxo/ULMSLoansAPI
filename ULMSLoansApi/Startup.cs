using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ULMSLoansDomain.Contracts.Repository;
using ULMSLoansDomain.Contracts.Services;
using ULMSLoansDomain.Services;
using ULMSRepository.Context;
using ULMSRepository.Logic;

namespace ULMSLoansApi
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
            var connection = "Server=MANE2\\MANELISI;Database=ULMSCustomer;Trusted_Connection=True;";
            services.AddDbContext<ULMSLoansContext>(options => options.UseSqlServer(connection));
            services.AddMvc();
            services.AddTransient<ILoansService, LoansService>();
            services.AddTransient<ILoansRepository, LoansRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ULMSLoansContext>();
                context.Database.EnsureCreated();
            }
            app.UseMvc();
        }
    }
}
