namespace P01_BillsPaymentSystem
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using P01_BillsPaymentSystem.Data.Models.Enums;
    using System;
    using System.Linq;

    public class DatabaseOperations
    {
        public static void SeedData(BillsPaymentSystemContext db)
        {
            using (db)
            {
                User[] users = new User[]
                {
                    new User()
                    {
                        FirstName = "Pesho",
                        LastName = "Peshov",
                        Email = "peshoo@abv.bg",
                        Password = "pesho123",
                    },

                    new User()
                    {
                        FirstName = "Gosho",
                        LastName = "Goshov",
                        Email = "goshko@abv.bg",
                        Password = "gosh0"
                    },

                    new User()
                    {
                        FirstName = "Stamat",
                        LastName = "Stoyanov",
                        Email = "stambi@abv.bg",
                        Password = "softuni"
                    }
                };

                BankAccount[] bankAccounts = new BankAccount[]
                {
                    new BankAccount()
                    {
                        Balance = 100m,
                        BankName = "OBB",
                        SWIFTCode = "OCB",
                    },

                    new BankAccount()
                    {
                        Balance = 100000m,
                        BankName = "SG",
                        SWIFTCode = "AAAA"
                    },

                    new BankAccount()
                    {
                        Balance = 5823m,
                        BankName = "BNB",
                        SWIFTCode = "FSDG"
                    }
                };

                CreditCard[] creditCards = new CreditCard[]
                {
                    new CreditCard()
                    {
                        ExpirationDate = DateTime.Today.AddYears(3),
                        Limit = 4125215m,
                        MoneyOwed = 1m
                    },

                    new CreditCard()
                    {
                        ExpirationDate = DateTime.Today.AddYears(10),
                        Limit = 4321m,
                        MoneyOwed = 100m
                    },

                    new CreditCard()
                    {
                        ExpirationDate = DateTime.Today.AddYears(99),
                        Limit = 12233m,
                        MoneyOwed = 1000m
                    }
                };

                PaymentMethod[] paymentMethods = new PaymentMethod[]
                {
                    new PaymentMethod()
                    {
                        Type = PaymentMethodType.CreditCard,
                        User = users[0],
                        CreditCard = creditCards[0],
                    },

                    new PaymentMethod()
                    {
                        Type = PaymentMethodType.BankAccount,
                        User = users[1],
                        BankAccount = bankAccounts[1]
                    },

                    new PaymentMethod()
                    {
                        Type = PaymentMethodType.CreditCard,
                        User = users[0],
                        CreditCard = creditCards[2],
                    }
                };

                db.Users.AddRange(users);
                db.BankAccounts.AddRange(bankAccounts);
                db.CreditCards.AddRange(creditCards);
                db.PaymentMethods.AddRange(paymentMethods);

                db.SaveChanges();
            }
        }

        public static void PrintUserPaymentMethodsInfo(int userId, BillsPaymentSystemContext db)
        {
            User user = db.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            Console.WriteLine(user);
        }

        public static void PayBills(int userId, decimal amount, BillsPaymentSystemContext db)
        {
            using (db)
            {
                User user = db.Users
                    .Include(x => x.PaymentMethods)
                    .FirstOrDefault(x => x.UserId == userId);

                BankAccount[] bankAccounts = (from a in db.BankAccounts from b in user.PaymentMethods where a.BankAccountId == b.BankAccountId select a).ToArray();

                CreditCard[] creditCards = (from a in db.CreditCards from b in user.PaymentMethods where a.CreditCardId == b.CreditCardId select a).ToArray();

                try
                {
                    foreach (var ba in bankAccounts)
                    {
                        ba.Withdraw(amount);
                    }
                    foreach (var cc in creditCards)
                    {
                        cc.Withdraw(amount);
                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

