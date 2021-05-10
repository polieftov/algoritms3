using System;

namespace LabWork3
{
    class Program
    {
        static void Main()
        {
            var t1 = new PolishAlg("2*4");         
            if (t1.Transform() != "2,4,*")
                Console.WriteLine("Test 1 failed");

            var t2 = new PolishAlg("x+5");
            if (t2.Transform() != "x,5,+")
                Console.WriteLine("Test 2 failed");

            var t3 = new PolishAlg("x+5*2-3");
            if (t3.Transform() != "x,5,2,*,+,3,-")
                Console.WriteLine("Test 3 failed");

            var t4 = new PolishAlg("x+5=32/2");
            if (t4.Transform() != "x,5,+,32,2,/,=")
                Console.WriteLine("Test 4 failed");

            var t5 = new PolishAlg("(x+5)*(2-3)");
            if (t5.Transform() != "x,5,+,2,3,-,*")
                Console.WriteLine("Test 5 failed");

            var t6 = new PolishAlg("-x+5");
            if (t6.Transform() != "-x,5,+")
                Console.WriteLine("Test 6 failed");

            var t7 = new PolishAlg("sin(87)");
            if (t7.Transform() != "87,sin")
                Console.WriteLine("Test 7 failed");

            var t8 = new PolishAlg("sin(87+x)");
            if (t8.Transform() != "87,x,+,sin")
                Console.WriteLine("Test 8 failed");

            var t9 = new PolishAlg("cos(32*x/5)");
            if (t9.Transform() != "32,x,*,5,/,cos")
                Console.WriteLine("Test 9 failed");

            var t10 = new PolishAlg("cos(32*-x/5)");
            if (t10.Transform() != "32,-x,*,5,/,cos")
                Console.WriteLine("Test 10 failed");

            var t11 = new PolishAlg("tan(124-x/5)");
            if (t11.Transform() != "124,x,5,/,-,tan")
                Console.WriteLine("Test 11 failed");

            var t12 = new PolishAlg("x^5");
            if (t12.Transform() != "x,5,^")
                Console.WriteLine("Test 12 failed");

            var t13 = new PolishAlg("x^5+7*8");
            if (t13.Transform() != "x,5,^,7,8,*,+")
                Console.WriteLine("Test 12 failed");

            var t14 = new PolishAlg("x^y/(5*z)+10");
            if (t14.Transform() != "x,y,^,5,z,*,/,10,+")
                Console.WriteLine("Test 12 failed");
            Console.WriteLine("Hello World!");
        }
    }
}
