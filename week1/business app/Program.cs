using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace business_app
{
    internal class Program
    {
        static int Main(string[] args)
        {
            string loginoption="";
            int arraysize = 200, usercount = 0;
            string[] user = new string[arraysize];
            string[] password = new string[arraysize];
            string[] role = new string[arraysize];
            string[] convertuser = new string[arraysize];
            string signinname = "", signinpassword = "";
            string role1 = "0";
            string adminoption = "";
            string staffoption = "";
            string customeroption = "";
            int customercount = 0;
            string[] age = new string[arraysize];
            string[] customername = new string[arraysize];
            string[] phonenumber = new string[arraysize];
            string[] cnic = new string[arraysize];
            string[] address = new string[arraysize];
            string[] money = new string[arraysize];
            string[] customerloan = new string[arraysize];
            string[] convertcustomername = new string[arraysize];
            string customname = "", customcnic = "";
            string option = "";
            string name1 = "",cnic1="";
            string newuserpassword;
            Console.SetWindowSize(170, 44);
            printheader();
            printsymbol();
            movesymbol();
            loginoption = loginmenu(loginoption);
            LoadData(user, convertuser, password, role,ref usercount);
            LoadDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan,ref customercount);
            while (true)
            {
                if (loginoption == "1")
                {
                    Console.Clear();
                    signupheader();
                    while (true)
                    {
                        usernameinstructions();
                        user[usercount] = Username(user, usercount);
                        convertuser[usercount] = Convert(user[usercount]);

                        if (IsValidUsername(convertuser, usercount))
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(5, 16);
                            Console.WriteLine("Already existed. Try again.");
                            Console.ReadKey();
                            Console.SetCursorPosition(22, 15);
                            Console.WriteLine("                                                          ");
                            Console.SetCursorPosition(5, 16);
                            Console.WriteLine("                          ");
                        }
                    }
                    RemoveInstructions();
                    PasswordInstructions();
                    password[usercount] = PasswordEnter(password, usercount);
                    RemoveInstructions();
                    RoleInstructions();
                    role[usercount] = EnterRole(role, usercount);
                    role[usercount] = Convert(role[usercount]);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine();
                    Console.WriteLine("Your account has been opened successfully. Press any key to continue.");
                    Console.ReadKey();
                    usercount++;
                    WriteData(user, convertuser, password, role, usercount);
                    loginoption = loginmenu(loginoption);
                }
                else if (loginoption == "2")
                {
                    SigninHeader();
                    signinname = Name();
                    signinpassword = Pass();
                    role1 = IdentifyRole(signinname, signinpassword, user, convertuser, password, role, arraysize);
                    if (role1 == "0")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You have no such account. Please try again.");
                        Console.Write("Press any key to continue: ");
                        Console.ReadKey();
                        loginoption = loginmenu(loginoption);
                    }
                    else
                    {
                        if (role1 == "admin")
                        {
                            while (true)
                            {
                                AdminHeader();
                                adminoption = AdminMenu(adminoption);
                                if (adminoption == "1")
                                {
                                    ShowAccountsHeader();
                                    ShowAccounts(user, password, role, usercount);
                                }
                                else if (adminoption == "2")
                                {
                                    Console.Clear();
                                    AddLoginAccountHeader();
                                    while (true)
                                    {
                                        usernameinstructions();
                                        user[usercount] = Username(user, usercount);
                                        convertuser[usercount] = Convert(user[usercount]);
                                        if (IsValidUsername(convertuser, usercount))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.SetCursorPosition(5, 16);
                                            Console.WriteLine("Already existed. Try again.");
                                            Console.ReadKey();
                                            Console.SetCursorPosition(22, 15);
                                            Console.WriteLine("                                                    ");
                                            Console.SetCursorPosition(5, 16);
                                            Console.WriteLine("                          ");
                                        }
                                    }
                                    RemoveInstructions();
                                    PasswordInstructions();
                                    password[usercount] = PasswordEnter(password, usercount);
                                    RemoveInstructions();
                                    RoleInstructions();
                                    role[usercount] = EnterRole(role, usercount);
                                    role[usercount] = Convert(role[usercount]);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine();
                                    Console.WriteLine("Your account has been opened successfully. Press any key to continue.");
                                    Console.ReadKey();
                                    usercount++;
                                    WriteData(user, convertuser, password, role, usercount);
                                }
                                else if (adminoption == "3")
                                {
                                    Console.Clear();
                                    RemoveLoginAccountHeader();
                                    signinname = Name();
                                    signinpassword = Pass();
                                    RemoveAccount(signinname, signinpassword, user, convertuser, password, role,ref usercount);
                                    WriteData(user, convertuser, password, role, usercount);
                                }
                                else if (adminoption == "4")
                                {
                                    Console.Clear();
                                    AdminAccountHeader();
                                    AdminAccounts(user, password, role, usercount);
                                }
                                else if (adminoption == "5")
                                {
                                    Console.Clear();
                                    StaffAccountHeader();
                                    StaffAccounts(user, password, role, usercount);
                                }
                                else if (adminoption == "6")
                                {
                                    Console.Clear();
                                    CustomerAccountHeader();
                                    CustomerAccounts(user, password, role, usercount);
                                }
                                else if (adminoption == "7")
                                {
                                    Console.Clear();
                                    ModifyPasswordHeader();
                                    Console.SetCursorPosition(5, 14);
                                    signinname = Name();
                                    Console.SetCursorPosition(5, 15);
                                    signinpassword = Pass();
                                    newuserpassword = ModifyLoginAccountPassword(signinname, signinpassword, convertuser, password, usercount);
                                    WriteData(user, convertuser, password, role, usercount);
                                }
                                else if (adminoption == "8")
                                {
                                    Console.Clear();
                                    ModifyName();
                                    Console.SetCursorPosition(5, 14);
                                    signinname = Name();
                                    Console.SetCursorPosition(5, 15);
                                    signinpassword = Pass();
                                    ModifyLoginAccountName(signinname, signinpassword, user, convertuser, password, usercount);
                                    WriteData(user, convertuser, password, role, usercount);
                                }
                                else if (adminoption == "9")
                                {
                                    Console.Clear();
                                    loginoption = loginmenu(loginoption);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You have entered the wrong option.");
                                    Console.WriteLine("Try Again.");
                                    Console.ReadKey();
                                }
                            }
                        }
                        if (role1 == "staff")
                        {
                            while (true)
                            {
                                StaffHeader();
                                staffoption = StaffMenu(staffoption);
                                if (staffoption == "1")
                                {
                                    Console.Clear();
                                    CustomerListHeader();
                                    ShowCustomerList(customername, age, cnic, money, address, phonenumber, customercount);
                                }
                                else if (staffoption == "2")
                                {
                                    while (true)
                                    {
                                        Console.Clear();
                                        ModifyAccountHeader();
                                        option = ModifyAccountMenu(option);
                                        if (option == "1")
                                        {
                                            AccountNameInstructions();
                                            name1 = ChangeName(name1);
                                            cnic1 = ChangeCnic(cnic1);
                                            ModifyName(name1, cnic1, cnic, customername, convertcustomername, customercount);
                                            WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                        }
                                        else if (option == "2")
                                        {
                                            CNICInstructions();
                                            name1 = ChangeName(name1);
                                            cnic1 = ChangeCnic(cnic1);
                                            ModifyCnic(name1, cnic1, cnic, convertcustomername, customercount);
                                            WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                        }
                                        else if (option == "3")
                                        {
                                            PhoneNumberInstructions();
                                            name1 = ChangeName(name1);
                                            cnic1 = ChangeCnic(cnic1);
                                            ModifyPhoneNumber(name1, cnic1, cnic, convertcustomername, phonenumber, customercount);
                                            WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                        }
                                        else if (option == "4")
                                        {
                                            AddressInstructions();
                                            name1 = ChangeName(name1);
                                            cnic1 = ChangeCnic(cnic1);
                                            ModifyAddress(name1, cnic1, cnic, convertcustomername, address, customercount);
                                            WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                        }
                                        else if (option == "5")
                                        {
                                            MoneyInstructions();
                                            name1 = ChangeName(name1);
                                            cnic1 = ChangeCnic(cnic1);
                                            ModifyMoney(name1, cnic1, cnic, convertcustomername, money, customercount);
                                            WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                        }
                                        else if (option == "6")
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have entered the wrong option.");
                                            Console.WriteLine("Try Again.");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                                else if (staffoption == "3")
                                {
                                    Console.Clear();
                                    CheckStatusHeader();
                                    customname = CName(customname);
                                    customcnic = CCNIC(customcnic);
                                    CheckStatus(customname, customcnic, customername, convertcustomername, age, cnic, money, address, phonenumber, arraysize, customercount);
                                }
                                else if (staffoption == "4")
                                {
                                    int a = 80, b = 17;
                                    int tmoney;
                                    Console.Clear();
                                    TotalMoneyHeader();
                                    tmoney = TotalMoney(money, customercount);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.SetCursorPosition(a, b);
                                    Console.WriteLine("##################################################################");
                                    Console.SetCursorPosition(a, b + 1);
                                    Console.WriteLine("#                                                                #");
                                    Console.SetCursorPosition(a, b + 2);
                                    Console.WriteLine($"#     Total money of all customers is PKR {tmoney}.                        #");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.SetCursorPosition(a + 42, b + 2);
                                    Console.WriteLine(tmoney + ".");
                                    Console.SetCursorPosition(a, b + 3);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("#                                                                #");
                                    Console.SetCursorPosition(a, b + 4);
                                    Console.WriteLine("##################################################################");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                }
                                else if (staffoption == "5")
                                {
                                    Console.Clear();
                                    ViewLoanHeader();
                                    ViewLoan(customername, customerloan, customercount);
                                }
                                else if (staffoption == "6")
                                {
                                    Console.Clear();
                                    DeleteAccount();
                                    customname = CName(customname);
                                    customcnic = CCNIC(customcnic);
                                    CloseAccount(age, customname, customcnic, customername, convertcustomername, cnic, money, phonenumber, customerloan, address,ref customercount);
                                    WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                }
                                else if (staffoption == "7")
                                {
                                    Console.Clear();
                                    loginoption = loginmenu(loginoption);
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Wrong Option. Press any key to try again");
                                    Console.WriteLine();
                                    Console.ReadKey();
                                }
                            }
                        }
                        if (role1 == "customer")
                        {
                            while (true)
                            {
                                CustomerHeader();
                                customeroption = CustomerMenu(customeroption);
                                if (customeroption == "1")
                                {
                                    Console.Clear();
                                    NewAccountHeader();
                                    AgeInstructions();
                                    age[customercount] = AgeOfCustomer(age, customercount);
                                    RemoveInstructions();
                                    while (true)
                                    {
                                        AccountNameInstructions();
                                        customername[customercount] = NameOfCustomer(customername, customercount);
                                        convertcustomername[customercount] = Convert(customername[customercount]);
                                        if (IsValidCustomerName(convertcustomername, customercount))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.SetCursorPosition(5, 19);
                                            Console.WriteLine("Already existed. Try again.");
                                            Console.ReadKey();
                                            Console.SetCursorPosition(30, 18);
                                            Console.WriteLine("                                                    ");
                                            Console.SetCursorPosition(5, 19);
                                            Console.WriteLine("                          ");
                                        }
                                    }
                                    RemoveInstructions();
                                    PhoneNumberInstructions();
                                    phonenumber[customercount] = PhoneNumberOfCustomer(phonenumber, customercount);
                                    RemoveInstructions();
                                    CNICInstructions();
                                    cnic[customercount] = CNICOfCustomer(cnic, customercount);
                                    RemoveInstructions();
                                    AddressInstructions();
                                    address[customercount] = AddressOfCustomer(address, customercount);
                                    RemoveInstructions();
                                    MoneyInstructions();
                                    money[customercount] = MoneyOfCustomer(money, customercount);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine();
                                    Console.WriteLine("Your account has been opened successfully. Press any key to continue.");
                                    Console.ReadKey();
                                    customercount++;
                                    WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                    Console.ReadKey();
                                }
                                else if (customeroption == "2")
                                {
                                    Console.Clear();
                                    DepositMoneyHeader();
                                    customname = CName(customname);
                                    customcnic = CCNIC(customcnic);
                                    DepositMoney(customname, customcnic, convertcustomername, cnic, money, customercount);
                                    WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                }
                                else if (customeroption == "3")
                                {
                                    Console.Clear();
                                    WithdrawMoneyHeader();
                                    customname = CName(customname);
                                    customcnic = CCNIC(customcnic);
                                    WithdrawMoney(customname, customcnic, convertcustomername, cnic, money, arraysize);
                                    WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                }
                                else if (customeroption == "4")
                                {
                                    Console.Clear();
                                    BalanceEnquiryHeader();
                                    customname = CName(customname);
                                    customcnic = CCNIC(customcnic);
                                    BalanceEnquiry(customname, customcnic, convertcustomername, cnic, money, arraysize);
                                }
                                else if (customeroption == "5")
                                {
                                    Console.Clear();
                                    CloseAccountHeader();
                                    customname = CName(customname);
                                    customcnic = CCNIC(customcnic);
                                    CloseAccount(age, customname, customcnic, customername, convertcustomername, cnic, money, phonenumber, customerloan, address,ref customercount);
                                    WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                }
                                else if (customeroption == "6")
                                {
                                    Console.Clear();
                                    CheckInformationHeader();
                                    customname = CName(customname);
                                    customcnic = CCNIC(customcnic);
                                    CheckInformation(customname, customcnic, customername, convertcustomername, age, cnic, money, address, phonenumber, arraysize, customercount);
                                }
                                else if (customeroption == "7")
                                {
                                    Console.Clear();
                                    LoanHeader();
                                    Console.SetCursorPosition(5, 14);
                                    customname = CName(customname);
                                    Console.SetCursorPosition(5, 15);
                                    customcnic = CCNIC(customcnic);
                                    LoanInstructions();
                                    Loan(customname, customcnic, convertcustomername, cnic, money, customerloan, customercount);
                                    WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                                }
                                else if (customeroption == "8")
                                {
                                    // Assuming loginmenu returns a value that is assigned to loginoption
                                    loginoption = loginmenu(loginoption);
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("   Wrong Option. Press any key to try again");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                }
                else if (loginoption == "3")
                {
                    WriteData(user, convertuser, password, role, usercount);
                    WriteDataCustomer(age, customername, convertcustomername, phonenumber, cnic, address, money, customerloan, customercount);
                    ExitPage();
                    return 0;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("   Wrong Option. Press any key to try again");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.ReadKey();
                    loginoption = loginmenu(loginoption); // Assuming LoginMenu returns a value that is assigned to loginoption
                }
            }

                        
        }
        static void printheader()
        {
            Console.Clear();
            int a = 1, b = 6;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(a, b);
            Console.Write("______  ___   _   _  _   __        ___  ___  ___   _   _   ___  _____  ________  ___ _____ _   _ _____");
            Thread.Sleep(70);
            Console.SetCursorPosition(a,7);
            Console.Write("| ___ \\/ _ \\ | \\ | || | / /        |  \\/  | / _ \\ | \\ | | / _ \\|  __ \\|  ___|  \\/  ||  ___| \\ | |_   _|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a,8);
            Console.Write("| |_/ / /_\\ \\|  \\| || |/ /         | .  . |/ /_\\ \\|  \\| |/ /_\\ \\ |  \\/| |__ | .  . || |__ |  \\| | | |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a,9);
            Console.Write("| ___ \\  _  || . ` ||    \\         | |\\/| ||  _  || . ` ||  _  | | __ |  __|| |\\/| ||  __|| . ` | | |");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(a,10);
            Console.Write("| |_/ / | | || |\\  || |\\  \\        | |  | || | | || |\\  || | | | |_\\ \\| |___| |  | || |___| |\\  | | |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a,11);
            Console.Write("\\____/\\_| |_/\\_| \\_/\\_| \\_/        \\_|  |_/\\_| |_/\\_| \\_/\\_| |_/\\____/\\____/\\_|  |_/\\____/\\_| \\_/ \\_/");
            Thread.Sleep(70);
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.SetCursorPosition(90, 16);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O you who believe!");
            Console.SetCursorPosition(90, 17);
            Console.Write("Do not consume usury, doubled and multiplied,");
            Console.SetCursorPosition(90, 18);
            Console.Write("and keep your duty to ALLAH, that you may be successful");
            Console.SetCursorPosition(90, 19);
            Console.Write("                                          (03;130)");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(90, 24);
            Console.Write("Press any key to continue.............");
            Console.ReadKey();
            Console.SetCursorPosition(90, 26);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Loading.......");
            Thread.Sleep(370);
            Console.Write(".........");
            Thread.Sleep(370);
            Console.Write(".........");
            Thread.Sleep(370);
            Console.Write(".........");
        }

        static void printsymbol()
        {
            int c = 140, d = 4;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(c, d);
            Console.Write("    $$\\    ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 1);
            Console.Write(" $$$$$$\\  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 2);
            Console.Write("$$  __$$\\ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 3);
            Console.Write("$$ /  \\__|");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 4);
            Console.Write("\\$$$$$$\\  ");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(c, d + 5);
            Console.Write(" \\___ $$\\ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 6);
            Console.Write("$$\\  \\$$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 7);
            Console.Write("\\$$$$$$  |");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 8);
            Console.Write(" \\_$$  _/ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 9);
            Console.Write("   \\ _/   ");
            Thread.Sleep(70);
        }

        static void removesymbol()
        {
            int c = 140, d = 4;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(c, d);
            Console.Write("           ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 1);
            Console.Write("           ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 2);
            Console.Write("           ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 3);
            Console.Write("           ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 4);
            Console.Write("           ");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(c, d + 5);
            Console.Write("           ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 6);
            Console.Write("           ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 7);
            Console.Write("           ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 8);
            Console.Write("           ");
            Thread.Sleep(70);
            Console.SetCursorPosition(c, d + 9);
            Console.Write("           ");
            Thread.Sleep(70);
        }

        static void movesymbol()
        {
            removesymbol();
            Thread.Sleep(100);
            printsymbol();
        }

        static void loginmenuheader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            int d = 2;
            Console.SetCursorPosition(80, d);
            Console.Write("  _                 _              __  __  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(80, d + 1);
            Console.Write(" | |               (_)            |  \\/  |     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(80, d + 2);
            Console.Write(" | |     ___   __ _ _ _ __        | \\  / | ___ _ __  _   _ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(80, d + 3);
            Console.Write(" | |    / _ \\ / _` | | '_ \\       | |\\/| |/ _ \\ '_ \\| | | |");
            Thread.Sleep(70);
            Console.SetCursorPosition(80, d + 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" | |___| (_) | (_| | | | | |      | |  | |  __/ | | | |_| |");
            Thread.Sleep(70);
            Console.SetCursorPosition(80, d + 5);
            Console.Write(" |______\\___/ \\__, |_|_| |_|      |_|  |_|\\___|_| |_|\\__,_|");
            Thread.Sleep(70);
            Console.SetCursorPosition(80, d + 6);
            Console.Write("               __/ |                                       ");
            Thread.Sleep(70);
            Console.SetCursorPosition(80, d + 7);
            Console.Write("              |___/                                        ");
            Thread.Sleep(70);
        }

        static string loginmenu(string loginoption)
        {
            Console.Clear();
            loginmenuheader();
            Console.ForegroundColor = ConsoleColor.Yellow;
            int d = 12;
            Console.SetCursorPosition(100, d);
            Console.Write("$$$$$$$$$$$$$$$$$$$$$$$$$");
            Thread.Sleep(70);
            Console.SetCursorPosition(100, d + 1);
            Console.Write("   1. Sign up");
            Thread.Sleep(70);
            Console.SetCursorPosition(100, d + 2);
            Console.Write("   2. Sign in");
            Thread.Sleep(70);
            Console.SetCursorPosition(100, d + 3);
            Console.Write("   3. Exit");
            Thread.Sleep(70);
            Console.SetCursorPosition(100, d + 4);
            Console.WriteLine();
            Thread.Sleep(70);
            Console.SetCursorPosition(100, d + 5);
            Console.Write("$$$$$$$$$$$$$$$$$$$$$$$$");
            Thread.Sleep(70);
            Console.SetCursorPosition(100, d + 6);
            Console.WriteLine();
            Thread.Sleep(70);
            Console.SetCursorPosition(100, d + 7);
            Console.WriteLine();
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   Enter your option: ");
            Console.ForegroundColor = ConsoleColor.White;
            loginoption = Console.ReadLine();
            Console.WriteLine();
            return loginoption;
        }

        static void signupheader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            int a = 80, b = 2;
            Console.SetCursorPosition(a, b);
            Console.Write(" $$$$$$\\  $$$$$$\\  $$$$$$\\  $$\\   $$\\       $$\\   $$\\ $$$$$$$\\  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.Write("$$  __$$\\ \\_$$  _|$$  __$$\\ $$$\\  $$ |      $$ |  $$ |$$  __$$\\ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.Write("$$ /  \\__|  $$ |  $$ /  \\__|$$$$\\ $$ |      $$ |  $$ |$$ |  $$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.Write("\\$$$$$$\\    $$ |  $$ |$$$$\\ $$ $$\\$$ |      $$ |  $$ |$$$$$$$  |");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b + 4);
            Console.Write(" \\____$$\\   $$ |  $$ |\\_$$ |$$ \\$$$$ |      $$ |  $$ |$$  ____/ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.Write("$$\\   $$ |  $$ |  $$ |  $$ |$$ |\\$$$ |      $$ |  $$ |$$ |      ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.Write("\\$$$$$$  |$$$$$$\\ \\$$$$$$  |$$ | \\$$ |      \\$$$$$$  |$$ |      ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.Write(" \\______/ \\______| \\______/ \\__|  \\__|       \\______/ \\__|   ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 8);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void usernameinstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-:INSTRUCTIONS:-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(120, 18);
            Console.Write("o Blank spaces and special   ");
            Console.SetCursorPosition(120, 19);
            Console.Write("  characters are not allowed.");
            Console.SetCursorPosition(120, 20);
            Console.Write("o Username must start with an");
            Console.SetCursorPosition(120, 21);
            Console.Write("  alphabet.                  ");
            Console.SetCursorPosition(120, 22);
            Console.Write("o Repetition in username is  ");
            Console.SetCursorPosition(120, 23);
            Console.Write("  not allowed.               ");
            Console.SetCursorPosition(120, 24);
            Console.Write("o Username  is  not  case   ");
            Console.SetCursorPosition(120, 25);
            Console.Write("  sensitive.                 ");
            Console.SetCursorPosition(120, 26);
            Console.Write("o Minimum 4 and maximum  12  ");
            Console.SetCursorPosition(120, 27);
            Console.Write("  characters are allowed.    ");
        }
        static bool CheckUserLength(int length)
        {
            return length > 3 && length < 13;
        }

        static int CheckUsername(string user)
        {
            int x = 0;
            string newname = user;
            char asc = newname[0];

            if ((asc >= 65 && asc <= 90) || (asc >= 97 && asc <= 122))
            {
                char ascii;
                int asciiCode;
                int length = newname.Length;
                for (int y = 0;y<=length ; y++)
                {
                    asciiCode = newname[y];
                    ascii = (char)asciiCode;

                    if ((ascii >= 48 && ascii <= 57) || (ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122))
                    {
                        x = 0;
                    }
                    else
                    {
                        x++;
                    }
                }
            }
            else
            {
                x++;
            }

            return x;
        }

        static string Username(string[] user, int userCount)
        {
            int x;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(5, 15);
            Console.Write("Enter username: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(22, 15);
            user[userCount] = Console.ReadLine();
            x = CheckUsername(user[userCount]);

            if (x >= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 16);
                Console.Write("Not valid. Try again.");
                Console.ReadKey();
                Console.SetCursorPosition(22, 15);
                Console.WriteLine("                                                                          ");
                Console.SetCursorPosition(5, 16);
                Console.Write("                    ");
                user[userCount] = Username(user, userCount);
                return user[userCount];
            }

            int length = user[userCount].Length;

            if (CheckUserLength(length))
            {
                return user[userCount];
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 16);
                Console.Write("Not valid. Try again.");
                Console.ReadKey();
                Console.SetCursorPosition(22, 15);
                Console.WriteLine("                                                    ");
                Console.SetCursorPosition(5, 16);
                Console.Write("                          ");
                user[userCount] = Username(user, userCount);
                return user[userCount];
            }
        }

        static void PasswordInstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-:INSTRUCTIONS:-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(120, 18);
            Console.Write("o Password must be of minimum");
            Console.SetCursorPosition(120, 19);
            Console.Write("  eight  and  maximum  ten   ");
            Console.SetCursorPosition(120, 20);
            Console.Write("  characters.                ");
            Console.SetCursorPosition(120, 21);
            Console.Write("o Any character can be used  ");
            Console.SetCursorPosition(120, 22);
            Console.Write("  password but blank spaces  ");
            Console.SetCursorPosition(120, 23);
            Console.Write("  are not allowed.           ");
            Console.SetCursorPosition(120, 24);
            Console.Write("o Password  is  also  case   ");
            Console.SetCursorPosition(120, 25);
            Console.Write("  sensitive.                 ");
        }

        static string PasswordEnter(string[] password, int userCount)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.SetCursorPosition(5, 17);
            Console.Write("Enter password: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(23, 17);
            password[userCount] = Console.ReadLine();
            int length = password[userCount].Length;

            if (CheckPassword(length))
            {
                if (CheckPasswordValid(password[userCount]))
                {
                    return password[userCount];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(5, 18);
                    Console.Write("Not valid. Try again.");
                    Console.ReadKey();
                    Console.SetCursorPosition(23, 17);
                    Console.WriteLine("                                                    ");
                    Console.SetCursorPosition(5, 18);
                    Console.Write("                          ");
                    password[userCount] = PasswordEnter(password, userCount);
                    return password[userCount];
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 18);
                Console.Write("Not valid. Try again.");
                Console.ReadKey();
                Console.SetCursorPosition(23, 17);
                Console.WriteLine("                                                    ");
                Console.SetCursorPosition(5, 18);
                Console.Write("                          ");
                password[userCount] = PasswordEnter(password, userCount);
                return password[userCount];
            }
        }

        static bool CheckPasswordValid(string password)
        {
            string newname = password;
            char ascii;
            int asciiCode;

            for (int y = 0; newname[y] != '\0'; y++)
            {
                asciiCode = newname[y];
                ascii = (char)asciiCode;

                if (ascii == 32)
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckPassword(int length)
        {
            return length >= 8 && length <= 10;
        }

        static bool IsValidUsername(string[] convertUser, int userCount)
        {
            int k = 0;
            if (userCount > 0)
            {
                for (int y = 0; y < userCount; y++)
                {
                    if (convertUser[userCount] == convertUser[y])
                    {
                        k++;
                    }
                }
            }

            if (k == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void RoleInstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-:INSTRUCTIONS:-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(120, 18);
            Console.Write("o Role is not case sensitive.");
        }

        static void RemoveInstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 18; i <= 27; i++)
            {
                Console.SetCursorPosition(120, i);
                Console.Write("                             ");
            }
        }

        static string EnterRole(string[] role, int userCount)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(5, 19);
            Console.Write("Enter role(admin or customer or staff): ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(46, 19);
            string roleInput = Console.ReadLine();
            role[userCount] = roleInput;
            string roleCheck = Convert(role[userCount]);
            if (CheckRole(roleCheck))
            {
                return role[userCount];
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 20);
                Console.WriteLine("Not valid. Try again.");
                Console.ReadKey();
                Console.SetCursorPosition(46, 19);
                Console.WriteLine("                                                    ");
                Console.SetCursorPosition(5, 20);
                Console.Write("                          ");
                role[userCount] = EnterRole(role, userCount);
                return role[userCount];
            }
        }

        static bool CheckRole(string roleCheck)
        {
            return roleCheck == "admin" || roleCheck == "customer" || roleCheck == "staff";
        }

        static void SigninHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            int a = 80, b = 2;
            Console.SetCursorPosition(a, b);
            Console.WriteLine(" $$$$$$\\  $$$$$$\\  $$$$$$\\  $$\\   $$\\       $$$$$$\\ $$\\   $$\\ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("$$  __$$\\ \\_$$  _|$$  __$$\\ $$$\\  $$ |      \\_$$  _|$$$\\  $$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("$$ /  \\__|  $$ |  $$ /  \\__|$$$$\\ $$ |        $$ |  $$$$\\ $$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("\\$$$$$$\\    $$ |  $$ |$$$$\\ $$ $$\\$$ |        $$ |  $$ $$\\$$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" \\____$$\\   $$ |  $$ |\\_$$ |$$ \\$$$$ |        $$ |  $$ \\$$$$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$$\\   $$ |  $$ |  $$ |  $$ |$$ |\\$$$ |        $$ |  $$ |\\$$$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\\$$$$$$  |$$$$$$\\ \\$$$$$$  |$$ | \\$$ |      $$$$$$\\ $$ | \\$$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine(" \\______/ \\______| \\______/ \\__|  \\__|      \\______|\\__|  \\__|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 8);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static string Name()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter username: ");
            Console.ForegroundColor = ConsoleColor.White;
            string username = Console.ReadLine();
            // Assuming convert method is used for conversion
            username = Convert(username);
            return username;
        }

        static string Pass()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter password: ");
            Console.ForegroundColor = ConsoleColor.White;
            string password = Console.ReadLine();
            return password;
        }

        static string IdentifyRole(string signinName, string signinPassword, string[] user, string[] convertUser, string[] password, string[] role, int arraySize)
        {
            for (int x = 0; x < arraySize; x++)
            {
                if (signinName == convertUser[x] && signinPassword == password[x])
                {
                    Console.WriteLine(role[x]);
                    return role[x];
                }
            }
            return "0";
        }

        static void AdminHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            int a = 50, b = 2;
            Console.SetCursorPosition(a, b);
            Console.WriteLine(" $$$$$$\\  $$$$$$$\\  $$\\      $$\\ $$$$$$\\ $$\\   $$\\       $$\\      $$\\ $$$$$$$$\\ $$\\   $$\\ $$\\   $$\\ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("$$  __$$\\ $$  __$$\\ $$$\\    $$$ |\\_$$  _|$$$\\  $$ |      $$$\\    $$$ |$$  _____|$$$\\  $$ |$$ |  $$ | ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("$$ /  $$ |$$ |  $$ |$$$$\\  $$$$ |  $$ |  $$$$\\ $$ |      $$$$\\  $$$$ |$$ |      $$$$\\ $$ |$$ |  $$ | ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("$$$$$$$$ |$$ |  $$ |$$\\$$\\$$ $$ |  $$ |  $$ $$\\$$ |      $$\\$$\\$$ $$ |$$$$$\\    $$ $$\\$$ |$$ |  $$ | ");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("$$  __$$ |$$ |  $$ |$$ \\$$$  $$ |  $$ |  $$ \\$$$$ |      $$ \\$$$  $$ |$$  __|   $$ \\$$$$ |$$ |  $$ | ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$$ |  $$ |$$ |  $$ |$$ |\\$  /$$ |  $$ |  $$ |\\$$$ |      $$ |\\$  /$$ |$$ |      $$ |\\$$$ |$$ |  $$ | ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("$$ |  $$ |$$$$$$$  |$$ | \\_/ $$ |$$$$$$\\ $$ | \\$$ |      $$ | \\_/ $$ |$$$$$$$$\\ $$ | \\$$ |\\$$$$$$  | ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("\\__|  \\__|\\_______/ \\__|     \\__|\\______|\\__|  \\__|      \\__|     \\__|\\________|\\__|  \\__| \\______/  ");
            Thread.Sleep(70);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static string AdminMenu(string adminOption)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("          -::MAIN MENU::-");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("       1. SHOW ALL ACCOUNTS");
            Thread.Sleep(60);
            Console.WriteLine("       2. ADD AN ACCOUNT");
            Thread.Sleep(60);
            Console.WriteLine("       3. REMOVE ACCOUNT");
            Thread.Sleep(60);
            Console.WriteLine("       4. SHOW ADMIN ACCOUNTS");
            Thread.Sleep(60);
            Console.WriteLine("       5. SHOW STAFF ACCOUNTS");
            Thread.Sleep(60);
            Console.WriteLine("       6. SHOW CUSTOMER ACCOUNTS");
            Thread.Sleep(60);
            Console.WriteLine("       7. MODIFY LOGINACCOUNT PASSWORD");
            Thread.Sleep(60);
            Console.WriteLine("       8. MODIFY LOGINACCOUNT NAME");
            Thread.Sleep(60);
            Console.WriteLine("       9. EXIT");
            Thread.Sleep(60);
            Console.WriteLine("    ");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("    Select your option (1-9): ");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.White;
            adminOption = Console.ReadLine();
            return adminOption;
        }

        static void ShowAccountsHeader()
        {
            Console.Clear();
            int a, b;
            a = 80; b = 2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("   _____ _                                                          _    ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("  / ____| |                          /\\                            | |    ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | (___ | |__   _____      __       /  \\   ___ ___ ___  _   _ _ __ | |_ ___ ");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("  \\___ \\| '_ \\ / _ \\ \\ /\\ / /      / /\\ \\ / __/ __/ _ \\| | | | '_ \\| __/ __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("  ____) | | | | (_) \\ V  V /      / ____ \\ (_| (_| (_) | |_| | | | | |_\\__\\");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" |_____/|_| |_|\\___/ \\_/\\_/      /_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|___/");
            Thread.Sleep(70);
        }

        static void ShowAccounts(string[] user, string[] password, string[] role, int userCount)
        {
            int z = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            int a = 100, b = 17;
            Console.SetCursorPosition(a, 15);
            Console.WriteLine("USERNAME");
            Console.SetCursorPosition(a + 15, 15);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PASSWORD");
            Console.SetCursorPosition(a + 30, 15);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ROLE");
            Console.ForegroundColor = ConsoleColor.White;
            for (int x = 0; x < userCount; x++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(a, b);
                Console.WriteLine(user[x]);
                Console.SetCursorPosition(a + 15, b);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(password[x]);
                Console.SetCursorPosition(a + 30, b);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(role[x]);
                b++;
                z++;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            if (z == 0)
            {
                Console.Clear();
                ShowAccountsHeader();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No accounts found");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }
        }

        static void AddLoginAccountHeader()
        {
            Console.Clear();
            int a, b;
            a = 70; b = 6;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("              _     _       _                 _                                         _   ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("     /\\      | |   | |     | |               (_)         /\\                            | |  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("    /  \\   __| | __| |     | |     ___   __ _ _ _ __    /  \\   ___ ___ ___  _   _ _ __ | |_ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("   / /\\ \\ / _` |/ _` |     | |    / _ \\ / _` | | '_ \\  / /\\ \\ / __/ __/ _ \\| | | | '_ \\| __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("  / ____ \\ (_| | (_| |     | |___| (_) | (_| | | | | |/ ____ \\ (_| (_| (_) | |_| | | | | |_ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" /_/    \\_\\__,_|\\__,_|     |______\\___/ \\__, |_|_| |_/_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("                                         __/ |                                              ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("                                        |___/                                               ");
            Thread.Sleep(70);
        }

        static void AddAccountHeader()
        {
            Console.Clear();
            int a, b;
            a = 80; b = 6;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("              _     _                                               _   ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     /\\      | |   | |               /\\                            | |  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    /  \\   __| | __| |              /  \\   ___ ___ ___  _   _ _ __ | |_ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   / /\\ \\ / _` |/ _` |             / /\\ \\ / __/ __/ _ \\| | | | '_ \\| __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  / ____ \\ (_| | (_| |            / ____ \\ (_| (_| (_) | |_| | | | | |_ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" /_/    \\_\\__,_|\\__,_|           /_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
        }

        static void RemoveLoginAccountHeader()
        {
            Console.Clear();
            int a, b;
            a = 70; b = 6;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("  _____                                     _                 _                                         _   ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" |  __ \\                                   | |               (_)         /\\                            | |  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | |__) |___ _ __ ___   _____   _____      | |     ___   __ _ _ _ __    /  \\   ___ ___ ___  _   _ _ __ | |_ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" |  _  // _ \\ '_ ` _ \\ / _ \\ \\ / / _ \\     | |    / _ \\ / _` | | '_ \\  / /\\ \\ / __/ __/ _ \\| | | | '_ \\| __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | | \\ \\  __/ | | | | | (_) \\ V /  __/     | |___| (_) | (_| | | | | |/ ____ \\ (_| (_| (_) | |_| | | | | |_ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" |_|  \\_\\___|_| |_| |_|\\___/ \\_/ \\___|     |______\\___/ \\__, |_|_| |_/_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("                                                         __/ |                                              ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("                                                        |___/                                               ");
            Thread.Sleep(70);
        }

        static void RemoveAccount(string signinName, string signinPassword, string[] user, string[] convertUser, string[] password, string[] role, ref int userCount)
        {
            int z = 0;
            for (int x = 0; x < userCount; x++)
            {
                if (signinName == convertUser[x] && signinPassword == password[x])
                {
                    user[x] = "";
                    convertUser[x] = "";
                    password[x] = "";
                    for (int y = x; y < userCount - 1; y++)
                    {
                        Console.WriteLine(y);
                        user[y] = user[y + 1];
                        password[y] = password[y + 1];
                        role[y] = role[y + 1];
                    }
                    user[userCount - 1] = "";
                    convertUser[userCount - 1] = "";
                    password[userCount - 1] = "";
                    role[userCount - 1] = "";
                    z++;
                    userCount--;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("   Your account has been removed.");
                    Console.WriteLine("   Press any key to try again");
                    Console.WriteLine();
                    Console.ReadKey();
                    break;
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   You have no such account. Press any key to try again");
                Console.WriteLine();
                Console.ReadKey();
            }
            Console.ReadLine();
        }

        static void AdminAccountHeader()
        {
            Console.Clear();
            int a, b;
            a = 70; b = 6;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("              _           _                                              _       ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("     /\\      | |         (_)              /\\                            | |      ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("    /  \\   __| |_ __ ___  _ _ __         /  \\   ___ ___ ___  _   _ _ __ | |_ ___ ");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("   / /\\ \\ / _` | '_ ` _ \\| | '_ \\       / /\\ \\ / __/ __/ _ \\| | | | '_ \\|| __/ __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("  / ____ \\ (_| | | | | | | | | | |     / ____ \\ (_| (_| (_) | |_| | | | | |_\\__ \\");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" /_/    \\_\\__,_|_| |_| |_|_|_| |_|    /_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|___/");
            Thread.Sleep(70);
        }

        static void AdminAccounts(string[] user, string[] password, string[] role, int userCount)
        {
            int z = 0;
            int a = 100, b = 17;
            for (int x = 0; x < userCount; x++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (role[x] == "admin")
                {
                    z++;
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" NO accounts. Press any key to try again");
                Console.WriteLine();
                Console.ReadKey();
            }
            if (z > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(a, 15);
                Console.WriteLine("USERS");
                Console.SetCursorPosition(a + 15, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PASSWORDS");
                for (int x = 0; x < userCount; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (role[x] == "admin")
                    {
                        Console.SetCursorPosition(a, b);
                        Console.WriteLine(user[x]);
                        Console.SetCursorPosition(a + 15, b);
                        Console.WriteLine(password[x]);
                        b++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Press any key to continue");
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        static void StaffAccountHeader()
        {
            Console.Clear();
            int a, b;
            a = 70; b = 6;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("   _____ _         __  __                                        _       ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("  / ____| |       / _|/ _|        /\\                            | |      ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | (___ | |_ __ _| |_| |_        /  \\   ___ ___ ___  _   _ _ __ | |_ ___ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  \\___ \\| __/ _` |  _|  _|      / /\\ \\ / __/ __/ _ \\| | | | '_ \\|| __/ __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("  ____) | || (_| | | | |       / ____ \\ (_| (_| (_) | |_| | | | | |_\\__ \\");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" |_____/ \\__\\__,_|_| |_|      /_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|___/");
            Thread.Sleep(70);
        }

        static void StaffAccounts(string[] user, string[] password, string[] role, int userCount)
        {
            int z = 0;
            for (int x = 0; x < userCount; x++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (role[x] == "staff")
                {
                    z++;
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" NO accounts. Press any key to try again");
                Console.WriteLine();
                Console.ReadKey();
            }
            if (z > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int a = 100, b = 17;
                Console.SetCursorPosition(a, 15);
                Console.WriteLine("USERS");
                Console.SetCursorPosition(a + 15, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PASSWORDS");
                for (int x = 0; x < userCount; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (role[x] == "staff")
                    {
                        Console.SetCursorPosition(a, b);
                        Console.WriteLine(user[x]);
                        Console.SetCursorPosition(a + 15, b);
                        Console.WriteLine(password[x]);
                        b++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Press any key to continue");
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        static void CustomerAccountHeader()
        {
            Console.Clear();
            int a, b;
            a = 70; b = 6;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("   _____          _                                                                   _    ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("  / ____|        | |                                   /\\                            | |      ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | |    _   _ ___| |_ ___  _ __ ___   ___ _ __        /  \\   ___ ___ ___  _   _ _ __ | |_ ___ ");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |   | | | / __| __/ _ \\| '_ ` _ \\ / _ \\ '__|     //  /\\ \\ / __/ __/ _ \\| | | | '_ \\| __/ __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |___| |_| \\__ \\ || (_) | | | | | |  __/ |        / ____ \\ ()_| ()_| (_) | |_| | | | | |_\\__ \\");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("  \\_____\\__,_|___/\\__\\___/|_| |_| |_|\\___|_|       /_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|___/");
            Thread.Sleep(70);
            Console.WriteLine();
        }

        static void CustomerAccounts(string[] user, string[] password, string[] role, int userCount)
        {
            int z = 0;
            for (int x = 0; x < userCount; x++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (role[x] == "customer")
                {
                    z++;
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" NO accounts. Press any key to try again");
                Console.WriteLine();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int a = 100, b = 17;
                Console.SetCursorPosition(a, 15);
                Console.WriteLine("USERS");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(a + 15, 15);
                Console.WriteLine("PASSWORDS");
                for (int x = 0; x < userCount; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (role[x] == "customer")
                    {
                        Console.SetCursorPosition(a, b);
                        Console.WriteLine(user[x]);
                        Console.SetCursorPosition(a + 15, b);
                        Console.WriteLine(password[x]);
                        b++;
                        z++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Press any key to continue");
                Console.WriteLine();
                Console.ReadKey();
            }

        }

        static void ModifyPasswordHeader()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("  __  __           _ _  __                                                          _ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" |  \\/  |         | (_)/ _|                                                        | |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | \\  / | ___   __| |_| |_ _   _          _ __   __ _ ___ _____      _____  _ __ __| |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |\\/| |/ _ \\ / _` | |  _| | | |        | '_ \\ / _` / __/ __\\ \\ /\\ / / _ \\| '__/ _` |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |  | | (_) | (_| | | | | |_| |        | |_) | (_| \\__ \\__ \\ V  V / (_) | | | (_| |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" |_|  |_|\\___/ \\__,_|_|_|  \\__, |        | .__/ \\__,_|___/___/ \\_/\\_/ \\___/|_|  \\__,_|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("                            __/ |        | |                                          ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("                           |___/         |_|                                          ");
            Thread.Sleep(70);
        }

        static string ModifyLoginAccountPassword(string signInName, string signInPassword, string[] convertUser, string[] passwords, int userCount)
        {
            string newP;
            int z = 0;
            for (int i = 0; i < userCount; i++)
            {
                if (signInName == convertUser[i] && signInPassword == passwords[i])
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.SetCursorPosition(5, 17);
                        Console.WriteLine("Enter new password: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(26, 17);
                        newP = Console.ReadLine();
                        int length = newP.Length;
                        if (CheckPassword(length))
                        {
                            if (CheckPasswordValid(newP))
                            {
                                passwords[i] = newP;
                                z++;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("       Your password has been changed.");
                                Console.ReadKey();
                                return newP;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(5, 18);
                                Console.WriteLine("Not valid. Try again.");
                                Console.ReadKey();
                                Console.SetCursorPosition(26, 17);
                                Console.WriteLine("                                                    ");
                                Console.SetCursorPosition(5, 18);
                                Console.WriteLine("                          ");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(5, 18);
                            Console.WriteLine("Not valid. Try again.");
                            Console.ReadKey();
                            Console.SetCursorPosition(26, 17);
                            Console.WriteLine("                                                    ");
                            Console.SetCursorPosition(5, 18);
                            Console.WriteLine("                          ");
                        }
                    }
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("       There is no such account. Try again.");
                Console.ReadKey();
            }
            return null;
        }

        static void ModifyName()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("  __  __           _ _  __              _   _                      ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" |  \\/  |         | (_)/ _|            | \\ | |                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | \\  / | ___   __| |_| |_ _   _       |  \\| | __ _ _ __ ___   ___ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |\\/| |/ _ \\ / _` | |  _| | | |      | . ` |/ _` | '_ ` _ \\ / _ \\");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |  | | (_) | ()| | | | | |_| |      | |\\  | ()| | | | | | |  __/");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" |_|  |_|\\___/ \\__,_|_|_|  \\__, |      |_| \\_|\\__,_|_| |_| |_|\\___|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("                            __/ |                                  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("                           |___/                                   ");
            Thread.Sleep(70);
            Console.WriteLine();
        }

        static void ModifyLoginAccountName(string signInName, string signInPassword, string[] users, string[] convertUsers, string[] passwords, int userCount)
        {
            string newName;
            string convertNewName;
            int z = 0, x = 0;
            for (int i = 0; i < userCount; i++)
            {
                if (signInName == convertUsers[i] && signInPassword == passwords[i])
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.SetCursorPosition(5, 17);
                        Console.WriteLine("Enter new user name: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(26, 17);
                        newName = Console.ReadLine();
                        convertNewName = Convert(newName);
                        x = CheckUsername(convertNewName);

                        if (x >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(5, 18);
                            Console.WriteLine("Not valid. Try again.");
                            Console.ReadKey();
                            Console.SetCursorPosition(26, 17);
                            Console.WriteLine("                                                                          ");
                            Console.SetCursorPosition(5, 18);
                            Console.WriteLine("                    ");
                        }
                        else
                        {
                            int length = convertNewName.Length;
                            if (CheckUserLength(length))
                            {
                                if (IsValidCustomerModifyUsername(convertNewName, users, convertUsers, userCount))
                                {
                                    users[i] = newName;
                                    convertUsers[i] = convertNewName;
                                    z++;
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("       Your name has been changed.");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(5, 18);
                                    Console.WriteLine("Already existed. Try again.");
                                    Console.ReadKey();
                                    Console.SetCursorPosition(26, 17);
                                    Console.WriteLine("                                                                          ");
                                    Console.SetCursorPosition(5, 18);
                                    Console.WriteLine("                           ");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(5, 18);
                                Console.WriteLine("Not valid. Try again.");
                                Console.ReadKey();
                                Console.SetCursorPosition(26, 17);
                                Console.WriteLine("                                                                          ");
                                Console.SetCursorPosition(5, 18);
                                Console.WriteLine("                    ");
                            }
                        }
                    }
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("       There is no such account. Try again.");
                Console.ReadKey();
            }
        }

        static bool IsValidCustomerModifyUsername(string name, string[] user, string[] convertUser, int userCount)
        {
            int k = 0;
            if (userCount > 0)
            {
                for (int y = 0; y < userCount; y++)
                {
                    if (name == convertUser[y])
                    {
                        k++;
                    }
                }
                return k == 0;
            }
            return false;
        }

        static void StaffHeader()
        {
            Console.Clear();
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("  /$$$$$$  /$$$$$$$$ /$$$$$$  /$$$$$$$$ /$$$$$$$$       /$$      /$$ /$$$$$$$$ /$$   /$$ /$$   /$$");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" /$$__  $$|__  $$__//$$__  $$| $$_____/| $$_____/      | $$$    /$$$| $$_____/| $$$ | $$| $$  | $$");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("| $$  \\__/   | $$  | $$  \\ $$| $$      | $$            | $$$$  /$$$$| $$      | $$$$| $$| $$  | $$");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("|  $$$$$$    | $$  | $$$$$$$$| $$$$$   | $$$$$         | $$ $$/$$ $$| $$$$$   | $$ $$ $$| $$  | $$");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" \\____  $$   | $$  | $$__  $$| $$__/   | $$__/         | $$  $$$| $$| $$__/   | $$  $$$$| $$  | $$");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" /$$  \\ $$   | $$  | $$  | $$| $$      | $$            | $$\\  $ | $$| $$      | $$\\  $$$| $$  | $$");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("|  $$$$$$/   | $$  | $$  | $$| $$      | $$            | $$ \\/  | $$| $$$$$$$$| $$ \\  $$|  $$$$$$/");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine(" \\______/    |__/  |__/  |__/|__/      |__/            |__/     |__/|________/|__/  \\__/ \\______/ ");
            Thread.Sleep(70);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static string StaffMenu(string staffOption)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("          ::MAIN MENU::");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     1. CUSTOMER LIST ");
            Thread.Sleep(60);
            Console.WriteLine("     2. MODIFY ACCOUNT");
            Thread.Sleep(60);
            Console.WriteLine("     3. CHECK STATUS OF ANY ACCOUNT");
            Thread.Sleep(60);
            Console.WriteLine("     4. TOTAL MONEY IN BANK");
            Thread.Sleep(60);
            Console.WriteLine("     5. VIEW CUSTOMER LOAN STATUS");
            Thread.Sleep(60);
            Console.WriteLine("     6. DELETE CUSTOMER ACCOUNT");
            Thread.Sleep(60);
            Console.WriteLine("     7. EXIT");
            Thread.Sleep(60);
            Console.WriteLine("");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Select an option(1-7): ");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.White;
            staffOption = Console.ReadLine();
            return staffOption;
        }

        static void CustomerListHeader()
        {
            Console.Clear();
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("   _____          _                                 _      _     _   ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("  / ____|        | |                               | |    (_)   | |  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | |    _   _ ___| |_ ___  _ __ ___   ___ _ __     | |     _ ___| |_ ");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |   | | | / __| __/ _ \\| '_ ` _ \\ / _ \\ '__|    | |    | / __| __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |___| |_| \\__ \\ || (_) | | | | | |  __/ |       | |____| \\__ \\ |_ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("  \\_____\\__,_|___/\\__\\___/|_| |_| |_|\\___|_|       |______|_|___/\\__|");
            Thread.Sleep(70);
            Console.WriteLine();
        }

        static void ShowCustomerList(string[] customerName, string[] age, string[] cnic, string[] money, string[] address, string[] phoneNumber, int customerCount)
        {
            if (customerCount == 0)
            {
                Console.Clear();
                CustomerListHeader();
                Console.SetCursorPosition(80, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SORRY THERE IS NO ACCOUNT OF ANY CUSTOMER.");
                Console.SetCursorPosition(100, 16);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                int a = 0, b = 17;
                Console.SetCursorPosition(a, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("The list of customers is as follows: ");
                Console.SetCursorPosition(a, 15);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("NAME");
                Console.SetCursorPosition(a + 15, 15);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("AGE");
                Console.SetCursorPosition(a + 30, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("PHONENUMBER");
                Console.SetCursorPosition(a + 45, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("CNIC");
                Console.SetCursorPosition(a + 60, 15);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("MONEY");
                Console.SetCursorPosition(a + 75, 15);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("ADDRESS");
                for (int x = 0; x < customerCount; x++)
                {
                    Console.SetCursorPosition(a, b);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(customerName[x]);
                    Console.SetCursorPosition(a + 15, b);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(age[x]);
                    Console.SetCursorPosition(a + 30, b);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(phoneNumber[x]);
                    Console.SetCursorPosition(a + 45, b);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(cnic[x]);
                    Console.SetCursorPosition(a + 60, b);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(money[x]);
                    Console.SetCursorPosition(a + 75, b);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(address[x]);
                    b++;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        static void ModifyAccountHeader()
        {
            Console.Clear();
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("  __  __           _ _  __                                              _   ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" |  \\/  |         | (_)/ _|              /\\                            | |  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | \\  / | ___   __| |_| |_ _   _        /  \\   ___ ___ ___  _   _ _ __ | |_ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |\\/| |/ _ \\ / _` | |  _| | | |      / /\\ \\ / __/ __/ _ \\| | | | '_ \\| __|");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |  | | (_) | (_| | | | | |_| |     / ____ \\ (_| (_| (_) | |_| | | | | |_ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" |_|  |_|\\___/ \\__,_|_|_|  \\__, |    /_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("                            __/ |                                        ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("                           |___/                                         ");
            Thread.Sleep(70);
        }

        static string ModifyAccountMenu(string option)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Which one do you want to change:");
            Console.WriteLine("1.   Name");
            Console.WriteLine("2.   CNIC");
            Console.WriteLine("3.   Phone number");
            Console.WriteLine("4.   Address");
            Console.WriteLine("5.   Money");
            Console.WriteLine("6.   Exit");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("    Select your option (1-6): ");
            Console.ForegroundColor = ConsoleColor.White;
            option = Console.ReadLine();
            return option;
        }

        static string ChangeName(string name1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the name of account which you want to modify: ");
            Console.ForegroundColor = ConsoleColor.White;
            name1 = Convert(Console.ReadLine());
            return name1;
        }

        static string ChangeCnic(string cnic1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the CNIC of account which you want to modify: ");
            Console.ForegroundColor = ConsoleColor.White;
            cnic1 = Console.ReadLine();
            return cnic1;
        }

        static void ModifyName(string name1, string cnic1, string[] cnic, string[] customerName, string[] convertCustomerName, int customerCount)
        {
            string newName;
            string convertName;
            int z = 0;
            for (int x = 0; x < customerCount; x++)
            {
                if (name1 == convertCustomerName[x] && cnic1 == cnic[x])
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter the new account name: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        newName = Convert(Console.ReadLine());
                        convertName = Convert(newName);
                        x = CheckCustomerName(convertName);
                        if (x >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not valid, Try again.");
                            Console.ReadKey();
                        }
                        if (x == 0)
                        {
                            int length = newName.Length;
                            if (CheckUserLength(length))
                            {
                                if (IsValidCustomerModifyName(convertName, convertCustomerName, customerCount))
                                {
                                    customerName[x] = newName;
                                    convertCustomerName[x] = convertName;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Your account name has been changed.");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Already existed. Try again.");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not valid. Try again.");
                                Console.ReadKey();
                            }
                        }
                    }
                    z++;
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("There is no such account with this name.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        static bool IsValidCustomerModifyName(string name, string[] convertCustomerName, int customerCount)
        {
            int k = 0;
            if (customerCount > 0)
            {
                for (int y = 0; y < customerCount; y++)
                {
                    if (name == convertCustomerName[y])
                    {
                        k++;
                    }
                }
                if (k == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false; // Added to satisfy compiler
        }

        static void ModifyCnic(string name1, string cnic1, string[] cnic, string[] convertCustomerName, int customerCount)
        {
            string newCnic;
            int z = 0,x=0;
            for (int b = 0; b < customerCount; b++)
            {
                if (name1 == convertCustomerName[b] && cnic1 == cnic[b])
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter the new CNIC: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        newCnic = Console.ReadLine();
                        x = CheckIntegers(newCnic);
                        if (x >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not valid. Try again.");
                            Console.ReadKey();
                        }
                        if (x == 0)
                        {
                            int length = newCnic.Length;
                            if (CheckCNIC(length))
                            {
                                cnic[b] = newCnic;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("The account CNIC has been changed. Press any key to continue.");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not valid. Try again.");
                                Console.ReadKey();
                            }
                        }
                    }
                    z++;
                    break;
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("There is no such account.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        static void ModifyPhoneNumber(string name1, string cnic1, string[] cnic, string[] convertCustomerName, string[] phoneNumber, int customerCount)
        {
            string newPhoneNumber;
            int z = 0;
            for (int x = 0; x < customerCount; x++)
            {
                if (name1 == convertCustomerName[x] && cnic1 == cnic[x])
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter the new phone number: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        newPhoneNumber = Console.ReadLine();
                        x = CheckIntegers(newPhoneNumber);
                        if (x >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not valid. Try again.");
                            Console.ReadKey();
                        }
                        if (x == 0)
                        {
                            int length = newPhoneNumber.Length;
                            if (CheckPhoneNumber(length))
                            {
                                phoneNumber[x] = newPhoneNumber;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("The account phone number has been changed. Press any key to continue.");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not valid. Try again.");
                                Console.ReadKey();
                            }
                        }
                    }
                    z++;
                    break;
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("There is no such account.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        static void ModifyAddress(string name1, string cnic1, string[] cnic, string[] convertCustomerName, string[] address, int customerCount)
        {
            string newAddress;
            int z = 0;
            for (int x = 0; x < customerCount; x++)
            {
                if (name1 == convertCustomerName[x] && cnic1 == cnic[x])
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter the new address: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        newAddress = Console.ReadLine();
                        if (x == 0)
                        {
                            int length = newAddress.Length;
                            if (CheckAddressLength(length))
                            {
                                address[x] = newAddress;
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("The account address has been changed. Press any key to continue.");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not valid. Try again.");
                                Console.ReadKey();
                            }
                        }
                    }
                    z++;
                    break;
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("There is no such account.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        static void ModifyMoney(string name1, string cnic1, string[] cnic, string[] convertCustomerName, string[] money, int customerCount)
        {
            string newMoney;
            int z = 0;
            for (int x = 0; x < customerCount; x++)
            {
                if (name1 == convertCustomerName[x] && cnic1 == cnic[x])
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter the new money: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        newMoney = Console.ReadLine();
                        x = CheckIntegers(newMoney);
                        if (x >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not valid. Try again.");
                            Console.ReadKey();
                        }
                        if (x == 0)
                        {
                            int length = newMoney.Length;
                            if (CheckMoneyLength(length))
                            {
                                if (double.TryParse(newMoney, out double n) && n >= 5000)
                                {
                                    money[x] = newMoney;
                                    Console.WriteLine("The account money has been changed. Press any key to continue.");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Not valid. Try again.");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not valid. Try again.");
                                Console.ReadKey();
                            }
                        }
                    }
                    z++;
                    break;
                }
            }
            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("There is no such account.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        static void CheckStatusHeader()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("   _____ _               _            _____ _        _             ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("  / ____| |             | |          / ____| |      | |            ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | |    | |__   ___  ___| | __      | (___ | |_ __ _| |_ _   _ ___ ");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |   | '_ \\ / _ \\/ __| |/ /       \\___ \\| __/ _` | __| | | / __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |___| | | |  __/ (__|   <        ____) | || (_| | |_| |_| \\__ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("  \\_____|_| |_|\\___|\\___|_|\\_\\      |_____/ \\__\\__,_|\\__|\\__,_|___/");
            Thread.Sleep(70);
        }

        static void CheckStatus(string customName, string customCnic, string[] customerName, string[] convertCustomerName, string[] age, string[] cnic, string[] money, string[] address, string[] phoneNumber, int arraySize, int customerCount)
        {
            int z = 0;
            for (int x = 0; x < customerCount; x++)
            {
                if (customName == convertCustomerName[x] && customCnic == cnic[x])
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Name: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(customerName[x]);
                    Thread.Sleep(60);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Age: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(age[x]);
                    Thread.Sleep(60);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Phone number: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(phoneNumber[x]);
                    Thread.Sleep(60);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Cnic: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(cnic[x]);
                    Thread.Sleep(60);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Money: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(money[x]);
                    Thread.Sleep(60);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Address: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(address[x]);
                    Thread.Sleep(60);
                    z++;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Press any key to continue.");
                    Thread.Sleep(60);
                    Console.ReadKey();
                }
            }
            if (z == 0)
            {
                Console.WriteLine("You have no account. Please first open an account. Press any key to continue.");
                Console.ReadKey();
            }
        }

        static void TotalMoneyHeader()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("  _______    _        _        __  __                        ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" |__   __|  | |      | |      |  \\/  |                       ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("    | | ___ | |_ __ _| |      | \\  / | ___  _ __   ___ _   _ ");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("    | |/ _ \\| __/ _` | |      | |\\/| |/ _ \\| '_ \\ / _ \\ | | |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("    | | (_) | || (_| | |      | |  | | (_) | | | |  __/ |_| |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("    |_|\\___/ \\__\\__,_|_|      |_|  |_|\\___/|_| |_|\\___|\\__, |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("                                                        __/ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("                                                       |___/ ");
            Thread.Sleep(70);
        }

        static int TotalMoney(string[] money, int customerCount)
        {
            int totalMoney1 = 0;
            for (int x = 0; x < customerCount; x++)
            {
                totalMoney1 = totalMoney1 + (int.Parse(money[x]));
            }
            return totalMoney1;
        }

        static void ViewLoanHeader()
        {
            Console.Clear();
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("   _____          _                                _                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("  / ____|        | |                              | |                      ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | |    _   _ ___| |_ ___  _ __ ___   ___ _ __    | |     ___   __ _ _ __  ");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |   | | | / __| __/ _ \\| '_ ` _ \\ / _ \\ '__|   | |    / _ \\ / _` | '_ \\ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |___| |_| \\__ \\ || (_) | | | | | |  __/ |      | |___| (_) | (_| | | | |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("  \\_____\\__,_|___/\\__\\___/|_| |_| |_|\\___|_|      |______\\___/ \\__,_|_| |_|");
            Thread.Sleep(70);
            Console.WriteLine();
        }

        static void ViewLoan(string[] customerName, string[] customerLoan, int customerCount)
        {
            int z = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            int a = 90, b = 17;
            Console.SetCursorPosition(a, 15);
            Console.WriteLine("Customers");
            Console.SetCursorPosition(a + 30, 15);
            Console.WriteLine("Loans");
            for (int x = 0; x < customerCount; x++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(a, b);
                Console.WriteLine(customerName[x]);
                Console.SetCursorPosition(a + 30, b);
                if (customerLoan[x] == "No")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(customerLoan[x]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(customerLoan[x]);
                }
                b++;
                z++;
            }
            Console.WriteLine();
            Console.WriteLine(" Press any key to continue");
            Console.WriteLine();
            Console.ReadKey();
            if (z == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" No accounts. Press any key to try again");
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        static void DeleteAccount()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("  _____       _      _                                                _   ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" |  __ \\     | |    | |                /\\                            | |  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | |  | | ___| | ___| |_ ___          /  \\   ___ ___ ___  _   _ _ __ | |_");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |  | |/ _ \\ |/ _ \\ __/ _ \\        / /\\ \\ / __/ __/ _ \\| | | | '_ \\| __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |__| |  __/ |  __/ ||  __/       / ____ \\ (_| (_| (_) | |_| | | | | |_");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" |_____/ \\___|_|\\___|\\__\\___|      /_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|");
            Thread.Sleep(70);
        }

        static void CustomerHeader()
        {
            Console.Clear();
            int a = 40, b = 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(a, b);
            Console.WriteLine(" $$$$$$\\  $$\\   $$\\  $$$$$$\\ $$$$$$$$\\  $$$$$$\\  $$\\      $$\\ $$$$$$$$\\ $$$$$$$\\        $$\\      $$\\ $$$$$$$$\\ $$\\   $$\\ $$\\   $$\\ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("$$  __$$\\ $$ |  $$ |$$  __$$\\__$$  __ |$$  __$$\\ $$$\\    $$$ |$$  _____|$$  __$$\\       $$$\\    $$$ |$$  _____|$$$\\  $$ |$$ |  $$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("$$ /  \\__|$$ |  $$ |$$ /  \\__|  $$ |   $$ /  $$ |$$$$\\  $$$$ |$$ |      $$ |  $$ |      $$$$\\  $$$$ |$$ |      $$$$\\ $$ |$$ |  $$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("$$ |      $$ |  $$ |\\$$$$$$\\    $$ |   $$ |  $$ |$$\\$$\\$$ $$ |$$$$$\\    $$$$$$$  |      $$\\$$\\$$ $$ |$$$$$\\    $$ $$\\$$ |$$ |  $$ |");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("$$ |      $$ |  $$ | \\____$$\\   $$ |   $$ |  $$ |$$ \\$$$  $$ |$$  __|   $$  __$$<       $$ \\$$$  $$ |$$  __|   $$ \\$$$$ |$$ |  $$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("$$ |  $$\\ $$ |  $$ |$$\\   $$ |  $$ |   $$ |  $$ |$$ |\\$  /$$ |$$ |      $$ |  $$ |      $$ |\\$  /$$ |$$ |      $$ |\\$$$ |$$ |  $$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("\\$$$$$$  |\\$$$$$$  |\\$$$$$$  |  $$ |    $$$$$$  |$$ | \\_/ $$ |$$$$$$$$\\ $$ |  $$ |      $$ | \\_/ $$ |$$$$$$$$\\ $$ | \\$$ |\\$$$$$$  |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine(" \\______/  \\______/  \\______/   \\__|    \\______/ \\__|     \\__|\\________|\\__|  \\__|      \\__|     \\__|\\________|\\__|  \\__| \\______/ ");
            Thread.Sleep(70);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static string CustomerMenu(string customerOption)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("          ::MAIN MENU::");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    1. NEW ACCOUNT");
            Thread.Sleep(60);
            Console.WriteLine("    2. DEPOSIT MONEY");
            Thread.Sleep(60);
            Console.WriteLine("    3. WITHDRAW AMOUNT");
            Thread.Sleep(60);
            Console.WriteLine("    4. BALANCE ENQUIRY");
            Thread.Sleep(60);
            Console.WriteLine("    5. CLOSE AN ACCOUNT ");
            Thread.Sleep(60);
            Console.WriteLine("    6. CHECK YOUR INFORMATION");
            Thread.Sleep(60);
            Console.WriteLine("    7. GET LOAN");
            Thread.Sleep(60);
            Console.WriteLine("    8. EXIT");
            Thread.Sleep(60);
            Console.WriteLine(" ");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("    Select your option (1-8): ");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.White;
            customerOption = Console.ReadLine();
            return customerOption;
        }

        static void NewAccountHeader()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("  _   _                                                     _   ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" | \\ | |                     /\\                            | |  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" |  \\| | _____      __      /  \\   ___ ___ ___  _   _ _ __ | |_ ");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | . ` |/ _ \\ \\ /\\ / /     / /\\ \\ / __/ __/ _ \\| | | | '_ \\| __|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |\\  |  __/\\ V  V /     / ____ \\ (_| (_| (_) | |_| | | | | |_ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" |_| \\_|\\___| \\_/\\_/     /_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|");
            Thread.Sleep(70);
        }

        static void AccountNameInstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-:INSTRUCTIONS:-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(120, 18);
            Console.WriteLine("o Blank spaces and special   ");
            Console.SetCursorPosition(120, 19);
            Console.WriteLine("  characters are not allowed.");
            Console.SetCursorPosition(120, 20);
            Console.WriteLine("o Accountname must start with");
            Console.SetCursorPosition(120, 21);
            Console.WriteLine("  an alphabet.               ");
            Console.SetCursorPosition(120, 22);
            Console.WriteLine("o Repitition in account name ");
            Console.SetCursorPosition(120, 23);
            Console.WriteLine("  is not allowed.            ");
            Console.SetCursorPosition(120, 24);
            Console.WriteLine("o Accountname  is  not  case");
            Console.SetCursorPosition(120, 25);
            Console.WriteLine("  sensitive.                 ");
            Console.SetCursorPosition(120, 26);
            Console.WriteLine("o Minimum 4 and maximum  12  ");
            Console.SetCursorPosition(120, 27);
            Console.WriteLine("  characters are allowed.    ");
        }

        static void PhoneNumberInstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-:INSTRUCTIONS:-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(120, 18);
            Console.WriteLine("o Phone number  must  be  of ");
            Console.SetCursorPosition(120, 19);
            Console.WriteLine("  eleven  characters.        ");
            Console.SetCursorPosition(120, 20);
            Console.WriteLine("o Only  numbers  can be used ");
            Console.SetCursorPosition(120, 21);
            Console.WriteLine("o Alhabets,special chsracters");
            Console.SetCursorPosition(120, 22);
            Console.WriteLine("  and  balak  spaces  are not");
            Console.SetCursorPosition(120, 23);
            Console.WriteLine("  allowed.                   ");
        }

        static void CNICInstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-:INSTRUCTIONS:-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(120, 18);
            Console.WriteLine("o CNIC  must  be  of  six    ");
            Console.SetCursorPosition(120, 19);
            Console.WriteLine("  characters.                ");
            Console.SetCursorPosition(120, 20);
            Console.WriteLine("o Only  numbers  can be used ");
            Console.SetCursorPosition(120, 21);
            Console.WriteLine("o Alhabets,special chsracters");
            Console.SetCursorPosition(120, 22);
            Console.WriteLine("  and  balak  spaces  are not");
            Console.SetCursorPosition(120, 23);
            Console.WriteLine("  allowed.                   ");
            Console.SetCursorPosition(120, 24);
            Console.WriteLine("o You must remember your cnic");
            Console.SetCursorPosition(120, 25);
            Console.WriteLine("  in  order  to  verify  your ");
            Console.SetCursorPosition(120, 26);
            Console.WriteLine("  identity.                  ");
        }

        static void MoneyInstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-:INSTRUCTIONS:-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(120, 18);
            Console.WriteLine("o Money can be minimum  5000 ");
            Console.SetCursorPosition(120, 19);
            Console.WriteLine("  and maximum 999999999 PKR. ");
            Console.SetCursorPosition(120, 20);
            Console.WriteLine("o Only  numbers  can be used ");
            Console.SetCursorPosition(120, 21);
            Console.WriteLine("o Alhabets,special chsracters");
            Console.SetCursorPosition(120, 22);
            Console.WriteLine("  and  balak  spaces  are not");
            Console.SetCursorPosition(120, 23);
            Console.WriteLine("  allowed.                   ");
        }

        static void AgeInstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-:INSTRUCTIONS:-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(120, 18);
            Console.WriteLine("o Age  can  be  minimum  18  ");
            Console.SetCursorPosition(120, 19);
            Console.WriteLine("  and maximum 150 years old. ");
            Console.SetCursorPosition(120, 20);
            Console.WriteLine("o Only  numbers  can be used ");
            Console.SetCursorPosition(120, 21);
            Console.WriteLine("o Alhabets,special chsracters");
            Console.SetCursorPosition(120, 22);
            Console.WriteLine("  and  balak  spaces  are not");
            Console.SetCursorPosition(120, 23);
            Console.WriteLine("  allowed.                   ");
        }

        static void AddressInstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-:INSTRUCTIONS:-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(120, 18);
            Console.WriteLine("o Alhabets,special chsracters");
            Console.SetCursorPosition(120, 19);
            Console.WriteLine("o ,numbers and balak spaces  ");
            Console.SetCursorPosition(120, 20);
            Console.WriteLine("  are allowed.               ");
            Console.SetCursorPosition(120, 21);
            Console.WriteLine("o Minimum 7 and maximum  30  ");
            Console.SetCursorPosition(120, 22);
            Console.WriteLine("  characters are allowed.    ");
        }

        static string AgeOfCustomer(string[] age, int customerCount)
        {
            int x = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 16);
            Console.Write("Enter your age: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(21, 16);
            age[customerCount] = Console.ReadLine();
            x = CheckIntegers(age[customerCount]);
            if (x >= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 17);
                Console.WriteLine("Not valid. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(21, 16);
                Console.WriteLine("                                                                            ");
                Console.SetCursorPosition(5, 17);
                Console.Write("                       ");
                age[customerCount] = AgeOfCustomer(age, customerCount);
                return age[customerCount];
            }
            int length = age[customerCount].Length;
            if (CheckAgeLength(length))
            {
                int n;
                if (int.TryParse(age[customerCount], out n) && n >= 18 && n <= 150)
                {
                    return age[customerCount];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(5, 17);
                    Console.WriteLine("Not eligible. Try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.SetCursorPosition(21, 16);
                    Console.WriteLine("                                                                            ");
                    Console.SetCursorPosition(5, 17);
                    Console.Write("                       ");
                    age[customerCount] = AgeOfCustomer(age, customerCount);
                    return age[customerCount];
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 17);
                Console.WriteLine("Not eligible. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(21, 16);
                Console.WriteLine("                                                                            ");
                Console.SetCursorPosition(5, 17);
                Console.Write("                       ");
                age[customerCount] = AgeOfCustomer(age, customerCount);
                return age[customerCount];
            }
        }

        static bool CheckAgeLength(int length)
        {
            return length <= 3;
        }

        static string NameOfCustomer(string[] customerName, int customerCount)
        {
            int x;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 18);
            Console.Write("Enter your account name: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, 18);
            customerName[customerCount] = Console.ReadLine();
            x = CheckUsername(customerName[customerCount]);
            if (x >= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 19);
                Console.Write("Not valid. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(5, 19);
                Console.Write("                    ");
                Console.SetCursorPosition(30, 18);
                Console.WriteLine("                                                                                        ");
                customerName[customerCount] = NameOfCustomer(customerName, customerCount);
                return customerName[customerCount];
            }
            int length = customerName[customerCount].Length;
            if (CheckUserLength(length))
            {
                return customerName[customerCount];
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 19);
                Console.WriteLine("Not valid. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(5, 19);
                Console.Write("                    ");
                Console.SetCursorPosition(30, 18);
                Console.WriteLine("                                                                                            ");
                customerName[customerCount] = NameOfCustomer(customerName, customerCount);
                return customerName[customerCount];
            }
        }

        static bool IsValidCustomerName(string[] convertCustomerName, int customerCount)
        {
            int k = 0;
            if (customerCount > 0)
            {
                for (int y = 0; y < customerCount; y++)
                {
                    if (convertCustomerName[customerCount] == convertCustomerName[y])
                    {
                        k++;
                    }
                }
                if (k == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        static int CheckCustomerName(string user)
        {
            string newName = user;
            char ascii;
            int asciiCode, x = 0;
            for (int y = 0; y < newName.Length; y++)
            {
                asciiCode = newName[y];
                ascii = (char)asciiCode;
                if (ascii == 32)
                {
                    x++;
                }
            }
            return x;
        }

        static string PhoneNumberOfCustomer(string[] phoneNumber, int customerCount)
        {
            int x = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 20);
            Console.Write("Enter your phone number: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, 20);
            phoneNumber[customerCount] = Console.ReadLine();
            x = CheckIntegers(phoneNumber[customerCount]);
            if (x >= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 21);
                Console.WriteLine("Not valid. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(30, 20);
                Console.WriteLine("                                                    ");
                Console.SetCursorPosition(5, 21);
                Console.Write("                          ");
                phoneNumber[customerCount] = PhoneNumberOfCustomer(phoneNumber, customerCount);
                return phoneNumber[customerCount];
            }
            int length = phoneNumber[customerCount].Length;
            if (CheckPhoneNumber(length))
            {
                return phoneNumber[customerCount];
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 21);
                Console.WriteLine("Not valid. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(30, 20);
                Console.WriteLine("                                                    ");
                Console.SetCursorPosition(5, 21);
                Console.Write("                          ");
                phoneNumber[customerCount] = PhoneNumberOfCustomer(phoneNumber, customerCount);
                return phoneNumber[customerCount];
            }
        }

        static bool CheckPhoneNumber(int length)
        {
            return length == 11;
        }

        static string CNICOfCustomer(string[] cnic, int customerCount)
        {
            int x = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 22);
            Console.Write("Enter your CNIC number: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(29, 22);
            cnic[customerCount] = Console.ReadLine();
            x = CheckIntegers(cnic[customerCount]);
            if (x >= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 23);
                Console.WriteLine("Not valid. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(29, 22);
                Console.WriteLine("                                                    ");
                Console.SetCursorPosition(5, 23);
                Console.Write("                          ");
                cnic[customerCount] = CNICOfCustomer(cnic, customerCount);
                return cnic[customerCount];
            }
            int length = cnic[customerCount].Length;
            if (CheckCNIC(length))
            {
                return cnic[customerCount];
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 23);
                Console.WriteLine("Not valid. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(29, 22);
                Console.WriteLine("                                                    ");
                Console.SetCursorPosition(5, 23);
                Console.Write("                          ");
                cnic[customerCount] = CNICOfCustomer(cnic, customerCount);
                return cnic[customerCount];
            }
        }

        static bool CheckCNIC(int length)
        {
            return length == 6;
        }

        static string AddressOfCustomer(string[] address, int customerCount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 24);
            Console.Write("Enter your address: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 24);
            address[customerCount] = Console.ReadLine();
            int length = address[customerCount].Length;
            if (CheckAddressLength(length))
            {
                return address[customerCount];
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 25);
                Console.WriteLine("Not valid. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(25, 24);
                Console.WriteLine("                                                                                                                                 ");
                Console.SetCursorPosition(5, 25);
                Console.Write("                          ");
                address[customerCount] = AddressOfCustomer(address, customerCount);
                return address[customerCount];
            }
        }

        static bool CheckAddressLength(int length)
        {
            return length > 6 && length < 31;
        }

        static string MoneyOfCustomer(string[] money, int customerCount)
        {
            int y = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 26);
            Console.Write("Enter your money: ");
            Console.ResetColor();
            Console.SetCursorPosition(23, 26);
            money[customerCount] = Console.ReadLine();
            y = CheckIntegers(money[customerCount]);

            if (y >= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 27);
                Console.WriteLine("Not valid. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(23, 26);
                Console.WriteLine(new string(' ', 100));
                Console.SetCursorPosition(5, 27);
                Console.WriteLine(new string(' ', 26));
                money[customerCount] = MoneyOfCustomer(money, customerCount);
                return money[customerCount];
            }

            int length = money[customerCount].Length;

            if (CheckMoneyLength(length))
            {
                int n;
                n = int.Parse(money[customerCount]);

                if (n >= 5000)
                {
                    return money[customerCount];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(5, 27);
                    Console.WriteLine("Not valid. Try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.SetCursorPosition(23, 26);
                    Console.WriteLine(new string(' ', 50));
                    Console.SetCursorPosition(5, 27);
                    Console.WriteLine(new string(' ', 26));
                    money[customerCount] = MoneyOfCustomer(money, customerCount);
                    return money[customerCount];
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 27);
                Console.WriteLine("Not valid. Try again.");
                Console.ResetColor();
                Console.ReadKey();
                Console.SetCursorPosition(23, 26);
                Console.WriteLine(new string(' ', 50));
                Console.SetCursorPosition(5, 27);
                Console.WriteLine(new string(' ', 26));
                money[customerCount] = MoneyOfCustomer(money, customerCount);
                return money[customerCount];
            }
        }

        static bool CheckMoneyLength(int length)
        {
            return length <= 9;
        }

        static int CheckIntegers(string str)
        {
            int y = 0;
            int length = str.Length;

            for (int x = 0; x < length; x++)
            {
                int asciiCode = str[x];

                if (asciiCode < 48 || asciiCode > 57)
                {
                    y++;
                }
            }

            return y;
        }

        static void IsValidCustomer(string[] customerName, ref int customerCount, string[] cnic, string[] money, string[] address, string[] phoneNumber)
        {
            int k = 0;

            if (customerCount == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nYour account has been opened. Press any key to continue:");
                Console.ResetColor();
                Console.ReadKey();
            }

            if (customerCount > 0)
            {
                for (int y = 0; y < customerCount; y++)
                {
                    if (customerName[customerCount] == customerName[y] || cnic[customerCount] == cnic[y])
                    {
                        k++;
                    }
                }

                if (k == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Valid");
                    Console.WriteLine("\nYour account has been successfully opened. Press any key to continue:");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid");
                    customerName[customerCount] = "";
                    cnic[customerCount] = "";
                    money[customerCount] = "";
                    phoneNumber[customerCount] = "";
                    address[customerCount] = "";
                    customerCount = customerCount - 1;
                    Console.WriteLine(customerCount);
                    Console.WriteLine("\nYour account has not been opened. Press any key to continue:");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        static void DepositMoneyHeader()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("  _____                       _ _         __  __                        ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" |  __ \\                     (_) |       |  \\/  |                       ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | |  | | ___ _ __   ___  ___ _| |_      | \\  / | ___  _ __   ___ _   _ ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |  | |/ _ \\ '_ \\ / _ \\/ __| | __|     | |\\/| |/ _ \\| '_ \\ / _ \\ | | |");
            System.Threading.Thread.Sleep(70);
            Console.ResetColor();
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |__| |  __/ |_) | (_) \\__ \\ | |_      | |  | | (_) | | | |  __/ |_| |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" |_____/ \\___| .__/ \\___/|___/_|\\__|     |_|  |_|\\___/|_| |_|\\___|\\__, |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("             | |                                                   __/ |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("             |_|                                                  |___/ ");
            System.Threading.Thread.Sleep(70);
        }

        static string CName(string customName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter account name: ");
            Console.ResetColor();
            customName = Convert(customName);
            return customName;
        }

        static string CCNIC(string customCnic)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter CNIC: ");
            Console.ResetColor();
            return customCnic;
        }

        static void DepositMoney(string customName, string customCnic, string[] convertCustomerName, string[] cnic, string[] money, int customerCount)
        {
            double newMoney = 0, z = 0;
            string money1;
            double newMoney1 = 0, sum = 0;
            string sum1;

            for (int x = 0; x < customerCount; x++)
            {
                if (customName == convertCustomerName[x] && customCnic == cnic[x])
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("How much money you want to deposit in your account: ");
                        Console.ResetColor();
                        money1 = Console.ReadLine();
                        x = CheckIntegers(money1);

                        if (x >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid. Try again.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        else
                        {
                            newMoney1 = double.Parse(money1);
                            newMoney = double.Parse(money[x]);
                            sum = newMoney + newMoney1;

                            if (sum > 999999999)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\nSorry, this money can't be entered in your account because it exceeds the limit. Try again.");
                                Console.ResetColor();
                                Console.ReadKey();
                                z++;
                                break;
                            }
                            else
                            {
                                sum1 = sum.ToString();
                                money[x] = sum1;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"\n{money1} has been entered in your account. Press any key to continue.");
                                Console.ResetColor();
                                Console.ReadKey();
                                z++;
                                break;
                            }
                        }
                    }

                    break;
                }
            }

            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou have no account. Please first open an account. Press any key to continue.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void WithdrawMoneyHeader()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(a, b);
            Console.WriteLine(" __           ___ _   _         _                         __  __                 ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" \\ \\        / (_) | | |       | |                       |  \\/  |                       ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("  \\ \\  /\\  / / _| |_| |__   __| |_ __ __ ___      __    | \\  / | ___  _ __   ___ _   _ ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("   \\ \\/  \\/ / | | __| '_ \\ / _` | '__/ _` \\ \\ /\\ / /    | |\\/| |/ _ \\| '_ \\ / _ \\ | | |");
            System.Threading.Thread.Sleep(70);
            Console.ResetColor();
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("    \\  /\\  /  | | |_| | | | (_| | | | (_| |\\ V  V /     | |  | | (_) | | | |  __/ |_| |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("     \\/  \\/   |_|\\__|_| |_|\\__,_|_|  \\__,_| \\_/\\_/      |_|  |_|\\___/|_| |_|\\___|\\__, |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("                                                                                  __/ |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("                                                                                 |___/ ");
            System.Threading.Thread.Sleep(70);
        }

        static void WithdrawMoney(string customName, string customCnic, string[] convertCustomerName, string[] cnic, string[] money, int arraySize)
        {
            double newMoney = 0, z = 0;
            string money1;
            double newMoney1 = 0, difference = 0;
            string difference1;

            for (int x = 0; x < arraySize; x++)
            {
                if (customName == convertCustomerName[x] && customCnic == cnic[x])
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("How much money you want to withdraw from your account: ");
                        Console.ResetColor();
                        money1 = Console.ReadLine();
                        x = CheckIntegers(money1);

                        if (x >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid. Try again.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        else
                        {
                            newMoney1 = double.Parse(money1);
                            newMoney = double.Parse(money[x]);
                            difference = newMoney - newMoney1;

                            if (difference < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\nSorry, this much money is not present in your account. Try again.");
                                Console.ResetColor();
                                Console.ReadKey();
                                z++;
                                break;
                            }
                            else
                            {
                                difference1 = difference.ToString();
                                money[x] = difference1;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"\n{money1} has been withdrawn from your account. Press any key to continue.");
                                Console.ResetColor();
                                Console.ReadKey();
                                z++;
                                break;
                            }
                        }
                    }

                    break;
                }
            }

            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou have no account. Please first open an account. Press any key to continue.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void BalanceEnquiryHeader()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("  ____        _                             ______                   _            ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" |  _ \\      | |                           |  ____|                 (_)           ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | |_) | __ _| | __ _ _ __   ___ ___       | |__   _ __   __ _ _   _ _ _ __ _   _ ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" |  _ < / _` | |/ _` | '_ \\ / __/ _ \\      |  __| | '_ \\ / _` | | | | | '__| | | |");
            System.Threading.Thread.Sleep(70);
            Console.ResetColor();
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |_) | (_| | | (_| | | | | (_|  __/      | |____| | | | (_| | |_| | | |  | |_| |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine(" |____/ \\__,_|_|\\__,_|_| |_|\\___\\___|      |______|_| |_|\\__, |\\__,_|_|_|   \\__, |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("                                                            | |              __/ |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("                                                            |_|             |___/ ");
            System.Threading.Thread.Sleep(70);
        }

        static void BalanceEnquiry(string customName, string customCnic, string[] convertCustomerName, string[] cnic, string[] money, int arraySize)
        {
            int z = 0;

            for (int x = 0; x < arraySize; x++)
            {
                if (customName == convertCustomerName[x] && customCnic == cnic[x])
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Currently your total balance is: {int.Parse(money[x])}");
                    Console.WriteLine("Press any key to continue.");
                    Console.ResetColor();
                    Console.ReadKey();
                    z++;
                }
            }

            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no account. Please first open an account. Press any key to continue.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void CloseAccountHeader()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("   _____ _                                                      _   ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("  / ____| |                      /\\                            | |  ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | |    | | ___  ___  ___       /  \\   ___ ___ ___  _   _ _ __ | |_ ");
            System.Threading.Thread.Sleep(70);
            Console.ResetColor();
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |    | |/ _ \\/ __|/ _ \\     / /\\ \\ / __/ __/ _ \\| | | | '_ \\| __|");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |____| | (_) \\__ \\  __/    / ____ \\ (_| (_| (_) | |_| | | | | |_ ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("  \\_____|_|\\___/|___/\\___|   /_/    \\_\\___\\___\\___/ \\__,_|_| |_|\\__|");
            System.Threading.Thread.Sleep(70);
        }

        static void CloseAccount(string[] age, string customName, string customCnic, string[] customerName, string[] convertCustomerName, string[] cnic, string[] money, string[] phoneNumber, string[] customerLoan, string[] address, ref int customerCount)
        {
            int z = 0;

            for (int x = 0; x < customerCount; x++)
            {
                if (customName == convertCustomerName[x] && customCnic == cnic[x])
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Your account has been closed.");
                    age[x] = "";
                    customerName[x] = "";
                    cnic[x] = "";
                    address[x] = "";
                    money[x] = "";
                    phoneNumber[x] = "";
                    convertCustomerName[x] = "";

                    for (int y = x; y < customerCount - 1; y++)
                    {
                        age[y] = age[y + 1];
                        customerName[y] = customerName[y + 1];
                        cnic[y] = cnic[y + 1];
                        address[y] = address[y + 1];
                        phoneNumber[y] = phoneNumber[y + 1];
                        money[y] = money[y + 1];
                        convertCustomerName[y] = convertCustomerName[y + 1];
                    }

                    age[customerCount - 1] = "";
                    customerName[customerCount - 1] = "";
                    cnic[customerCount - 1] = "";
                    address[customerCount - 1] = "";
                    money[customerCount - 1] = "";
                    phoneNumber[customerCount - 1] = "";
                    convertCustomerName[customerCount - 1] = "";
                    z++;
                }
            }

            if (z > 0)
            {
                customerCount--;
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }

            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no account. Please first open an account. Press any key to continue.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void CheckInformationHeader()
        {
            int a = 70, b = 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("   _____ _               _         _____        __                           _   _             ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("  / ____| |             | |       |_   _|      / _|                         | | (_)            ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine(" | |    | |__   ___  ___| | __      | |  _ __ | |_ ___  _ __ _ __ ___   __ _| |_ _  ___  _ __  ");
            System.Threading.Thread.Sleep(70);
            Console.ResetColor();
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine(" | |    | '_ \\ / _ \\/ __| |/ /      | | | '_ \\|  _/ _ \\| '__| '_ ` _ \\ / _` | __| |/ _ \\| '_ \\ ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" | |____| | | |  __/ (__|   <      _| |_| | | | || (_) | |  | | | | | | (_| | |_| | (_) | | | |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("  \\_____|_| |_|\\___|\\___|_|\\_\\    |_____|_| |_|_| \\___/|_|  |_| |_| |_|\\__,_|\\__|_|\\___/|_| |_|");
            System.Threading.Thread.Sleep(70);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void CheckInformation(string customName, string customCnic, string[] customerName, string[] convertCustomerName, string[] age, string[] cnic, string[] money, string[] address, string[] phoneNumber, int arraySize, int customerCount)
        {
            int a = 100, b = 17;
            int z = 0;

            for (int x = 0; x < customerCount; x++)
            {
                if (customName == convertCustomerName[x] && customCnic == cnic[x])
                {
                    Console.Clear();
                    CheckInformationHeader();
                    Console.SetCursorPosition(a, b);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Name: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(customerName[x]);
                    System.Threading.Thread.Sleep(60);
                    Console.SetCursorPosition(a, b + 2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Age: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(age[x]);
                    System.Threading.Thread.Sleep(60);
                    Console.SetCursorPosition(a, b + 4);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("PhoneNumber: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(phoneNumber[x]);
                    System.Threading.Thread.Sleep(60);
                    Console.SetCursorPosition(a, b + 6);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Cnic: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(cnic[x]);
                    System.Threading.Thread.Sleep(60);
                    Console.SetCursorPosition(a, b + 8);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Money: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(money[x]);
                    System.Threading.Thread.Sleep(60);
                    Console.SetCursorPosition(a, b + 10);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Address: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(address[x]);
                    System.Threading.Thread.Sleep(60);
                    Console.SetCursorPosition(a, b + 12);
                    z++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press any key to continue.");
                    System.Threading.Thread.Sleep(60);
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }

            if (z == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no account. Please first open an account. Press any key to continue.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void LoanHeader()
        {
            Console.Clear();
            int a = 90, b = 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("    _                     ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("   | |                      ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("   | |     ___   __ _ _ __  ");
            System.Threading.Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("   | |    / _ \\ / _` | '_ \\ ");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("   | |___| (_) | (_| | | | |");
            System.Threading.Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("   |______\\___/ \\__,_|_| |_|");
            System.Threading.Thread.Sleep(70);
            Console.WriteLine();
        }

        static void LoanInstructions()
        {
            Console.SetCursorPosition(120, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-:INSTRUCTIONS:-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(120, 18);
            Console.WriteLine("o You can only get a loan of ");
            Console.SetCursorPosition(120, 19);
            Console.WriteLine("  1,000,000 PKR.");
            Console.SetCursorPosition(120, 20);
            Console.WriteLine("o If your bank balance is");
            Console.SetCursorPosition(120, 21);
            Console.WriteLine("  998,999,999 PKR then the loan ");
            Console.SetCursorPosition(120, 22);
            Console.WriteLine("  can't be given to you.");
            Console.SetCursorPosition(120, 23);
            Console.WriteLine("o You can't apply for a loan if");
            Console.SetCursorPosition(120, 24);
            Console.WriteLine("  you have already availed this.");
        }

        static string Loan(string customName, string customCnic, string[] convertCustomerName, string[] cnic, string[] money, string[] loan, int customerCount)
        {
            string option = "";
            int z = 0;
            int x = 1000000;
            int newMoney = 0;
            int money1 = 0;

            for (int i = 0; i < customerCount; i++)
            {
                if (customName == convertCustomerName[i] && customCnic == cnic[i])
                {
                    if (loan[i] == "Yes")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n    You have already availed this option.");
                        Console.ResetColor();
                        Console.ReadKey();
                        return "0";
                    }

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nIf you want to take a loan, press 1. To exit, press 2: ");
                        Console.ResetColor();
                        Console.SetCursorPosition(59, 17);
                        option = Console.ReadLine();

                        if (option == "1")
                        {
                            money1 = int.Parse(money[i]) + x;

                            if (money1 < 999999999)
                            {
                                newMoney = int.Parse(money[i]) + x;
                                money[i] = newMoney.ToString();

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n    1000000 PKR has been deposited in your account. Press any key to continue.");
                                Console.ResetColor();
                                Console.ReadKey();

                                loan[i] = "Yes";
                                z++;
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nSorry! Loan can't be provided to you because it exceeds the limit. Press any key to continue.");
                                Console.ResetColor();
                                Console.ReadKey();
                                z++;
                                break;
                            }
                        }
                        else if (option == "2")
                        {
                            z++;
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(5, 18);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have entered the wrong option. Try again.");
                            Console.ResetColor();
                            Console.SetCursorPosition(59, 17);
                            Console.WriteLine("                                                                                                             ");
                            Console.SetCursorPosition(5, 18);
                            Console.WriteLine("                                        ");
                            z++;
                        }
                    }
                    break;
                }
            }

            if (z == 0)
            {
                Console.WriteLine("There is no such account. Try again.");
                Console.ReadKey();
            }

            return null;
        }

        static void ExitPage()
        {
            Console.Clear();
            int a = 65, b = 1;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(a, b);
            Console.WriteLine("                                                                                          ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("                              #############################=                              ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("                              @@@@@@@@@@@@@@%%#@@@@@@@@@@@@@+                              ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("                              ..-#######################*...                              ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("                                -@@@%%******@@@%%*****#@@@%%                                 ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("                                -@@@#:%%%% @@@+=%%%%*:@@@%%                                 ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("                  =@@@@@@@@@@@@@@@#@#:@@@@ @@@++@@@#:@@#@@@@@@@@@@@@@@@@                  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("                  -%%%%%%%%%%%%%@@%@#:@@@@ @@@++@@@#:@@%@%%%%%%%%%%%%%%%                  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 8);
            Console.WriteLine("                     %%%%%%%%%%%=@@@#:@@@@ @@@++@@@#:@@@%+%%%%%%%%%%+                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 9);
            Console.WriteLine("                    .@@%++++++@@=@@@#-++++-@@@*=+++==@@@%*@#++++++@@*                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 10);
            Console.WriteLine("                    .@@*-@@@@ @@=@@@@@*************#@@@@%*@+=@@@%.@@*                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 11);
            Console.WriteLine("                    .@@*-@@@@ @@=@@@@@  -: BANK :- -@@@@%*@+=@@@%.%@*                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 12);
            Console.WriteLine("                    .@@*-@@@@ @@=@@@@@  =+=====++  -@@@@%*@+=@@@%.@@*                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 13);
            Console.WriteLine("                    .@@*-@@@@ @@=@@@@@-------------+@@@@%*@+=@@@%.@@*                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 14);
            Console.WriteLine("                    .@@%=++++=@@=@@@========++=======*@@%*@#=+++++@@*                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 15);
            Console.WriteLine("                    .@@@@@@@@@@@=@#%        @+       =@#%*@@@@@@@@@@*                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 16);
            Console.WriteLine("                    .@@@@@@@@@@@=@%%        @+       =@%%*@@@@@@@@@@*                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 17);
            Console.WriteLine("                    .@@@@@@@@@@@=@@%        @+       =@@%*@@@@@@@@@@*                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 18);
            Console.WriteLine("                    .@@@@@@@@@@@=@@%        @+       =@@%*@@@@@@@@@@*                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 19);
            Console.WriteLine("                    .@@@@@@@@@@@=@@%        +-       =@@%*@@@@%%%%%%+                     ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 20);
            Console.WriteLine("                  -==##*+#######+###********++********##**###*======--=.                  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 21);
            Console.WriteLine("                  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*%%-                  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 22);
            Console.WriteLine();
            Console.SetCursorPosition(a, b + 23);
            Console.WriteLine();
            Console.SetCursorPosition(a, b + 24);
            Console.WriteLine();
            Console.SetCursorPosition(a, b + 25);
            Console.WriteLine();
            Console.SetCursorPosition(a, b + 26);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(a, b + 27);
            Console.WriteLine("@@@@@%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 28);
            Console.WriteLine("@@@*-:--:=+@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%#%%%#%%%@@@");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 29);
            Console.WriteLine("@@@@@@@@@#%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%@@@@@");
            Thread.Sleep(70);

            a = 25; b = 32;

            Console.SetCursorPosition(a, b);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  _______ _                 _                           __                     _   _     _                          __ _ _           _   _          ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine(" |__   __| |               | |                         / _|                   (_) (_) | (_)               | | | |   (_)                         | (_)         | | (_)            ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("    | |  | |__   __ _ _ __ | | ___   _  ___  _   _    | |_ ___  _ __    __   ___ ___ _| |_ _ _ __   __ _    | |_| |__  _ ___      __ _ _ __  _ __ | |_  ___ __ _| |_ _  ___  _ __  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("    | |  | '_ \\ / _` | '_ \\| |/ / | | |/ _ \\| | | |   |  _/ _ \\| '__|   \\ \\ / / / __| | __| | '_ \\ / _` |   | __| '_ \\| / __|    / _` | '_ \\| '_ \\| | |/ __/ _` | __| |/ _ \\| '_ \\ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine("    | |  | | | | (_| | | | |   <| |_| | (_) | |_| |   | || (_) | |       \\ V /| \\__ \\ | |_| | | | | (_| |   | |_| | | | \\__ \\   | (_| | |_) | |_) | | | (_| (_| | |_| | (_) | | | |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("    |_|  |_| |_|\\__,_|_| |_|_|\\_\\__, |\\___/ \\__,_|    |_| \\___/|_|        \\_/ |_|___/_|\\__|_|_| |_|\\__, |    \\__|_| |_|_|___/    \\__,_| .__/| .__/|_|_|\\___\\__,_|\\__|_|\\___/|_| |_|");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("                                  __/ |                                                             __/ |                             | |   | |                                    ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine("                                 |___/                                                             |___/                              |_|   |_|                                    ");
            Thread.Sleep(70);
        }

        static string ParseData(string line, int field)
        {
            string item = "";
            int commaCount = 1;

            foreach (char character in line)
            {
                if (character == ',')
                {
                    commaCount++;
                }
                else if (field == commaCount)
                {
                    item += character;
                }
            }

            return item;
        }

        static void LoadData(string[] user, string[] convertUser, string[] password, string[] role, ref int userCount)
        {
            string line;

            using (StreamReader file = new StreamReader("userdata.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string username = ParseData(line, 1);
                    string password1 = ParseData(line, 2);
                    string role1 = ParseData(line, 3);
                    string convert = ParseData(line, 4);

                    user[userCount] = username;
                    password[userCount] = password1;
                    role[userCount] = role1;
                    convertUser[userCount] = convert;

                    userCount++;
                }
            }
        }

        static void WriteData(string[] user, string[] convertUser, string[] password, string[] role, int userCount)
        {
            using (StreamWriter file = new StreamWriter("userdata.txt"))
            {
                for (int i = 0; i < userCount; i++)
                {
                    file.WriteLine($"{user[i]},{password[i]},{role[i]},{convertUser[i]}");
                }
            }
        }

        static void LoadDataCustomer(string[] age, string[] customerName, string[] convertCustomerName, string[] phoneNumber, string[] cnic, string[] address, string[] money, string[] customerLoan, ref int customerCount)
        {
            string line;

            using (StreamReader file = new StreamReader("customerdata.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string age1 = ParseData(line, 1);
                    string name = ParseData(line, 2);
                    string phoneNumber1 = ParseData(line, 3);
                    string cnic1 = ParseData(line, 4);
                    string address1 = ParseData(line, 5);
                    string money1 = ParseData(line, 6);
                    string loan = ParseData(line, 7);
                    string convert = ParseData(line, 8);

                    age[customerCount] = age1;
                    customerName[customerCount] = name;
                    phoneNumber[customerCount] = phoneNumber1;
                    cnic[customerCount] = cnic1;
                    address[customerCount] = address1;
                    money[customerCount] = money1;
                    customerLoan[customerCount] = loan;
                    convertCustomerName[customerCount] = convert;

                    customerCount++;
                }
            }
        }

        static void WriteDataCustomer(string[] age, string[] customerName, string[] convertCustomerName, string[] phoneNumber, string[] cnic, string[] address, string[] money, string[] customerLoan, int customerCount)
        {
            using (StreamWriter file = new StreamWriter("customerdata.txt"))
            {
                for (int i = 0; i < customerCount; i++)
                {
                    file.WriteLine($"{age[i]},{customerName[i]},{phoneNumber[i]},{cnic[i]},{address[i]},{money[i]},{customerLoan[i]},{convertCustomerName[i]}");
                }
            }
        }

        static string Convert(string word)
        {
            char ascii;
            int asciiCode;

            for (int y = 0; y < word.Length; y++)
            {
                asciiCode = word[y];
                ascii = (char)asciiCode;

                if (ascii == 'A')
                {
                    ascii = 'a';
                }
                else if (ascii == 'B')
                {
                    ascii = 'b';
                }
                else if (ascii == 'C')
                {
                    ascii = 'c';
                }
                else if (ascii == 'D')
                {
                    ascii = 'd';
                }
                else if (ascii == 'E')
                {
                    ascii = 'e';
                }
                else if (ascii == 'F')
                {
                    ascii = 'f';
                }
                else if (ascii == 'G')
                {
                    ascii = 'g';
                }
                else if (ascii == 'H')
                {
                    ascii = 'h';
                }
                else if (ascii == 'I')
                {
                    ascii = 'i';
                }
                else if (ascii == 'J')
                {
                    ascii = 'j';
                }
                else if (ascii == 'K')
                {
                    ascii = 'k';
                }
                else if (ascii == 'L')
                {
                    ascii = 'l';
                }
                else if (ascii == 'M')
                {
                    ascii = 'm';
                }
                else if (ascii == 'N')
                {
                    ascii = 'n';
                }
                else if (ascii == 'O')
                {
                    ascii = 'o';
                }
                else if (ascii == 'P')
                {
                    ascii = 'p';
                }
                else if (ascii == 'Q')
                {
                    ascii = 'q';
                }
                else if (ascii == 'R')
                {
                    ascii = 'r';
                }
                else if (ascii == 'S')
                {
                    ascii = 's';
                }
                else if (ascii == 'T')
                {
                    ascii = 't';
                }
                else if (ascii == 'U')
                {
                    ascii = 'u';
                }
                else if (ascii == 'V')
                {
                    ascii = 'v';
                }
                else if (ascii == 'W')
                {
                    ascii = 'w';
                }
                else if (ascii == 'X')
                {
                    ascii = 'x';
                }
                else if (ascii == 'Y')
                {
                    ascii = 'y';
                }
                else if (ascii == 'Z')
                {
                    ascii = 'z';
                }

                asciiCode = ascii;
                word = word.Remove(y, 1).Insert(y, asciiCode.ToString());
            }

            return word;
        }

    }
}
