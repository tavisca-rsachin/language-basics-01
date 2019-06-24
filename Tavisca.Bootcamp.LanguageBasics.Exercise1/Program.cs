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
            string operandA = equationSplitAsterisk[0];
            string[] equationSplitAsteriskAndEqual =  equationSplitAsterisk[1].Split("=");
            string operandB = equationSplitAsteriskAndEqual[0];
            string operandC = equationSplitAsteriskAndEqual[1];

            if(operandC.Contains('?'))
                return CalValue(operandA, operandB, operandC, Cases.ThirdCase);
            else if(operandA.Contains('?'))
                return CalValue(operandC, operandB, operandA, Cases.FirstCase);
            else if(operandB.Contains('?'))
                return CalValue(operandC, operandA, operandB, Cases.SecondCase);
            return -1;
            
        }

        public static int CalValue(string X, string Y, string Z, Cases i)
        {
            int x = Int32.Parse(X);
            int y = Int32.Parse(Y);
            
            int z;
            if(i == Cases.ThirdCase)
                z = x * y;
            else 
            {
                if(x == 0 || y == 0 || x % y != 0)
                    return -1;
                z = x / y;
            }

            string res = Convert.ToString(z);

            if(res.Length != Z.Length)
                    return -1;

            int ind = Z.IndexOf('?');
            return (int)(res[ind]-'0');
        }
    }
}
