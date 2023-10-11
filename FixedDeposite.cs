namespace Banking.Logic;

public class FixedDeposite : Account
{
    public DateOnly OpeningDate { get; set; }
    public DateOnly FixedUntil { get; set; }

    public override bool IsAllowed(Transaction transaction)
    {
        return base.IsAllowed(transaction)
        && CurrentBalance + transaction.Amount <= 10_000_000
        && CurrentBalance + transaction.Amount >= 0
        && ((DateOnly.FromDateTime(transaction.Timestamp) > FixedUntil && transaction.Amount < 0)
        || (DateOnly.FromDateTime(transaction.Timestamp) == OpeningDate && transaction.Amount > 0));

    }
}


