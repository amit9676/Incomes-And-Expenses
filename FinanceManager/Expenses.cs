using System;
using System.Collections.Generic;

namespace IncomeAndExpences
{
    // Expenses is a FinanceManagent
    class Expenses : FinanceActivities
    {
        public ExpensesTypes ExpensesType;

        public Expenses()
        {
            base.EnterDate("Expense");
            base.EnterDescription("Expense");
            base.EnterValue("Expense");
            EnterType();

            Console.WriteLine("\nExpense added");
        }

        public Expenses(DateTime date, string description, decimal value, ExpensesTypes type)
        {
            Date = date;
            Description = description;
            Value = value;
            ExpensesType = type;

        }

        public void EnterType()
        {
            bool typeTrigger = false;
            do
            {
                try
                {
                    List<int> nums = new List<int> { 1, 2, 3, 4, 5 };
                    int val;
                    Console.WriteLine("\nEnter Expense type\n" +
                        "1. Regular\n" +
                        "2. Vatless\n" +
                        "3. Car\n" +
                        "4. Phone\n" +
                        "5. Refreshments");
                    string type = Console.ReadLine();
                    if (int.TryParse(type, out val) && nums.IndexOf(int.Parse(type)) == -1)
                    {
                        throw new Exception();
                    }
                    string type2 = char.ToUpper(type[0]) + type.Substring(1);

                    ExpensesType = (ExpensesTypes)Enum.Parse(typeof(ExpensesTypes), type2);
                    typeTrigger = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("This is not an Expense type from the list");
                }
            }
            while (!typeTrigger);
        }

        public override string ToString()
        {
            return ("Expense date: " + Date.ToString("d/M/yyyy") + "\r\n" + "Expense description: " + Description
                + "\r\n" + "Expense value: " + Value + "\r\n" + "Expense type: " + ExpensesType);
        }

        public override void Display(string financeType)
        {
            base.Display("Expense");
            Console.WriteLine("Expense type: " + ExpensesType);
        }
    }
    
}
