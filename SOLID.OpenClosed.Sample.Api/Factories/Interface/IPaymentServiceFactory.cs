using SOLID.OpenClosed.Sample.Api.Models;
using SOLID.OpenClosed.Sample.Api.Services.Interface;

namespace SOLID.OpenClosed.Sample.Api.Factories.Interface
{
    public interface IPaymentServiceFactory
    {
        IPaymentService GetProcessor(PaymentType type);
    }
}
