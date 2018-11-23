using Moq;
using Shouldly;
using Xunit;
using Xunit.Sdk;

namespace TDD_Mock
{
//    public class PaymentServiceShould
//    {
//        private readonly Mock<IValidationService> _validationServiceMock;
//        private readonly Mock<IPaymentGatewayService> _paymentGatewayServiceMock;
//
//        public PaymentServiceShould()
//        {
//             _validationServiceMock = new Mock<IValidationService>();
//            _paymentGatewayServiceMock=new Mock<IPaymentGatewayService>();
//        }
//        
//        [Fact]
//        public void ThrowUserIsNotValidException_WhenUserIsInvalid()
//        {
//            User user = new User();
//            PaymentDetails paymentDetails = new PaymentDetails();
//            
//            _validationServiceMock.Setup(x => x.IsValid(user)).Returns(false);
//
//            PaymentService paymentService =
//                new PaymentService(_paymentGatewayServiceMock.Object, _validationServiceMock.Object);
//
//            Should.Throw<UserIsNotValidException>(() =>
//            {
//                paymentService.ProcessPayment(user, paymentDetails);
//            });
//        }
//
//        [Fact]
//        public void NotThrowUserIsNotValidException_WhenUserIsValid()
//        {
//            User user = new User();
//            PaymentDetails paymentDetails = new PaymentDetails();
//            
//            _validationServiceMock.Setup(x => x.IsValid(user)).Returns(true);
//
//            PaymentService paymentService =
//                new PaymentService(_paymentGatewayServiceMock.Object, _validationServiceMock.Object);
//
//            Should.NotThrow(() =>
//            {
//                paymentService.ProcessPayment(user, paymentDetails);
//            });
//        }
//
//        [Fact]
//        public void NotMakeThePayment_WhenTheUserIsNotValid()
//        {
//            User user = new User();
//            PaymentDetails paymentDetails = new PaymentDetails();
//            
//            _validationServiceMock.Setup(x => x.IsValid(user)).Returns(false);
//            
//            PaymentService paymentService = new PaymentService(_paymentGatewayServiceMock.Object, _validationServiceMock.Object);
//
//            Should.Throw<UserIsNotValidException>(() =>
//            {
//                paymentService.ProcessPayment(user,paymentDetails);
//            });
//            _paymentGatewayServiceMock.Verify(x => x.MakePayment(paymentDetails), Times.Never);
//        }
//        
//        [Fact]
//        public void MakeThePayment_WhenTheUserIsValid()
//        {
//            User user = new User();
//            PaymentDetails paymentDetails = new PaymentDetails();
//            
//            _validationServiceMock.Setup(x => x.IsValid(user)).Returns(true);
//            _paymentGatewayServiceMock.Setup(x => x.MakePayment(paymentDetails));
//            
//            PaymentService paymentService = new PaymentService(_paymentGatewayServiceMock.Object, _validationServiceMock.Object);
//            paymentService.ProcessPayment(user,paymentDetails);
//            _paymentGatewayServiceMock.Verify(x => x.MakePayment(paymentDetails), Times.Once());
//        }
//    }
}