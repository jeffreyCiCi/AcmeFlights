using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Infrastructure.Repository;
using DomainServices.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using FlightsCore.Interfaces;
using FlightsCore.Models;

namespace FlightsWeb
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AcmeFlightsContext>(
                optionsBuilder => optionsBuilder.UseInMemoryDatabase(databaseName:"AcmeFlights"));

            services.Add(new ServiceDescriptor(typeof(IFlightsRepository), typeof(FlightsRepository), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IFlightService), typeof(FlightService), ServiceLifetime.Scoped));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
