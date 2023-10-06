namespace Banking.Logic;

public class CheckingAccount : Account
{
    public override bool IsAllowed(Transaction myTransaction)
    {
        return base.IsAllowed(myTransaction)
        && myTransaction.Amount <= 10_000
        && CurrentBalance + myTransaction.Amount >= -10_000
        && CurrentBalance + myTransaction.Amount <= 10_000_000;
    }
}