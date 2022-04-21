using System;
namespace MyApp
{
    public class BankCard
    {
        public string BankName { get; set; }
        public string PAN { get; set; }
        public string Pin { get; set; }
        public int CVC { get; set; }
        public double Balans { get; set; }
        public BankCard(string BankName,string pin,double Balans)
        {
            this.BankName = BankName; Pin = pin;this.Balans = Balans;
        }

    } 
    class Client
    {
        public Client(int id,string Name,string Surname,int age,double salary,BankCard card)
        {
            Id = id; Age = age;
            this.Name = Name;this.Surname = Surname;
            Salary = salary;
            Card = card;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public BankCard Card { get; set; }
        public void ShowCardBalance()
        {
            Console.WriteLine(Card.Balans); 
        }
    }
    class ATM :ApplicationException
    {
        public Client[] client = {};
        public ATM(Client[] cln)
        {
            client = cln;
        }
        private int check(string pin)
        {
            int count = 0;
            foreach (var item in client)
            {
                if (item.Card.Pin == pin)return count;
                count++;
            }
            return -1;
        }
        private double Money3(int array)
        {
            Console.Write("Enter Money: ");
            double num = Convert.ToDouble(Console.ReadLine());
  
               try
               {
                if (num < 0) { throw new Exception(); };
                return num;
               }
               catch 
               {
                    
                Console.WriteLine("Incorrect card information!");
                Thread.Sleep(1000);
                return 0;
               }
            
            
        }
        private void Money2(int money,int array)
        {

            double var =  client[array].Card.Balans;
            double var2 = 0;
            try
            {
                switch (money)
                {
                    case 0:
                        if (var >= 10) var2 += 10;
                        else throw new ATM(default);
                        break;
                    case 1:
                        if (var >= 20) var2 += 20;
                        else throw new ATM(default);
                        break;
                    case 2:
                        if (var >= 50) var2 += 50;
                        else throw new ATM(default);
                        break;
                    case 3:
                        if (var >= 100) var2 += 100;
                        else throw new ATM(default);
                        break;
                    case 4:
                        double num = Money3(array);
                        if (var >= num) var2 += num;
                        else throw new ATM(default);
                        break;
                    default:
                        break;
                
                }
                client[array].Card.Balans -= var2;
                return;
            }
            catch (ATM m)
            {

                Console.WriteLine("No money in balance");
                Thread.Sleep(1000);
            }


        }
        private void WithdrawMoney(int array)
        {
            int number = 0;
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Clear();
            do
            {
                string[] Array = new string[] { ") 10 AZN", ") 20 AZN", ") 50 AZN", ") 100 AZN",") Other" };
                for (int i = 0; i < Array.Length; i++)
                {
                    if (i == number) { Array[i] += " <-"; }
                    Console.WriteLine($"{i+1}{Array[i]}");
                }
                ConsoleKeyInfo selec = Console.ReadKey();
                Console.Clear();
                if (selec.Key == ConsoleKey.UpArrow && number == 0) number = Array.Length - 1;
                else if (selec.Key == ConsoleKey.DownArrow && number == Array.Length - 1) number = 0;
                else if (selec.Key == ConsoleKey.UpArrow) number--;
                else if (selec.Key == ConsoleKey.DownArrow) number++;
                else if (selec.Key == ConsoleKey.Enter) { Money2(number, array); return; }
                else { Console.WriteLine("Enter (UpArrow && DownArrow && click Enter to select)"); continue; }
            } while (true);

        }
        private void Choice2(int sel,int array)
        {
            Console.Clear();
            switch (sel)
            {
                case 0:
                    Console.WriteLine($"Balance {client[array].Card.Balans}");
                    Thread.Sleep(1000);
                    break;
                case 1:
                    WithdrawMoney(array);
                    break;
                default:
                    break;
            }
            Console.Clear();
            return;
        }
        private void Choice(int array)
        {
            int number = 0;
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Clear();
            do
            {
                if (number == 0) Console.WriteLine("balance\t<-\nWithdraw money");
                else Console.WriteLine("balans\t\nWithdraw money<-");
                ConsoleKeyInfo selec = Console.ReadKey();
                Console.Clear();
                if (selec.Key == ConsoleKey.DownArrow && number == 0) number = 1;
                else if (selec.Key == ConsoleKey.UpArrow && number == 1) number = 0;
                else if (selec.Key == ConsoleKey.UpArrow) number++;
                else if (selec.Key == ConsoleKey.DownArrow) number--;
                else if (selec.Key == ConsoleKey.Enter) Choice2(number,array);
                else { Console.WriteLine("Enter (UpArrow && DownArrow && click Enter to select)"); continue; }
            } while (true);
        }
        public void Start()
        {
            int count= 0;
            do
            {
                Console.Write("Enter pin: ");
                var pin = Console.ReadLine();
                count = check(pin);
                if (count >= 0) break;
                Console.Clear();
            } while (count < 0);
            Choice(count);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           Client[] client = {
           new Client(12, "a", "A", 12, 12, new BankCard("Z", "Z", 100))
           };
           ATM A = new(client);
           A.Start();

        }
    }
}