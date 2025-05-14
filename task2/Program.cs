using System;
using System.Linq;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Input2.input.Replace("\n", "").Split("\r");

            long wrapPaper = 0;
            long ribbon = 0;

            foreach (var row in input)
            {
                var sides = row.Split('x').Select(x => Convert.ToInt32(x)).ToList();
                
                //part 1
                var side1A = sides[0] * sides[1];
                var side2A = sides[1] * sides[2];
                var side3A = sides[0] * sides[2];
                var minSideA = Math.Min(side1A, Math.Min(side2A, side3A));

                wrapPaper += 2 * (side1A + side2A + side3A) + minSideA;

                //part 2
                var side1P = (sides[0] + sides[1]) * 2;
                var side2P = (sides[1] + sides[2]) * 2;
                var side3P = (sides[0] + sides[2]) * 2;
                var minSideP = Math.Min(side1P, Math.Min(side2P, side3P));
                var volume = sides[0] * sides[1] * sides[2];

                ribbon += (minSideP + volume);
            }

            Console.WriteLine(wrapPaper);
            Console.WriteLine(ribbon);
        }
    }
}
