using SOLID.OpenClosed.Sample.Api.Factories.Interface;
using SOLID.OpenClosed.Sample.Api.Models;
using SOLID.OpenClosed.Sample.Api.Services.Interface;
using System;
using System.Collections.Generic;

namespace SOLID.OpenClosed.Sample.Api.Factories
{
    public class PaymentServiceFactory : IPaymentServiceFactory
    {
        private readonly IDictionary<PaymentType, IPaymentService> PaymentServices;

        public PaymentServiceFactory(IDictionary<PaymentType, IPaymentService> paymentServices)
        {
            this.PaymentServices = paymentServices;
        }

        public IPaymentService GetProcessor(PaymentType type)
        {
            if (!this.PaymentServices.ContainsKey(type))
            {
                throw new NotImplementedException("Payment type not implemented");
            }   

            return this.PaymentServices[type];
        }
    }
}
