namespace Banking.Logic;

public abstract class Account
{
    public string AccountNumber { get; set; } = "";
    public string AccountHolder { get; set; } = "";
    public decimal CurrentBalance { get; set; }

    // public abstract bool IsAllowed(Transaction transaction); (abstrakte Methode vs virtuelle Methode)
    public virtual bool IsAllowed(Transaction transaction) {return AccountNumber == transaction.AccountNumber; }

    public bool TryExecute(Transaction MyTransaction)
    {
        if (IsAllowed(MyTransaction))
        {
            CurrentBalance += MyTransaction.Amount;
            return true;
        }
        return false;
    }
}
