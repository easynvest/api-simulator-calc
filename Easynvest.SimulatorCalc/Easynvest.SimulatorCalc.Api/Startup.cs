using Easynvest.SimulatorCalc.Application.Handlers;
using Easynvest.SimulatorCalc.Domain.Contracts;
using Easynvest.SimulatorCalc.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using Easynvest.SimulatorCalc.Domain.Interpolation;
using Easynvest.SimulatorCalc.Domain.Investment;

namespace Easynvest.SimulatorCalc.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var handlersAssembly = typeof(SimulateInvestmentHandler).GetTypeInfo().Assembly;
            services.AddMediatR(handlersAssembly);
            services.AddMvc();

            ConfigureIoC(services);
        }

        private void ConfigureIoC(IServiceCollection services)
        {
            services.AddScoped<ICalendarRepository, CalendarRepository>();
            services.AddScoped<IEttjRepository, EttjRepository>();
            services.AddScoped<IInterpolationCalculator, InterpolationCalculator>();
            services.AddScoped<IInvestmentSimulator, InvestmentSimulator>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Calculator is online");
            });
        }
    }
}
