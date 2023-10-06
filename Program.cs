using Banking.Logic;

Console.Write("Type of account ([c]hecking, [b]usiness, [s]avings: )");
var type = Console.ReadLine()!;
Account myAccount = type switch
{
    "c" => new CheckingAccount(),
    "b" => new BusinessAccount(),
    "s" => new SavingsAccount(),
    _ => throw new ArgumentException("Invalid account type.")
};
Console.Write("Account number: ");
myAccount.AccountNumber= Console.ReadLine()!;
Console.Write("Account holder: ");
myAccount.AccountHolder = Console.ReadLine()!;
Console.Write("Current balance: ");
myAccount.CurrentBalance = decimal.Parse(Console.ReadLine()!);

var myTransaction = new Transaction();

Console.Write("Transaction Account number: ");
myTransaction.AccountNumber = Console.ReadLine()!;
Console.Write("Transaction Description: ");
myTransaction.Description = Console.ReadLine()!;
Console.Write("Transaction amount: ");
myTransaction.Amount = decimal.Parse(Console.ReadLine()!);
Console.Write("Transation timestamp: ");
myTransaction.Timestamp = DateTime.Parse(Console.ReadLine()!);


if (myAccount.TryExecute(myTransaction))
{
    Console.WriteLine($"Transaction executed successfully. The new current balance is {myAccount.CurrentBalance}€.");
}
else
{
    Console.WriteLine("Transaction not allowed.");
}



