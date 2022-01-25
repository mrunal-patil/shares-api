using System;
using System.Net.Http;
using Download.StockHistory.Adapter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shares.Domain.Ports;
using Shares.Domain.Services;
using Shares.Domain.Usecases;

namespace Shares.Api
{
    public class Startup
    {
        private const string APP_NAME = "Shares API";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo {Title = $"{APP_NAME}", Version = "v1"});
            });

            services.AddScoped<SaveStockHistory>();
            services.AddScoped<GetCycles>();
            services.AddScoped<GetCyclesByPercentageAndDateInterval>();
            services.AddScoped<StopLossIndicator>();
            services.AddScoped<AverageCalculator>();
            services.AddScoped<CurrentPerformanceCalculator>();

            services.AddScoped<ICreateCycles, CyclesCreator>();
            services.AddScoped<ICreateStopLossCycles, StopLossCyclesCreator>();

            services.AddHttpClient<IDownloadStockHistory, StockHistoryDownloader>(client =>
                client.BaseAddress = new Uri(Configuration["YahooFinanceApi:Url"]));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{APP_NAME} v1"));

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}