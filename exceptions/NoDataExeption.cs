using System;

namespace IncomeAndExpences
{
    class NoDataExeption : Exception
    {
        public NoDataExeption() : base("There is no data for selected date.")
        {
        }
    }
}
