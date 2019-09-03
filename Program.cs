using System;
using System.Collections.Generic;


namespace IncomeAndExpences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Income> incomes = new List<Income>();
            List<Expenses> expenses = new List<Expenses>();
            List<FinanceActivities> financeActivities = new List<FinanceActivities>();
            ReadAndWrite readAndWrite = new ReadAndWrite();
            DataRetriever dataRetriever = new DataRetriever();
            try
            {
                readAndWrite.ReadFromList(financeActivities, expenses, incomes);
            }
            catch (CorruptedExeption ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            ProgramInitlizing init = new ProgramInitlizing();
            init.ProgramInitilizer(incomes, expenses, financeActivities, readAndWrite, dataRetriever);
        }
    }
}
