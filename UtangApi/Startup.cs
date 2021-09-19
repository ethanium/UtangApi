using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pera.UtangApi.Models;
using Pera.UtangApi.Repositories;
using Pera.UtangApi.Services;
using System;
using System.Collections.Generic;

namespace Pera.UtangApi
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

            services.AddControllers();
            services.AddDbContext<UtangContext>(opt => opt.UseInMemoryDatabase("UtangDb"));
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UtangApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UtangApi v1"));

                IServiceScope scope = app.ApplicationServices.CreateScope();
                UtangContext context = scope.ServiceProvider.GetRequiredService<UtangContext>();
                Seed(context);
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method will seed sample data to UtangDb
        private static void Seed(UtangContext context)
        {
            List<Payment> payments = new();
            for (int i = 1; i < 12; i++)
            {
                Payment payment = new()
                {
                    Id = i,
                    AccountNumber = "000000000001",
                    Date = DateTime.Today.AddMonths(i - 12),
                    Amount = 1000,
                    Status = ""
                };
                payments.Add(payment);
            }
            context.Payments.AddRange(payments);
            context.SaveChanges();
        }
    }
}
