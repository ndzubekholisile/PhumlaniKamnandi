// ========== RoomAccount ==========

namespace PhumlaniKamnandi.Business
{
    public class RoomAccount
    {
        public int AccountID { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; }   // settled | outstanding

        public RoomAccount() { }

        public RoomAccount(decimal balance, string status)
        {
            Balance = balance;
            Status = status;
        }
    }
}