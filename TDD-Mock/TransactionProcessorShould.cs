using Moq;
using Shouldly;
using Xunit;

namespace TDD_Mock
{
    public class TransactionProcessorServiceShould
    {
        [Fact]
        public void Send_money_to_ewallet_on_deposit()
        {
            int amount = 999;
            Mock<IEwalletService> ewalletServiceMock = new Mock<IEwalletService>();
            ewalletServiceMock
                .Setup(x => x.Deposit(amount))
                .Verifiable();
            Mock<IPrintingService> printerMock = new Mock<IPrintingService>();

            var service = new TransactionProcessorService(ewalletServiceMock.Object, printerMock.Object);
            service.Deposit(999);
            ewalletServiceMock.Verify();
        }

        [Fact]
        public void Throw_exception_when_depositing_with_negative_amount()
        {
            var service = new TransactionProcessorService(null, null);
            Should.Throw<DepositIsNegativeException>(() => { service.Deposit(-1000); });
        }

        [Fact]
        public void Register_two_consecutive_deposits()
        {
            int firstAmount= 999;
            int secondAmount = 1000;
            Mock<IEwalletService> ewalletServiceMock = new Mock<IEwalletService>();
            ewalletServiceMock
                .Setup(x => x.Deposit(firstAmount))
                .Verifiable();
            Mock<IPrintingService> printerMock = new Mock<IPrintingService>();

            var service = new TransactionProcessorService(ewalletServiceMock.Object, printerMock.Object);
            service.Deposit(999);
            ewalletServiceMock.Verify();   
        }
    }

    public interface IEwalletService
    {
        void Deposit(int amount);
    }

    public class EwalletService : IEwalletService
    {
        public void Deposit(int amount)
        {
        }
    }
}