namespace P01_BillsPaymentSystem.Data.Models
{
    using System;
    using System.Text;

    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwed { get; set; }

        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        public DateTime ExpirationDate { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal money)
        {
            if (money > Limit)
            {
                throw new ArgumentException("Insufficient funds!");
            }
            this.MoneyOwed += money;
        }

        public void Deposit(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Value cannot be negative!");
            }
            this.MoneyOwed -= money;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"-- ID: {this.CreditCardId}")
                .AppendLine($"--- Limit: {this.Limit}")
                .AppendLine($"--- Money owed: {this.MoneyOwed}")
                .AppendLine($"--- Limit left: {this.LimitLeft}")
                .AppendLine($"--- Expiration Date: {this.ExpirationDate}");

            return sb.ToString();
        }
    }
}
