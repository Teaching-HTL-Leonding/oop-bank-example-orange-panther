using Banking.Logic;

var accountFileData = File.ReadAllLines(args[0]);
var transactionFileData = File.ReadAllLines(args[1]);
var accounts = new Account[accountFileData.Length - 1];
var transactions = new Transaction[transactionFileData.Length - 1];

for (int i = 0; i < accountFileData.Length - 1; i++)
{
    accounts[i] = CreateAnAccount(accountFileData[i + 1]);
}
for (int i = 0; i < transactionFileData.Length - 1; i++)
{
    transactions[i] = CreateATransaction(transactionFileData[i + 1]);
}

foreach (var transaction in transactions)
{
    var matchingAccount = accounts.FirstOrDefault(account => account.AccountNumber == transaction.AccountNumber);

    if (matchingAccount == null)
    {
        continue;
    }
    else if (!matchingAccount.TryExecute(transaction))
    {
        Console.WriteLine($"Transaction with description \"{transaction.Description}\" on \"{transaction.Timestamp}\" not allowed.");
    }
}

// for (int i = 0; i < transactions.Length - 1; i++)
// {
//     for (int j = 0; j < accounts.Length - 1; j++)
//     {
//         if (transactions[i].AccountNumber != accounts[j].AccountNumber)
//         {
//             continue;
//         }
//         if (!accounts[j].TryExecute(transactions[i]))
//         {
//         }
//     }
// }

Account CreateAnAccount(string accountData)
{
    var data = accountData.Split(';');
    Account myAccount = data[0] switch
    {
        "c" => new CheckingAccount(),
        "b" => new BusinessAccount(),
        "s" => new SavingsAccount(),
        _ => throw new ArgumentException("Invalid account type.")
    };
    myAccount.AccountNumber = data[1];
    myAccount.AccountHolder = data[2];
    myAccount.CurrentBalance = decimal.Parse(data[3]);
    return myAccount;
}

Transaction CreateATransaction(string transactionData)
{
    var data = transactionData.Split(';');
    var myTransaction = new Transaction();
    myTransaction.AccountNumber = data[0];
    myTransaction.Description = data[1];
    myTransaction.Amount = decimal.Parse(data[2]);
    myTransaction.Timestamp = DateTime.Parse(data[3]);
    return myTransaction;
}

