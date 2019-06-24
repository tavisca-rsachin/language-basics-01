using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        public enum Cases
        {
            FirstCase,
            SecondCase,
            ThirdCase

        }
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            if(String.IsNullOrEmpty(equation))
                throw new ArgumentNullException(nameof(equation));

            string[] equationSplitAsterisk = equation.Split("*");
            string multiplier1 = equationSplitAsterisk[0];
            string[] equationSplitAsteriskAndEqual =  equationSplitAsterisk[1].Split("=");
            string multiplier2 = equationSplitAsteriskAndEqual[0];
            string result = equationSplitAsteriskAndEqual[1];

            return GetMissingDigit(multiplier1, multiplier2, result);
            
        }

        public static int GetMissingDigit(string multiplier1, string multiplier2, string result)
        {
            int multiplierTemp;
            if(int.TryParse(multiplier1, out multiplierTemp) == false)
                return GetMissingDigitInMultiplier(int.Parse(multiplier2), multiplier1, int.Parse(result));
            else if(int.TryParse(multiplier2, out multiplierTemp) == false)
                return GetMissingDigitInMultiplier(int.Parse(multiplier1), multiplier2, int.Parse(result));
            else
                return GetMissingDigitInResult(int.Parse(multiplier1), int.Parse(multiplier2), result);

        }

        public static int GetMissingDigitInMultiplier(int multiplier1, string multiplier2, int result)
        {
            if(multiplier1 == 0 || result == 0 || result % multiplier1 != 0)
                return -1;

            return GetDigitFromEvaluatedResult(result/multiplier1, multiplier2);
        }

        public static int GetMissingDigitInResult(int multiplier1, int multiplier2, string result)
        {
            return GetDigitFromEvaluatedResult(multiplier1*multiplier2, result);
        }

        public static int GetDigitFromEvaluatedResult(int evaluatedResult, string targetedMultiplierOrResult)
        {
            string evaluatedResultStr = Convert.ToString(evaluatedResult);

            if(evaluatedResultStr.Length != targetedMultiplierOrResult.Length)
                    return -1;

            int ind = targetedMultiplierOrResult.IndexOf('?');
            return (int)(evaluatedResultStr[ind]-'0');
        }
    }
}
