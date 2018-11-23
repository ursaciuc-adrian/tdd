using System;

namespace TDD_Mock
{
    public interface ITransactionProcessorService
    {
    }

    public class TransactionProcessorService : ITransactionProcessorService
    {
        private readonly IEwalletService _ewalletService;
        private readonly IPrintingService _printer;

        public TransactionProcessorService(IEwalletService ewalletService, IPrintingService printer)
        {
            _ewalletService = ewalletService;
            _printer = printer;
        }
        
        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new DepositIsNegativeException();
            }
            
            _ewalletService.Deposit(amount);
        }

        public void PrintHistory()
        {
            _printer.PrintHeader();
            _printer.Print(DateTime.Now, 200, 200);
        }
    }

    public interface IPrintingService
    {
        void PrintHeader();
        void Print(DateTime date, int transactionAmount, int accountBallance);
    }

    
}