using System;

namespace IncomeAndExpences
{
    class CorruptedExeption : Exception
    {
        public CorruptedExeption():base("Data corrupted, please check or delete corrupted data on documnent.") { }
    }
}
