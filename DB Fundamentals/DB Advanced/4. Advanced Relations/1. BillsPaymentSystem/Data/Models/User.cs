namespace P01_BillsPaymentSystem.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class User
    {
        public User()
        {
            this.PaymentMethods = new HashSet<PaymentMethod>();
        }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int PaymentMethodId { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"User: {this.FirstName} {this.LastName}")
                .AppendLine("Bank accounts:");

            List<BankAccount> bankAccounts = this.PaymentMethods
                .Where(x => x.Type == Enums.PaymentMethodType.BankAccount)
                .Select(x => x.BankAccount)
                .OrderBy(x => x.BankAccountId)
                .ToList();

            foreach (BankAccount bankAccount in bankAccounts)
            {
                sb.AppendLine(bankAccount.ToString());
            }
            sb.AppendLine("Credit cards:");

            List<CreditCard> creditCards = this.PaymentMethods
                .Where(x => x.Type == Enums.PaymentMethodType.CreditCard)
                .Select(x => x.CreditCard)
                .OrderBy(x => x.CreditCardId)
                .ToList();

            foreach (CreditCard creditCard in creditCards)
            {
                sb.AppendLine(creditCard.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
