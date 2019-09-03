using System;

namespace IncomeAndExpences
{
    class Income : FinanceActivities
    {

        public Income()
        {
            base.EnterDate("Income");
            base.EnterDescription("Income");
            base.EnterValue("Income");
            Console.WriteLine("\nIncome added");
        }
        
        public Income(DateTime date, string description, decimal value)
        {
            Date = date;
            Description = description;
            Value = value;
        }

        public override string ToString()
        {
            return ("Income date: " + Date.ToString("d/M/yyyy") + "\r\n" + "Income description: " + Description
                + "\r\n" + "Income value: " + Value);
        }
    }
}
