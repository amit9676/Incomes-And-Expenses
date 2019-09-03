using System;
namespace IncomeAndExpences
{
    class MinusValueExeption : Exception
    {
        public MinusValueExeption() : base("Value can not be negative! Please put positive value.")
        {

        }
    }
}
