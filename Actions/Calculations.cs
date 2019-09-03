using System.Collections.Generic;

namespace IncomeAndExpences
{
    class Calculations
    {

        public decimal TotalIncomes (List<FinanceActivities> incomes)
        {
            decimal total = 0;
            foreach (FinanceActivities item in incomes)
            {
                if(item is Income)
                    total += item.Value;
            }
            return total;
        }

        public decimal TotalExpenses(List<FinanceActivities> expenses)
        {
            decimal total = 0;
            foreach (FinanceActivities item in expenses)
            {
                if (item is Expenses)
                    total += item.Value;
            }
            return total;
        }

        public decimal Taxes(decimal GrossProfits)
        {
            if (GrossProfits < 0)
                return 0;
            else if (GrossProfits >= 0 && GrossProfits <= 4590)
                return GrossProfits / 10;
            else if (GrossProfits > 4590 && GrossProfits <= 8160)
                return GrossProfits / 100 * 15;
            else if (GrossProfits > 8160 && GrossProfits <= 12250)
                return GrossProfits / 100 * 23;
            else if (GrossProfits > 12250 && GrossProfits <= 17600)
                return GrossProfits / 10 * 3;
            else if (GrossProfits > 17600 && GrossProfits <= 37890)
                return GrossProfits / 100 * 34;
            else
                return GrossProfits / 100 * 46;
        }

        public decimal NationalInsurance(decimal GrossProfits)
        {
            if (GrossProfits < 0 || GrossProfits > 36750)
                return 0;
            else if (GrossProfits >= 0 && GrossProfits <= 4598)
                return GrossProfits / 100 * (decimal)9.82;
            else
                return GrossProfits / 100 * (decimal)16.23;
        }

    }
}
