using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Task10
{
    public static void LookAndSay()
    {
        var input = input10.input;
        StringBuilder resultString = new StringBuilder(input);
        for(int i=0; i < 50; i++)
        {
            StringBuilder newResult =new StringBuilder(10000000);
            var count = 1;
            var length = resultString.Length;
            for (int j = 0; j < length - 1; j++)
            {
                if( resultString[j] == resultString[j + 1])
                {
                    count++;
                }
                else
                {
                    newResult.Append($"{count}{resultString[j]}");
                    count = 1;
                }
            }

            if(resultString[length-1] != resultString[length - 2])
            {
                newResult.Append($"1{resultString[length - 1]}");
            }

            resultString = newResult;
        }

        Console.WriteLine(resultString.Length);
    }
}