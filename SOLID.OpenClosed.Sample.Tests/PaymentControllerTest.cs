using Moq;
using SOLID.OpenClosed.Sample.Api.Controllers;
using SOLID.OpenClosed.Sample.Api.Factories.Interface;
using SOLID.OpenClosed.Sample.Api.Models;
using SOLID.OpenClosed.Sample.Api.Services.Interface;
using Xunit;

namespace SOLID.OpenClosed.Sample.Tests
{
    public class PaymentControllerTest
    {
        [Fact]
        public void SampleTest_MockFactory()
        {
            // arrange
            var initialPayment = new Payment
            {
                Type = PaymentType.CreditCard
            };

            var expectedPayment = new Payment
            {
                Type = PaymentType.CreditCard,
                Message = "CreditCard Test"
            };

            var creditCardPaymentService = new Mock<IPaymentService>();
            creditCardPaymentService
                .Setup(m => m.ProcessPayment(initialPayment))
                .Returns(expectedPayment);

            var paymentServiceFactory = new Mock<IPaymentServiceFactory>();
            paymentServiceFactory
                .Setup(m => m.GetProcessor(PaymentType.CreditCard))
                .Returns(creditCardPaymentService.Object);

            var controller = new PaymentController(paymentServiceFactory.Object);

            // act
            var result = controller.CreatePayment(initialPayment);

            // assert
            Assert.NotNull(result);
            Assert.Equal(PaymentType.CreditCard, result.Type);
            Assert.Equal("CreditCard Test", result.Message);
            paymentServiceFactory.Verify(m => m.GetProcessor(PaymentType.CreditCard), Times.Once());
            creditCardPaymentService.Verify(m => m.ProcessPayment(initialPayment), Times.Once());
        }
    }
}
