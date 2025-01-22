namespace WebApplication1.Constants
{
    public class MultiValues
    {

        public enum Txn_Type_Status
        {
            Debit = 0,
            Credit = 1
        }
        public enum Txn_Method_Status
        {
            UPI = 0,
            Cash = 1,
            Card = 2,
            OnlineBanking = 3
        }
        public enum Frequency_Status
        {
            Daily = 0,
            Weekly = 1,
            Monthly = 2,
            Quarterly = 3,
            Yearly = 4,
            Custom = 5
        }

        public enum UserRole
        {
            User = 0,
            SuperAdmin = 1
        }
    }
}
