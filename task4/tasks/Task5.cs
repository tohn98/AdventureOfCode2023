using System;
using System.Collections.Generic;
using System.Linq;

class Task5
{
    public static void NiceString()
    {
        var input = input5.input.Replace("\n", "").Split("\r");

        var result = 0;
        var resultPart2 = 0;

        char[] givenCharacters = { 'a', 'e', 'i', 'o', 'u' };



        foreach (var row in input)
        {
            //for part 1 only
            //if (row.Contains("ab") || row.Contains("cd") || row.Contains("pq") || row.Contains("xy"))
            //    continue;

            List<char> uniqueCharacters = new List<char>();
            bool foundDoubleLetter = false;
            var foundPair = false;
            var foundRepeate = false;
            for (int i = 0; i < row.Length; i++)
            {
                //part 1
                if (givenCharacters.Contains(row[i]))
                {
                    uniqueCharacters.Add(row[i]);
                }

                if (i < row.Length - 1 && row[i] == row[i + 1])
                {
                    foundDoubleLetter = true;
                }

                //part2
                for (int j = i + 2; j < row.Length - 1; j++)
                {
                    if (row[i] == row[j] && row[i + 1] == row[j + 1])
                    {
                        foundPair = true;
                        break;
                    }
                }

                if(i < row.Length - 2 && row[i] == row[i + 2])
                {
                    foundRepeate = true;
                }
            }

            if (uniqueCharacters.Count >= 3 && foundDoubleLetter)
            {
                result++;
            }
            if (foundPair && foundRepeate)
            {
                resultPart2++;
            }
        }

        Console.WriteLine(result);
        Console.WriteLine(resultPart2);

    }
}