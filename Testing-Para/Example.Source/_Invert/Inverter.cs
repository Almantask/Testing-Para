namespace Example.Source._Invert
{
    // Variation 2.3 - difficult to determine exact boundary value.
    public class Inverter
    {
        public const int Invalid = 0;

        public int Reverse(int integer)
        {
            var numberAsString = integer.ToString();

            var isNegative = integer < 0;
            if (isNegative)
            {
                numberAsString = numberAsString.Substring(1);
            }

            var reversedAsString = new string(numberAsString.Reverse().ToArray());

            var canParse = int.TryParse(reversedAsString, out int reversedAsNumber);
            if (!canParse)
            {
                return Invalid;
            }

            if (isNegative)
            {
                reversedAsNumber = reversedAsNumber * -1;
            }

            return reversedAsNumber;
        }
    }
}
