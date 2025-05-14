using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Input3.input;
            var currPosSanta = (x: 0, y: 0);
            var currPosRoboSanta = (x: 0, y: 0);
            var giftedHouses = new HashSet<(int x,int y)>();
            giftedHouses.Add(currPosSanta);
            giftedHouses.Add(currPosRoboSanta);

            var isSantaTurn = true;

            foreach (var x in input)
            {
                var currPos = isSantaTurn ? currPosSanta : currPosRoboSanta;

                //part 1
                var newPos = (0,0);
                switch (x)
                {
                    case 'v':
                        newPos = (currPos.x, currPos.y - 1);
                        break;
                    case '^':
                        newPos = (currPos.x, currPos.y + 1);
                        break;
                    case '<':
                        newPos = (currPos.x - 1, currPos.y);
                        break;
                    case '>':
                        newPos = (currPos.x + 1, currPos.y);
                        break;
                    default:
                        break;
                }

                currPos = newPos;
                var test = giftedHouses.Add(newPos);
                //

                //part 2
                if (isSantaTurn)
                {
                    currPosSanta = currPos;
                }
                else
                {
                    currPosRoboSanta = currPos;
                }
                isSantaTurn = !isSantaTurn;
            }

            Console.WriteLine(giftedHouses.Count);
            Console.ReadKey();
        }
    }

    
}
