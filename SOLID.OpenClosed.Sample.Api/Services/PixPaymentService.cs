using SOLID.OpenClosed.Sample.Api.Models;
using SOLID.OpenClosed.Sample.Api.Services.Interface;

namespace SOLID.OpenClosed.Sample.Api.Services
{
    public class PixPaymentService : IPaymentService
    {
        public Payment ProcessPayment(Payment payment)
        {
            // do something
            payment.Message = "PixPaymentService.ProcessPayment";

            return payment;
        }
    }
}
