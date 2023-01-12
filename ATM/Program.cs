using ATM;

void printOptions()
{
    Console.WriteLine("Please choose from one of the following options...");
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. Withdraw");
    Console.WriteLine("3. Show Balance");
    Console.WriteLine("4. Exit");
}

void deposit(cardHolder currentUser)
{
    Console.WriteLine("How much would you like to deposit: ");
    double deposit = Double.Parse(Console.ReadLine());
    currentUser.setBalance(deposit + currentUser.getBalance());
    Console.WriteLine($"Thank you for your deposit. Your new balance is {currentUser.getBalance()}");
}

void withdraw(cardHolder currentUser)
{
    Console.WriteLine("How much would you like to withdraw: ");
    double withdrawal = Double.Parse(Console.ReadLine());
    //Check if user has enough money
    if (currentUser.getBalance() < withdrawal)
    {
        Console.WriteLine("Insufficient funds.");
    }
    else
    {
        currentUser.setBalance(currentUser.getBalance() - withdrawal);
        Console.WriteLine("Withdraw successful!");
    }
}

void balance(cardHolder currentUser)
{
    Console.WriteLine("Current balance: " + currentUser.getBalance());
}

List<cardHolder> cardHolders = new List<cardHolder>();
cardHolders.Add(new cardHolder("4539033356083421", 4761, "John", "Gabbana", 175.26));
cardHolders.Add(new cardHolder("4024007172491572", 2522, "Ashley", "Smith", 4002.35));
cardHolders.Add(new cardHolder("4916336331481187", 3833, "Freida", "Turkey", 23.56));
cardHolders.Add(new cardHolder("4475749689250025", 7204, "Andrew", "Tate", 100000000));
cardHolders.Add(new cardHolder("4553350764134583", 2355, "Tawp", "Gee", 250000.97));

// prompt user

Console.WriteLine("Welcome to simple ATM");
Console.WriteLine("Please enter your debit card: ");
String debitCardNum = "";
cardHolder currentUser;

while (true)
{
    try
    {
        debitCardNum = Console.ReadLine();
        //check against our db (list)
        currentUser = cardHolders.FirstOrDefault(a => a.getNum() == debitCardNum);
        if (currentUser != null) { break; }
        else { Console.WriteLine("Card not recognised, please try again."); }
    }
    catch
    {
        Console.WriteLine("Card not recognised, please try again.");
    }
}

Console.WriteLine("Please enter your pin: ");
int userPin = 0;

while (true)
{
    try
    {
        userPin = int.Parse(Console.ReadLine());
        if (currentUser.getPin() == userPin) { break; }
        else { Console.WriteLine("Incorrect Pin, please try again."); }
    }
    catch
    {
        Console.WriteLine("Incorrect Pin, please try again.");
    }
}

Console.WriteLine($"Welcome {currentUser.getFirstName()} {currentUser.getLastName()}");
int option = 0;
do
{
    printOptions();
    try
    {
        option = int.Parse(Console.ReadLine());
    }
    catch { }
    if(option == 1) { deposit(currentUser); }
    else if(option == 2) { withdraw(currentUser); }
    else if(option == 3) { balance(currentUser); }
    else if(option == 4) { break; }
    else { option = 0; }
}
while (option != 4);
Console.WriteLine("Thank you have a nice day");
