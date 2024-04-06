using System;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*

         Problem:
         t and z are strings consist of lowercase English letters.

         Find all substrings for t, and return the maximum value of [ len(substring) x [how many times the substring occurs in z] ]

         Example:
         t = acldm1labcdhsnd
         z = shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa

         Solution:
         abcd is a substring of t, and it occurs 5 times in Z, abcd.Length x 5 = 20 is the solution

         */

            var t = "acldm1labcdhsnd";
            var z = "shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa";

            string FindOccurance(string substring, string mainString)
            {
                var max = 0;

                for (var i = 0; i < substring.Length; ++i)
                {
                    for (var k = i + 1; k <= substring.Length - i; ++k)
                    {
                        var substr = substring.Substring(i, k);
                        var temp = CountSubstring(substr, mainString) * substr.Length;

                        if (temp > max)
                            max = temp;

                    }

                }

                return max.ToString();
            }

            int CountSubstring(string substr, string mainstr)
            {
                var bIdx = 0;
                var count = 0;
                var index = 0;
                while (true)
                {
                    index = mainstr.IndexOf(substr,bIdx);
                    if (index != -1)
                    {
                        ++count;
                        bIdx = index + substr.Length;
                    }
                    
                    if (index == -1 || bIdx >= mainstr.Length)
                        break;
                    
                }
                //Console.WriteLine(count);
                return count;
            }


            Console.WriteLine(FindOccurance(t, z));
        }
    }
}
