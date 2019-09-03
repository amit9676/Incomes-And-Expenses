using System;
using System.Globalization;

namespace IncomeAndExpences
{
    abstract class FinanceActivities
    {
        public DateTime Date;
        public string Description;
        public decimal Value;

        public virtual void EnterDate(string financeType)
        {
            bool dateTrigger = false;

            do
            {
                try
                {
                    Console.WriteLine("Enter " + financeType + " date (in format d/m/yyyy)");
                    CultureInfo dateFormat = new CultureInfo("fr-FR");
                    Date = DateTime.Parse(Console.ReadLine(), dateFormat);
                    if (Date.Date > DateTime.Now.Date)
                    {
                        throw new FutureExeption();
                    }
                    dateTrigger = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is an invalid date!");
                }
                catch (FutureExeption ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            while (!dateTrigger);
        }

        public virtual void EnterDescription(string financeType)
        {
            Console.WriteLine("\nEnter " + financeType + " description");
            Description = Console.ReadLine();
        }

        public virtual void EnterValue(string financeType)
        {
            bool valueTrigger = false;

            do
            {
                try
                {
                    Console.WriteLine("\nEnter " + financeType + " value");
                    Value = decimal.Parse(Console.ReadLine());
                    if (Value <= 0)
                    {
                        throw new MinusValueExeption();
                    }
                    valueTrigger = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter numirical value!");
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Value is either too large or too small.") ;
                }
                catch (MinusValueExeption ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!valueTrigger);
        }

        public virtual void Display(string financeType)
        {
            Console.WriteLine(financeType + " date: " + Date.ToString("d/M/yyyy"));
            Console.WriteLine(financeType + " description: " + Description);
            Console.WriteLine(financeType + " value: " + Value);
        }



    }
}
