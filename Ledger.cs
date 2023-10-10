using Banking.Logic;

var accountFileData = File.ReadAllLines(@"C:\Users\Kathi\Dokumente\cs-codes\PROO\005-Bank\Banking.CheckLedger\accounts.txt"); //args[0]
var transactionFileData = File.ReadAllLines(@"C:\Users\Kathi\Dokumente\cs-codes\PROO\005-Bank\Banking.CheckLedger\transactions.txt"); //args[1]

var accounts = new Account[accountFileData.Length];
var transactions = new Transaction[transactionFileData.Length];

for (int i = 0; i < accountFileData.Length - 1; i++)
{
    accounts[i] = CreateAnAccount(accountFileData[i + 1]);
}

for (int i = 0; i < transactionFileData.Length - 1; i++)
{
    transactions[i] = CreateATransaction(transactionFileData[i + 1]);
}

for (int i = 0; i < transactions.Length- 1; i++)
{
    for (int j = 0; j < accounts.Length -1; j++)
    {
        if (transactions[i].AccountNumber != accounts[j].AccountNumber)
        {
            continue;
        }
        if (!accounts[j].TryExecute(transactions[i]))
        {
            Console.WriteLine($"Transaction with description \"{transactions[i].Description}\" on \"{transactions[i].Timestamp}\" not allowed.");
        }
    }
}

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

