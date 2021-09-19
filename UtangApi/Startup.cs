using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pera.UtangApi.Handlers;
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
            services.AddScoped<IBalanceRepository, BalanceRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IBalanceService, BalanceService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UtangApi", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method will seed sample data to UtangDb
        private static void Seed(UtangContext context)
        {
            int transactionId = 0;
            int loanId = 0;

            Loan loan = new();
            loan.TransactionId = ++transactionId;
            loan.LoanId = ++loanId;
            loan.AccountNumber = "000000000001";
            loan.Date = DateTime.Today.AddMonths(-13);
            loan.Amount = 20000;
            loan.Year = 2;
            loan.InterestRate = 0.08M;
            loan.ClosedReason = "";
            context.Loans.Add(loan);

            List<Payment> payments = new();
            for (int month = 0; month < 12; month++)
            {
                Payment payment = new()
                {
                    TransactionId = ++transactionId,
                    LoanId = loan.LoanId,
                    AccountNumber = "000000000001",
                    Date = DateTime.Today.AddMonths(month - 12),
                    Amount = 1000,
                    Status = ""
                };
                payments.Add(payment);
            }
            context.Payments.AddRange(payments);

            loan = new();
            loan.TransactionId = ++transactionId;
            loan.LoanId = ++loanId;
            loan.AccountNumber = "000000000002";
            loan.Date = DateTime.Today.AddYears(-2);
            loan.Amount = 20000;
            loan.Year = 2;
            loan.InterestRate = 0.08M;
            loan.ClosedReason = "";
            context.Loans.Add(loan);

            context.SaveChanges();
        }
    }
}
