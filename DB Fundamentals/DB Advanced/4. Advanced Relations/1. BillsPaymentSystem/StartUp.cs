namespace P01_BillsPaymentSystem
{
    using P01_BillsPaymentSystem.Data;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using (BillsPaymentSystemContext db = new BillsPaymentSystemContext())
            {
                //DatabaseOperations.SeedData(db);

                //Console.WriteLine("User Id: ");
                //int infoUserId = int.Parse(Console.ReadLine());
                //DatabaseOperations.PrintUserPaymentMethodsInfo(infoUserId, db);

                //Console.WriteLine("User Id: ");
                //int withdrawUserId = int.Parse(Console.ReadLine());
                //Console.WriteLine("Enter amount to withdraw");
                //decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                //DatabaseOperations.PayBills(withdrawUserId, withdrawAmount, db);
            }
        }
    }
}
