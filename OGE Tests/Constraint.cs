using System;

namespace OGE_Tests
{
    public class Constraint
    {
        public static bool isAppropriateSymbol(char symbol, int leftConstr, int rightConstr)
        {
            if (symbol != 8 && symbol != 32)
                if (symbol <= leftConstr || symbol >= rightConstr)
                {
                    return true;
                }
            return false;
        }

        public static bool isAppropriateSymbol(char symbol, int rightConstr)
        {
            return isAppropriateSymbol(symbol, 48, rightConstr);
        }
    }
}
