namespace P01_BillsPaymentSystem.Data.Models
{
    using System;
    using System.Text;

    public class BankAccount
    {
        public int BankAccountId { get; set; }

        public decimal Balance { get; set; }

        public string BankName { get; set; }

        public string SWIFTCode { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal money)
        {
            if (money > Balance)
            {
                throw new ArgumentException("Insufficient funds!");
            }
            this.Balance -= money;
        }

        public void Deposit(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Value cannot be negative !");
            }
            this.Balance += money;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"-- ID: {this.BankAccountId}")
                .AppendLine($"--- Balance: {this.Balance}")
                .AppendLine($"--- Bank: {this.BankName}")
                .AppendLine($"--- SWIFT: {this.SWIFTCode}");

            return sb.ToString();
        }
    }
}
