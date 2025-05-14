using System;
using System.Collections.Generic;
using System.Text;

namespace task1
{
    class task1bothparts
    {
        static void Main(string[] args)
        {
            var input = Input1.input;

            var openingCount = 0;
            var closingCount = 0;
            var firstTimeBasement= 0;

            foreach (var x in input)
            {
                // part 1
                if ( x == '(')
                {
                    openingCount++;
                }
                else if ( x == ')')
                {
                    closingCount++;
                }
                

                //part 2
                if(closingCount > openingCount && firstTimeBasement == 0)
                {
                    firstTimeBasement = openingCount + closingCount;
                }

            }
            Console.WriteLine(openingCount-closingCount);
            Console.WriteLine(firstTimeBasement);
            Console.ReadLine();
        }
    }
}
