using SOLID.OpenClosed.Sample.Api.Models;

namespace SOLID.OpenClosed.Sample.Api.Services.Interface
{
    public interface IPaymentService
    {
        Payment ProcessPayment(Payment payment);
    }
}
