namespace Banking.Logic;
public class BusinessAccount : Account
{
    public override bool IsAllowed(Transaction myTransaction)
    {
        return base.IsAllowed(myTransaction)
        && myTransaction.Amount <= 100_000
        && CurrentBalance + myTransaction.Amount >= -1_000_000
        && CurrentBalance + myTransaction.Amount <= 100_000_000;
    }
    
}