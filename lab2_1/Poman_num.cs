namespace lab2
{
    internal class RomanNumber : ICloneable, IComparable
    {
        public RomanNumber(ushort n)
        {
            int i;
            if (n == 0)
                throw new RomanNumberException("Constructor: n is equal to zero.");
            Num = n;
            Rom_String = "";
            for (i = 0; i < Mass_Size; ++i)
            {
                while (n - Meaning[i] >= 0)
                {
                    Rom_String += Romans[i];
                    n -= Meaning[i];
                }
            }
        }
        public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Add:  one object is null.");
            if (n1.Num + n2.Num > ushort.MaxValue)
                throw new RomanNumberException("Add: sum exceeds ushort max value.");
            return new RomanNumber((ushort)(n1.Num + n2.Num));
        }
        public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Sub: one object is null.");
            if (n1.Num <= n2.Num)
                throw new RomanNumberException("Sub: result is less than or equal to zero.");
            return new RomanNumber((ushort)(n1.Num - n2.Num));
        }
        public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Mul: one object is null.");
            if (n1.Num * n2.Num > ushort.MaxValue)
                throw new RomanNumberException("Mul: result exceeds ushort max value.");
            return new RomanNumber((ushort)(n1.Num * n2.Num));
        }
        public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Div: one object is null.");
            if (n1.Num / n2.Num == 0)
                throw new RomanNumberException("Div: result equals zero.");
            return new RomanNumber((ushort)(n1.Num / n2.Num));
        }
        public override string ToString()
        {
            return Rom_String;
        }
        // Clone и CompareTo пришлось добавить, иначе класс был бы абстрактным.
        public object Clone()
        {
            return new RomanNumber(Num);
        }
        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber)
                return this.Num.CompareTo(((RomanNumber)obj).Num);
            throw new RomanNumberException("CompareTo: obj is null or not RomanNumber.");
        }
        private static int Mass_Size = 19;
        private static string[] Romans =
            { "_L", "_L_X", "_X", "_X_V",
            "_V", "_VM", "M", "CM", "D", "CD", "C", "XC", "L",
            "XL", "X", "IX", "V", "IV", "I" };
        private static ushort[] Meaning =
            { 50000, 40000, 10000, 9000, 5000, 4000, 1000, 900, 500,
            400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private ushort Num;
        private string Rom_String;
    }
}