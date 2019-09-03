using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IncomeAndExpences
{
    class ProgramInitlizing
    {
        public void ProgramInitilizer(List<Income> incomes, List<Expenses> expenses, List<FinanceActivities> financeActivities, ReadAndWrite readAndWrite, DataRetriever dataRetriever)
        {
            Console.WriteLine("Wellcome to finance manager interface!\n" +
                "1. Enter Income\n" +
                "2. Enter Expense\n" +
                "3. Print Incomes and Expenses by month.\n" +
                "4. Print Report by month.\n" +
                "5. Display all Incomes.\n" +
                "6. Display all Expenses.\n" +
                "7. Display all Incomes and Expenses.\n" +
                "8. Delete all data.\n" +
                "9. Exit.");
            while (true)
            {
                string readme = Console.ReadLine();
                
                switch (readme)
                {
                    case "1":
                    {
                        Income obj = new Income();
                        incomes.Add(obj);
                        financeActivities.Add(obj);
                        readAndWrite.WriteToList(obj);
                        break;
                    }
                    case "2":
                    {
                        Expenses obj = new Expenses();
                        expenses.Add(obj);
                        financeActivities.Add(obj);
                        readAndWrite.WriteToList(obj);
                        break;
                    }
                    case "3":
                    {
                        try
                        {
                            List<FinanceActivities> totalData = dataRetriever.printMonth(financeActivities);
                            foreach (FinanceActivities item in totalData)
                            {
                                Console.WriteLine(item);
                                Console.WriteLine();
                            }
                        }
                        catch (NoDataExeption ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    }
                    case "4":
                    {
                        try
                        {
                            dataRetriever.PrintReportByMonth(financeActivities);
                        }
                        catch (NoDataExeption ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    }
                    case "5":
                    {
                        incomes.OrderBy(p => p.Date).ToList().ForEach(p => { Console.WriteLine(); p.Display("Income"); });

                        if (incomes.Count == 0)
                        {
                            Console.WriteLine("No incomes avialable.");
                        }
                        break;
                    }
                    case "6":
                    {
                        expenses.OrderBy(p => p.Date).ToList().ForEach(p => { Console.WriteLine(); p.Display("Expense"); });

                        if (expenses.Count == 0)
                        {
                            Console.WriteLine("No expenses avialable.");
                        }
                        break;
                    }
                    case "7":
                    {
                        financeActivities = financeActivities.OrderBy(p => p.Date).ToList();

                        foreach (FinanceActivities item in financeActivities)
                        {
                            Console.WriteLine();
                            if (item is Expenses)
                                item.Display("Expense");
                            else
                                item.Display("Income");
                        }

                        if (financeActivities.Count == 0)
                        {
                            Console.WriteLine("No finance managments avialable.");
                        }
                        break;
                    }
                    case "8":
                    {
                        financeActivities.Clear();
                        expenses.Clear();
                        incomes.Clear();
                        File.WriteAllText(@"..\..\financeText.txt", string.Empty);
                        Console.WriteLine("Data deleted.");
                        break;
                    }
                    case "9":
                    {
                        Environment.Exit(9);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid input! please choose an option from 1 to 9.");
                        continue;
                    }
                }

                ClearConsole(incomes, expenses, financeActivities, readAndWrite, dataRetriever);
            }
        }

        public void ClearConsole(List<Income> incomes, List<Expenses> expenses, List<FinanceActivities> financeManagment, ReadAndWrite readAndWrite, DataRetriever dataRetriever)
        {
            Console.WriteLine("\nPress on any key to continue.");
            Console.ReadKey();
            Console.Clear();
            ProgramInitilizer(incomes, expenses, financeManagment, readAndWrite, dataRetriever);
        }
    }
}
