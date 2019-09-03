using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace IncomeAndExpences
{
    class DataRetriever
    {
        private Calculations Calculations = new Calculations();

        public List<FinanceActivities> printMonth(List<FinanceActivities> actionData)
        {
            DateTime date = GetDate();
            Console.WriteLine();
            List<FinanceActivities> totalData = actionData.FindAll(p => ((p.Date.Month == date.Month) && (p.Date.Year == date.Year))).
                OrderBy(p => p.Date).ThenBy(p => p.Value).ToList();
            if (totalData.Count == 0)
                throw new NoDataExeption();

            return totalData;
        }

        public void PrintReportByMonth(List<FinanceActivities> actionData)
        {
            List<FinanceActivities> totalData = printMonth(actionData);

            decimal totalIncome = Calculations.TotalIncomes(totalData);
            Console.WriteLine("The total amount of incomes with vat is: " + totalIncome);

            decimal vatlessIncome = totalIncome - (totalIncome / 100 * 17);
            Console.WriteLine("The total amount of incomes without vat is: " + vatlessIncome);

            decimal totalExpenses = Calculations.TotalExpenses(totalData);
            Console.WriteLine("The total amount of expenses with vat is: " + totalExpenses);

            decimal vatlessExpenses = totalExpenses - (totalExpenses / 100 * 17);
            Console.WriteLine("The total amount of expenses without vat is: " + vatlessExpenses);

            decimal grossProfit = totalIncome - totalExpenses;
            Console.WriteLine("The gross ptrofit is: " + grossProfit);

            decimal vatToPay = (totalIncome / 100 * 17) - (totalExpenses / 100 * 17);
            if (vatToPay < 0)
                vatToPay = 0;
            Console.WriteLine("The vat needed to pay is: " + vatToPay);

            decimal taxes = Calculations.Taxes(grossProfit);
            Console.WriteLine("The taxes needed to pay is: " + taxes);

            decimal nationalInsurance = Calculations.NationalInsurance(grossProfit);
            Console.WriteLine("The national Insurances needed to pay is: " + nationalInsurance);

            decimal totalLoses = taxes + vatToPay + nationalInsurance;
            Console.WriteLine("The total loses from the gross profit is: " + totalLoses);

            decimal netProfit = grossProfit - totalLoses;
            Console.WriteLine("The net profit is: " + netProfit);

        }

        public DateTime GetDate()
        {
            DateTime date = DateTime.Now;
            bool dateTrigger = false;
            do
            {
                try
                {

                    Console.WriteLine("Enter date (in format m/yyyy)");
                    CultureInfo dateFormat = new CultureInfo("fr-FR");
                    date = DateTime.ParseExact(Console.ReadLine(), "M/yyyy", dateFormat);

                    if (date.Date > DateTime.Now.Date)
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
            return date;
        }
    }
}
