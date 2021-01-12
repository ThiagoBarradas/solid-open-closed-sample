using Microsoft.AspNetCore.Mvc;
using SOLID.OpenClosed.Sample.Api.Factories.Interface;
using SOLID.OpenClosed.Sample.Api.Models;

namespace SOLID.OpenClosed.Sample.Api.Controllers
{
    [Route("payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServiceFactory PaymentServiceFactory;

        public PaymentController(IPaymentServiceFactory paymentServiceFactory)
        {
            this.PaymentServiceFactory = paymentServiceFactory;
        }

        [HttpPost]
        public Payment CreatePayment([FromBody] Payment payment)
        {
            var paymentService = this.PaymentServiceFactory.GetProcessor(payment.Type);
            var paymentResult = paymentService.ProcessPayment(payment);

            return paymentResult;
        }
    }
}
