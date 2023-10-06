namespace Banking.Logic;
public class SavingsAccount : Account
{
    public override bool IsAllowed(Transaction myTransaction)
    {
        return base.IsAllowed(myTransaction)
        && CurrentBalance + myTransaction.Amount >= 0
        && CurrentBalance + myTransaction.Amount <= 100_000_000;
    }
    
}