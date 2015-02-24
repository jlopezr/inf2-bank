using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankAccount
    {
        public String owner;
        public int ageOwner;
        public double amount;
    }

    class Program
    {
        static BankAccount readBankAccount()
        {
            BankAccount account = new BankAccount();
            Console.WriteLine("Dime el nombre del propietario: ");
            account.owner = Console.ReadLine();
            Console.WriteLine("Dime la edad del propietario: ");
            account.ageOwner = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Dime la cantidad inicial: ");
            //account.amount = Convert.ToDouble(Console.ReadLine());            
            account.amount = 0;
            return account;
        }

        static void incrementAmount(BankAccount account, double money)
        {
            account.amount = account.amount + money;
        }

        static void decrementAmount(BankAccount account, double money)
        {

        }

        static void writeAccount(BankAccount account)
        {

        }

        static BankAccount accountUnion(BankAccount a1, BankAccount a2)
        {
            if (a1.owner == a2.owner && a1.ageOwner == a2.ageOwner)
            {
                BankAccount result = new BankAccount();
                result.owner = a1.owner;
                result.ageOwner = a1.ageOwner;
                result.amount = a1.amount + a2.amount;
                return result;
            }
            else
            {
                return null;
            }
        }

        class BankAccountList
        {
            public int accountNumber = 0;
            public BankAccount[] accounts = new BankAccount[100];          
        }

        static int addAccount(BankAccountList list, BankAccount account)
        {
            if (list.accountNumber == 100)
            {
                return -1;
            }
            else
            {
                list.accounts[list.accountNumber] = account;
                list.accountNumber = list.accountNumber + 1;
                return 0;
            }
        }


        static void loadAccounts(BankAccountList list)
        {
            bool end = false;

            while (!end)
            {
                Console.WriteLine("Quieres añadir?");
                String result = Console.ReadLine();
                if (result == "s")
                {
                    BankAccount account = readBankAccount();
                    addAccount(list, account);
                }
                else
                {
                    end = true;
                }
            }
        }

        static void writeAccounts(BankAccountList list)
        {
            int i = 0;
            while (i < list.accountNumber)
            {
                BankAccount account = list.accounts[i];
                writeAccount(account);
                Console.WriteLine("-------------------------------");
                i++;
            }
        }

        static BankAccount higherAmount(BankAccountList list) {
            int i = 0;
            double maxAmount = -1;
            BankAccount result = null;

            while (i < list.accountNumber)
            {
                if (list.accounts[i].amount > maxAmount)
                {
                    result = list.accounts[i];
                    maxAmount = result.amount;
                }
                i++;
            }
            return result;
        }

        static void Main(string[] args)
        {
            BankAccountList l = new BankAccountList();
            loadAccounts(l);
            incrementAmount(l.accounts[0], 100);
            incrementAmount(l.accounts[1], 1000);
            BankAccount ac = higherAmount(l);
            if (ac != null)
            {
                writeAccount(ac);
            }
            else
            {
                Console.WriteLine("No hay ninguna cuenta");
            }


            /*BankAccount ac1 = readBankAccount();
            Console.WriteLine("Cuanto quieres ingresar?");
            double cantidad = Convert.ToDouble(Console.ReadLine());
            incrementAmount(ac1, cantidad);
            Console.WriteLine("Cuanto quieres sacar?");
            cantidad = Convert.ToDouble(Console.ReadLine());
            decrementAmount(ac1, cantidad);
            writeAccount(ac1);
            BankAccount ac2 = readBankAccount();
            BankAccount resultado = accountUnion(ac1, ac2);
            if (resultado != null)
            {
                writeAccount(resultado);
            }
            else
            {
                Console.WriteLine("El propietario de las cuentas NO es el mismo");
            }*/

            /*
            BankAccount ac1 = readBankAccount();
            Console.WriteLine("Cuanto quieres ingresar?");
            double cantidad = Convert.ToDouble(Console.ReadLine());
            incrementAmount(ac1, cantidad);
            BankAccount ac2 = readBankAccount();
            Console.WriteLine("Cuanto quieres ingresar?");
            cantidad = Convert.ToDouble(Console.ReadLine());
            incrementAmount(ac2, cantidad);
            
            BankAccount resultado = accountUnion(ac1, ac2);
            */
        }
    }
}
