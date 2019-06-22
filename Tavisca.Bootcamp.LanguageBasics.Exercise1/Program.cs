using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
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
            string[] arrABC = equation.Split("*");
            string A = arrABC[0];
            string[] arrBC =  arrABC[1].Split("=");
            string B = arrBC[0];
            string C = arrBC[1];

            if(C.Contains('?'))
                return CalValue(A, B, C, 3);
            else if(A.Contains('?'))
                return CalValue(C, B, A, 1);
            else if(B.Contains('?'))
                return CalValue(C, A, B, 2);
            return -1;
        }
        public static int CalValue(string X, string Y, string Z, int i)
        {
            int x = Int32.Parse(X);
            int y = Int32.Parse(Y);
            
            int z;
            if(i == 3)
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
