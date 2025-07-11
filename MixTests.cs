using System.IO;
using System;

class MixTests
{
    static int add1(int n)  // OK 07.09.25
    {
        return -~n;
    }

    static int sub1(int n)  // OK 07.09.25
    {
        return ~-n;
    }

    static void test_read_line()  // OK 07.09.25
    {
        Console.Write("Enter a number>");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("x={0}\n", x);
    }

    static void test_loops()  // OK 07.09.25
    {
        int[] myInts = { 10, 20, 30, 40 };
        foreach (int i in myInts)
            Console.WriteLine(i);
    }

    static void test_condition_operator() // OK 07.09.25
    {
        int x = 1, y = 0, z = 0, p = 0;
        y = x << 2;
        z = add1(z);
        p = (x > y) ? 1 : 3;
        Console.WriteLine("x={0}\t\ty={1}\t\tz={2}\t\tp={3}", x, y, z, p);
    }

    static void test_nameof() // OK 07.10.25
    {
        double PI = 3.14;
        Console.WriteLine("{0} = {1}", nameof(PI),PI);
    }

    static bool areEqual(int a, int b)  // OK 07.10.25
    {
        return (a ^ b) == 0;
    }

    static bool isPowerOf2(int n)   //  OK 07.10.25
    {
        return (n!=0) && (n & (n - 1)) == 0;
    }

    static bool isOdd(int n)    // OK 07.10.25
    {
        return (n & 1) == 1;
    }

    static int mult_by_2(int n) // OK 07.10.25
    {
        return n << 1;
    }

    static int mult_by_7(int n) // OK 07.10.25
    {
        return (n << 3) -n;
    }

    // OK 07.10.25
    // Conversion to binary
    //	0 is not handled as of 2.22.17
    static void convert2(int n)
    {
        if (n > 0)
        {
            convert2(n / 2);
            Console.Write(n % 2);
        }
    }


    // OK 07.10.25
    // 	Conversion to hexadecimal
    //	0 is not handled as of 2.23.17
    static void convert8(int n)
    {
        if (n > 0)
        {
            convert8(n / 8);
            Console.Write(n % 8);
        }
    }


    // OK 07.10.25
    // Conversion to hexadecimal
    //	0 is not handled as of 2.22.17
    static void convert16(int n)
    {
        int rem = 0;
        if (n > 0)
        {
            convert16(n / 16);
            rem = n % 16;

            switch (rem)
            {
                case 10:
                    Console.Write("A");
                    break;
                case 11:
                    Console.Write("B");
                    break;
                case 12:
                    Console.Write("C");
                    break;
                case 13:
                    Console.Write("D");
                    break;
                case 14:
                    Console.Write("E");
                    break;
                case 15:
                    Console.Write("F");
                    break;
                default:
                    Console.Write(rem);
                    break;
            };
        }
    }

    //  Euclid's Algorithm, O(n)
    static int gcd(int a, int b)
    {
        return (b == 0 ? a : gcd(b, a % b));
    }

    /* Budd, "Data Structures in C++ using STL, p 55 */
    //  Euclid's Algorithm, O(n)
    static int gcd1(int m, int n)
    {
    //    assert(n > 0 && m > 0);  // Does the assert equivalent exist in C#?

        while (m != n)
        {
            if (n > m)
                n = n - m;
            else
                m = m - n;
        }
        return n;
    }

    //  Complexity:     O(n^(1/2))  Budd, p 67
    static bool isPrime(int n)
    {
        int i = 2;

        //	Sanity checking
        if (n <= 1) return false;

        while (i * i <= n)
        {
            if (n % i == 0) return false;
            ++i;
        }
        return true;
    }

    static int mult_by_5(int n)
    {
        return (n << 2) + n;
    }

    static int mult_by_10(int n)
    {
        return (n << 3) + (n << 1);
    }

    /* Remainder by 8 without % operator */
    static int rem8(int x)
    {
        return x - 8 * (x >> 3);
    }

    // Recursive multiplication by addition
    static int mult(int a, int b)
    {
        if (b == 0)
            return 0;
        else
            return a + mult(a, b - 1);
    }

    //  03.27.15
    static int add(int a, int b)
    {
        int sum = a ^ b; //   add without carrying
        int carry = (a & b) << 1;  // Carry, don't add

        if (b == 0) return a;

        return add(sum, carry);
    }


    //	06.04.2020
    //	0 is neither positive nor negative
    static bool isSameSign2(int x, int y)
    {
        // Since 0 has no sign, any number and 0 won't have same sign.
        if (x == 0 && y == 0) return false;
        else if (x == 0 || y == 0) return false;
        else if (areEqual(x, y)) return true;
        return ((x ^ y) > 0);
    }

    static void ToLower()   // OK 07.10.25
    {
        char ch;

        for (ch = 'A'; ch <= 'Z'; ch++)
            Console.Write((char)(ch | ' '));
    }


    static void ToUpper()  // OK 07.10.25
    {
        char ch;

        for (ch = 'a'; ch <= 'z'; ch++)
            Console.Write((char)(ch & '_'));
    }

    
    static void InvertCase()    // OK 07.11.25
    {

        char ch;

        //  To lower
        for (ch = 'A'; ch <= 'Z'; ch++)
            Console.Write((char)(ch ^ ' '));
        Console.WriteLine("");

        //  To Upper
        for (ch = 'a'; ch <= 'z'; ch++)
            Console.Write((char)(ch ^ ' '));
        Console.WriteLine("");
    }

    
    static void InvertCase2()   // OK 07.11.25
    {
        char ch;

        //   To upper
        for (ch = 'a'; ch <= 'z'; ch++)
            Console.Write((char)(ch + 'A' - 'a'));
        Console.WriteLine("");

        //  To lower
        for (ch = 'A'; ch <= 'Z'; ch++)
            Console.Write((char)(ch - 'A' + 'a'));
        Console.WriteLine("");
    }

    //	Recursive Version of Fibonacci numbers
    //	O(2^n)
    static int fib(int n)
    {
        if (n <= 1)
            return n;
        else
            return fib(n - 1) + fib(n - 2);
    }

    //	Iterative Version of Fibonacci numbers
    //	O(n)
    static int fib1(int num)
    {
        int term1 = 0, term2 = 1, i, temp;

        if (num == 0)
            return 0;
        if (num == 1)
            return 1;

        for (i = 2; i <= num; i++)
        {
            temp = term1;
            term1 = term2;
            term2 = term1 + temp;
        }
        return term2;
    }

    //	Turning on k-th bit of a number n
    //	Bit numeration starts from 1!
    int turnOnKthBit(int n, int k)
    {
        return n | (1 << (k - 1));
    }



    int turnOffKthBit(int n, int k)
    {
        return n & ~(1 << (k - 1));
    }


    int toggleKthBit(int n, int k)
    {
        return n ^ (1 << (k - 1));
    }


    int unsetRightMostBit(int n)
    {
        return n & (n - 1);
    }



    //	Find absolute value
    int findAbsoluteValue(int n)
    {
        int mask = n >> 31;
        return (n + mask) ^ mask;
    }




    /*
    10/22/10
    Test of min and max, works OK - don't get it yet.
    
    On some rare machines where branching is very expensive and no condition move instructions exist, 
    the above expression might be faster than the obvious approach, r = (x < y) ? x : y, 
    even though it involves two more instructions. (Typically, the obvious approach is best, though.) 
    It works because if x < y, then -(x < y) will be all ones, so r = y ^ (x ^ y) & ~0 = y ^ x ^ y = x. 
    Otherwise, if x >= y, then -(x < y) will be all zeros, so r = y ^ ((x ^ y) & 0) = y. 
    On some machines, evaluating (x < y) as 0 or 1 requires a branch instruction, so there may be no advantage. 
*/
    static void min_max()
    {
        int x = 3, y = 2, r = 0;

        /* Find min */
     //   r = y ^ ((x ^ y) & -(x < y));   // C and C++
        r = y ^ ((x ^ y) & ((-1) * (x < y ? 1 : 0)));
        Console.WriteLine("x={0}\ty={1}\tmin({2},{3}) = {4}", x, y, x, y, r);
        //  Under JDK 1.7 as per 05.15.12
        //  r=y^((x^y) & ((-1) * (x<y?1:0)));


        /* Find max */
    //    r = x ^ ((x ^ y) & -(x < y));   //  C and C++
        r = x ^ ((x ^ y) & ((-1) * (x < y ? 1 : 0)));
        Console.WriteLine("x={0}\ty={1}\tmax({2},{3}) = {4}", x, y, x, y, r);
        //  Under JDK 1.7 as per 05.15.12
        //  r=x^((x^y) & ((-1) * (x<y?1:0)));

    }

    //  Hanoi Towers

    //
    //	test of Towers of Hanoi routine
    //
    //	Described in Chapter 3 of
    //	Data Structures in C++ using the STL
    //	Published by Addison-Wesley, 1997
    //	Written by Tim Budd, budd@cs.orst.edu
    //	Oregon State University
    static void Hanoi(int n, char a, char b, char c)
    // move n disks from tower a to tower b, using tower c
    {
        if (n == 1)
        {
            // can move smallest disk directly
         //   cout << "move disk from tower " << a << " to " << b << endl;
            Console.WriteLine("Move disk from tower {0} to {1}", a, b);
        }
        else
        {
            // first move all but last disk from tower a to tower c via b
            Hanoi(n - 1, a, c, b);

            // then move one disk from a to b
        //    cout << "move disk from tower " << a << " to " << b << endl;

            Console.WriteLine("Move disk from tower {0} to {1}", a, b);

            // then move all disks from c back to b via a
            Hanoi(n - 1, c, b, a);
        }
    }

    static void test_Hanoi()
    {
        Hanoi(3, 'a', 'b', 'c');
        //    Hanoi(4, 'a', 'b', 'c');
        //    Hanoi(5, 'a', 'b', 'c');
    }

    //	Swap 2 ints without 3rd parameter
    //	Only swap technique is show in this method!
    //	No actual swap is done here!
    static void swap1(int x, int y)
    {
        x ^= y ^= x ^= y;
    }


    //	Swap 2 ints without 3rd parameter
    //	Only swap technique is show in this method!
    //	No actual swap is done here!
    static void swap2(int a, int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    static bool isPowerOf_2(int num)    // OK 07.11.25
    {
        if (num <= 0) return false;
        return (num > 0) && Math.Ceiling(Math.Log(num) / Math.Log(2)) == Math.Floor(Math.Log(num) / Math.Log(2));
    }

    //	Test for Multiplication Overflow
    //  C and C++ INT_MAX value is Int32.MaxValue in C#
    static bool isMultOverflow(int x, int y)
    {
        return x > Int32.MaxValue / y;
    }

    //  Test for an ADD overflow
    //  C and C++ INT_MAX value is Int32.MaxValue in C#
    bool WillOverflow_GOOD(int x, int add)
    {
        // This won't overflow because "x" can't be greater than INT_MAX
        // Use UINT_MAX for unsigned - what is the name of the corresponding constant in C#?
        return (Int32.MaxValue - x) < add;
    }

    //  Morgan Stanley, 07/29/10
    //  find a maximum of double x and 0 without if statement
    double max2(double x)
    {
        return (x + Math.Abs(x)) / 2;
    }


    static void Main()
    {

        //       Console.WriteLine("typeof(x) = {0}\n", sizeof(this->p));
        //   test_read_line(); // OK 07.09.25
        //   test_loops(); // OK 07.09.25
        //   test_nameof(); // OK 07.10.25

        
        int a = 1, b = 2, c = 7, d = -1, zero = 0, d16 = 16;
        /*
        Console.WriteLine("areEqual({0},{1}) => {2}", a, b, areEqual(a,b));
        Console.WriteLine("areEqual({0},{1}) => {2}", a, a, areEqual(a, a));

        Console.WriteLine("isPowerOf2({0}) => {1}", a, isPowerOf2(a));
        Console.WriteLine("isPowerOf2({0}) => {1}", b, isPowerOf2(b));
        Console.WriteLine("isPowerOf2({0}) => {1}", c, isPowerOf2(c));
        Console.WriteLine("isPowerOf2({0}) => {1}", d, isPowerOf2(d));
        Console.WriteLine("isPowerOf2({0}) => {1}", d, isPowerOf2(d16));
        Console.WriteLine("isPowerOf2({0}) => {1}", zero, isPowerOf2(zero));

        Console.WriteLine("isOdd({0}) => {1}", a, isOdd(a));
        Console.WriteLine("isOdd({0}) => {1}", b, isOdd(b));

        Console.WriteLine("{0} * 2 = {1}", a, mult_by_2(a));
        Console.WriteLine("{0} * 2 = {1}", b, mult_by_2(b));
        Console.WriteLine("{0} * 2 = {1}", c, mult_by_2(c));
        Console.WriteLine("{0} * 2 = {1}", d, mult_by_2(d));

        Console.WriteLine("{0} * 7 = {1}", a, mult_by_7(a));
        Console.WriteLine("{0} * 7 = {1}", b, mult_by_7(b));
        Console.WriteLine("{0} * 7 = {1}", c, mult_by_7(c));
        Console.WriteLine("{0} * 7 = {1}", d, mult_by_7(d));

        Console.Write("{0} in BINARY = ", d16);
        convert2(d16);
        Console.Write("\n{0} in OCTAL = ", d16);
        convert8(d16);
        Console.Write("\n{0} in HEX = ", d16);
        convert16(d16);

        Console.WriteLine("\n{0} is prime? {1}", b, isPrime(b));
        Console.WriteLine("{0} is prime? {1}", a, isPrime(a));
        Console.WriteLine("{0} is prime? {1}", c, isPrime(c));
        Console.WriteLine("{0} is prime? {1}", d16, isPrime(d16));
        */
        min_max();
        Console.WriteLine("isPowerOf_2({0}) => {1}", a, isPowerOf_2(a));
        Console.WriteLine("isPowerOf_2({0}) => {1}", b, isPowerOf_2(b));
        Console.WriteLine("isPowerOf_2({0}) => {1}", c, isPowerOf_2(c));
        Console.WriteLine("isPowerOf_2({0}) => {1}", d, isPowerOf_2(d));
        Console.WriteLine("isPowerOf_2({0}) => {1}", d16, isPowerOf_2(d16));
        Console.WriteLine("isPowerOf_2({0}) => {1}", zero, isPowerOf_2(zero));
    }
}
