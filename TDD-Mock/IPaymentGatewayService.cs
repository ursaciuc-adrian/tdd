namespace TDD_Mock
{
    public interface IPaymentGatewayService
    {
        void MakePayment(PaymentDetails paymentDetails);
    }
}