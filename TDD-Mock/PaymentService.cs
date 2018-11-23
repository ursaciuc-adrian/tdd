using System;

namespace TDD_Mock
{
    public class PaymentService
    {
        private readonly IPaymentGatewayService _paymentGatewayService;
        private readonly IValidationService _validationService;

        public PaymentService(IPaymentGatewayService paymentGatewayService, IValidationService validationService)
        {
            _paymentGatewayService = paymentGatewayService;
            _validationService = validationService;
        }
        
        public void ProcessPayment(User user, PaymentDetails paymentDetails)
        {
            if (!_validationService.IsValid(user))
            {
                throw new UserIsNotValidException();
            }
            
            _paymentGatewayService.MakePayment(paymentDetails);
        }
    }
}