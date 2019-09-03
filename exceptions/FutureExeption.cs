using System;

namespace IncomeAndExpences
{
    class FutureExeption : Exception
    {
        public FutureExeption(): base("This date did not exist yet! please put a date which existed.")
        {

        }

    }
}
