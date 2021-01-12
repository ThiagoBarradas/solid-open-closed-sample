using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SOLID.OpenClosed.Sample.Api.Factories;
using SOLID.OpenClosed.Sample.Api.Factories.Interface;
using SOLID.OpenClosed.Sample.Api.Models;
using SOLID.OpenClosed.Sample.Api.Services;
using SOLID.OpenClosed.Sample.Api.Services.Interface;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SOLID.OpenClosed.Sample.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            this.RegisterPaymentServices(services);

            services
                .AddControllers()
                .AddJsonOptions(opts =>
                    {
                        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });
        }

        public void RegisterPaymentServices(IServiceCollection services)
        {
            // register each specific "class" as singleton
            // to resolve your dependencies automatically
            services.AddSingleton<CreditCardPaymentService>();
            services.AddSingleton<DebitCardPaymentService>();
            services.AddSingleton<BankInvoicePaymentService>();

            // add factory as singleton with enum/class map
            services.AddSingleton<IPaymentServiceFactory>(provider =>
            {
                var paymentServices = new Dictionary<PaymentType, IPaymentService>
                {
                    { PaymentType.BankInvoice, provider.GetService<BankInvoicePaymentService>() },
                    { PaymentType.CreditCard,  provider.GetService<CreditCardPaymentService>()  },
                    { PaymentType.DebitCard,   provider.GetService<DebitCardPaymentService>()   },
                };

                return new PaymentServiceFactory(paymentServices);
            });
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
                endpoints.MapControllers();
            });
        }
    }
}
