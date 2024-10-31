using System;

namespace Problem.StudentDataBase.Pesel
{
    internal class GeneratePeselNumber
    {
        private const int MaleOddModifier = 1;
        private const int FemaleEvenModifier = 0;
        private const int MaxIndividualNumber = 999;

        private const int Modifier1800s = 80;
        private const int Modifier2000s = 20;
        private const int Modifier2100s = 40;
        private const int Modifier2200s = 60;

        private static readonly int[] Weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        private static readonly Random Random = new Random();

        public int YearOfBirth { get; private set; }
        public int MonthOfBirth { get; private set; }
        public int DayOfBirth { get; private set; }
        public bool IsMale { get; private set; }

        public GeneratePeselNumber(int yearOfBirth, int monthOfBirth, int dayOfBirth, bool isMale)
        {
            YearOfBirth = yearOfBirth;
            MonthOfBirth = monthOfBirth;
            DayOfBirth = dayOfBirth;
            IsMale = isMale;
        }

        public string GeneratePesel()
        {
            string yearPart = GetYearPart();
            string monthPart = GetMonthPart();
            string dayPart = DayOfBirth.ToString("D2");
            string individualNumber = GenerateIndividualNumber();
            string genderDigit = GenerateGenderDigit();
            string peselWithoutChecksum = $"{yearPart}{monthPart}{dayPart}{individualNumber}{genderDigit}";

            int checksum = CalculateChecksum(peselWithoutChecksum);
            return $"{peselWithoutChecksum}{checksum}";
        }

        private string GetYearPart() => YearOfBirth.ToString("D4").Substring(2, 2);

        private string GetMonthPart()
        {
            int adjustedMonth = MonthOfBirth + GetCenturyModifier();
            return adjustedMonth.ToString("D2");
        }

        private int GetCenturyModifier()
        {
            if (YearOfBirth >= 1800 && YearOfBirth < 1900) return Modifier1800s;
            if (YearOfBirth >= 2000 && YearOfBirth < 2100) return Modifier2000s;
            if (YearOfBirth >= 2100 && YearOfBirth < 2200) return Modifier2100s;
            if (YearOfBirth >= 2200 && YearOfBirth < 2300) return Modifier2200s;
            return 0;
        }

        private string GenerateIndividualNumber() =>
            Random.Next(0, MaxIndividualNumber + 1).ToString("D3");

        private string GenerateGenderDigit()
        {
            int genderDigit = Random.Next(0, 10);

            return (IsMale ? genderDigit | MaleOddModifier : genderDigit & ~MaleOddModifier).ToString();
        }

        private int CalculateChecksum(string peselWithoutChecksum)
        {
            int sum = 0;

            for (int i = 0; i < Weights.Length; i++)
            {
                sum += Weights[i] * (int)char.GetNumericValue(peselWithoutChecksum[i]);
            }

            return (10 - (sum % 10)) % 10;
        }
    }
}
