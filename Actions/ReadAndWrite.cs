using System;
using System.Collections.Generic;
using System.IO;

namespace IncomeAndExpences
{
    class ReadAndWrite
    {
        public void WriteToList(FinanceActivities actionData)
        {
            using (StreamWriter financeText = new StreamWriter(@"..\..\financeText.txt", true))
            {
                financeText.WriteLine(actionData);
                financeText.WriteLine();
            }
        }

        public void ReadFromList(List<FinanceActivities> actionData, List<Expenses> expenseData, List<Income> incomeData)
        {
            using (StreamReader financeText = new StreamReader(@"..\..\financeText.txt", true))
            {
                string line = "k";
                DateTime date;
                string description;
                decimal value;
                ExpensesTypes expensesType;

                while (line != null)
                {

                    line = financeText.ReadLine();
                    if (line == "" || line == null)
                    {
                        continue;
                    }

                    if (line[0] == (char)TextReader.E)
                    {
                        date = DateTime.Parse(line.Replace("Expense date: ", ""));

                        line = financeText.ReadLine();
                        description = line.Replace("Expense description: ", "");

                        line = financeText.ReadLine();
                        value = decimal.Parse(line.Replace("Expense value: ", ""));

                        line = financeText.ReadLine();
                        expensesType = (ExpensesTypes)Enum.Parse(typeof(ExpensesTypes), line.Replace("Expense type: ", ""));
                        actionData.Add(new Expenses(date, description, value, expensesType));
                        expenseData.Add(new Expenses(date, description, value, expensesType));

                    }
                    else if (line[0] == (char)TextReader.I)
                    {
                        date = DateTime.Parse(line.Replace("Income date: ", ""));

                        line = financeText.ReadLine();
                        description = line.Replace("Income description: ", "");

                        line = financeText.ReadLine();
                        value = decimal.Parse(line.Replace("Income value: ", ""));

                        actionData.Add(new Income(date, description, value));
                        incomeData.Add(new Income(date, description, value));
                    }
                    else
                    {
                        throw new CorruptedExeption();
                    }

                }
            }
        }
    }
}
