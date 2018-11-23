using System;
using Moq;
using Shouldly;
using Xunit;

namespace TDD_Mock
{
    public class AcceptanceTests
    {
        [Fact]
        public void Should_deposit_with_no_error()
        {
            var service = new TransactionProcessorService(new EwalletService(), null);
            Should.NotThrow(() => { service.Deposit(100); });
        }

        [Fact]
        public void Should_throw_exception_when_depositing_with_negative_amount()
        {
            var service = new TransactionProcessorService(null, null);
            Should.Throw<DepositIsNegativeException>(() => { service.Deposit(-1000); });
        }

        [Fact]
        public void When_depositing_should_reflect_in_history()
        {
            int amount = 200;
            Mock<IPrintingService> printerMock = new Mock<IPrintingService>();
            printerMock.Setup(x => x.PrintHeader()).Verifiable();
            printerMock.Setup(x => x.Print(It.IsAny<DateTime>(), amount, amount)).Verifiable();
            var service = new TransactionProcessorService(new EwalletService(), printerMock.Object);
            service.Deposit(amount);
            service.PrintHistory();

            printerMock.Verify();
        }

        [Fact]
        public void When_depositing_two_times_should_calculate_corectlly_the_total()
        {

            int firstDeposit = 100;
            int secondDeposit = 200;
            Mock<IPrintingService> printerMock = new Mock<IPrintingService>();
            printerMock.Setup(x => x.PrintHeader()).Verifiable();
            printerMock.Setup(x => x.Print(It.IsAny<DateTime>(), firstDeposit, firstDeposit)).Verifiable();
            printerMock.Setup(x => x.Print(It.IsAny<DateTime>(), secondDeposit, firstDeposit+secondDeposit)).Verifiable();
            
            var service = new TransactionProcessorService(new EwalletService(), printerMock.Object);
            service.Deposit(firstDeposit);
            service.Deposit(secondDeposit);
            service.PrintHistory();

            printerMock.Verify();
        }
    }
}